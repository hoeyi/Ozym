using EulerFinancial.Context;
using EulerFinancial.Model;
using EulerFinancial.ModelMetadata;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EulerFinancial.Logging;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Account"/> 
    /// data store.
    /// </summary>
    public class AccountService : ModelServiceBase<Account>, IModelService<Account>
    {
        /// <inheritdoc/>
        public AccountService(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger)
            : base(context, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override async Task<Account> GetDefaultAsync()
        {
            var defaultTask = Task.Run(() => new Account()
            {
                AccountNavigation = new AccountObject()
                {
                    ObjectType = AccountObjectType.Account.ConvertToStringCode()
                }
            });

            return await defaultTask;
        }

        /// <inheritdoc/>
        public override async Task<Account> CreateAsync(Account model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            context.AccountObjects.Add(model.AccountNavigation);

            await context.SaveChangesAsync();

            model.AccountId = model.AccountNavigation.AccountObjectId;
            context.Accounts.Add(model);

            var count = await context.SaveChangesAsync();

            await transaction.CommitAsync();

            var result = count > 0;

            if (result)
                logger.ModelServiceCreatedModel(
                    new
                    {
                        Type = model.GetType().Name,
                        Id = model.AccountId,
                        Code = model.AccountCode
                    });

            return model;
        }

        /// <inheritdoc/>   
        public override async Task<Account> ReadAsync(int? id)
        {
            try
            {
                var result = await context.Accounts
                                    .Include(a => a.AccountCustodian)
                                    .Include(a => a.AccountNavigation)
                                    .FirstOrDefaultAsync(a => a.AccountId == id);

                if (result is not null)
                    logger.ModelServiceReadModel(
                        model: new
                        {
                            Type = typeof(Account).Name,
                            result.AccountId,
                            result.AccountCode
                        });

                return result;
            }
            catch(Exception exception)
            {
                logger.ModelServiceReadSingleFailed(
                    model: new
                    {
                        Type = typeof(Account).Name,
                        Id = id
                    },
                    exception);

                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<bool> UpdateAsync(Account model)
        {
            context.Entry(model).State = EntityState.Modified;

            var count = await context.SaveChangesAsync();
            var result = count > 0;

            if (result)
                logger.ModelServiceUpdatedModel(
                    model: new
                    {
                        Type = typeof(Account).Name,
                        model.AccountId,
                        model.AccountCode
                    });

            return result;
        }

        /// <inheritdoc/>
        public override async Task<bool> DeleteAsync(Account model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.BankTransactions.RemoveRange(
                    context.BankTransactions.Where(bt => bt.AccountId == model.AccountId));

                context.BrokerTransactions.RemoveRange(
                    context.BrokerTransactions.Where(bt => bt.AccountId == model.AccountId));

                context.AccountGroupMembers.RemoveRange(
                    context.AccountGroupMembers.Where(agm => agm.AccountId == model.AccountId));

                context.AccountWallets.RemoveRange(
                    context.AccountWallets.Where(w => w.AccountId == model.AccountId));

                await context.SaveChangesAsync();

                context.Accounts.Remove(model);

                context.AccountAttributeMemberEntries.RemoveRange(
                    context.AccountAttributeMemberEntries.Where(aa => aa.AccountObjectId == model.AccountId));

                await context.SaveChangesAsync();

                context.AccountObjects.Remove(
                    context.AccountObjects.Where(a => a.AccountObjectId == model.AccountId).First());

                var count = await context.SaveChangesAsync();
                var result = count > 0;

                await transaction.CommitAsync();

                if (result)
                    logger.ModelServiceDeletedModel(
                        model: new
                        {
                            Type = typeof(Account).Name,
                            model.AccountId,
                            model.AccountCode
                        });

                return result;
            }
            catch (DbUpdateException e)
            {
                logger.ModelServiceSaveChangesFailed(e);

                return !ModelExists(model.AccountId);
            }
        }

        /// <inheritdoc/>
        public override bool ModelExists(int? id)
        {
            if (id is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == id);
        }

        /// <inheritdoc/>
        public override bool ModelExists(Account model)
        {
            if (model is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == model.AccountId);
        }

        /// <inheritdoc/>
        public override async Task<List<Account>> SelectAllAsync()
        {
            Expression<Func<Account, bool>> expression = x => true;

            var searchGuid = Guid.NewGuid();

            logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(Account),
                predicate: expression.Body,
                recordLimit: int.MaxValue);

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();

            logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(Account),
                resultCount: result?.Count ?? default);

            return result;
        }

        /// <inheritdoc/>
        public override async Task<List<Account>> SelectWhereAysnc(
            Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            var searchGuid = Guid.NewGuid();

            logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(Account),
                predicate: predicate.Body,
                recordLimit: maxCount);

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .Take(maxCount)
                            .ToListAsync();

            logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(Account),
                resultCount: result?.Count ?? default);

            return result;
        }

    }
}
