using EulerFinancial.Context;
using EulerFinancial.Logging;
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

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Account"/> 
    /// data store.
    /// </summary>
    public class AccountService : ModelService<Account>, IModelService<Account>
    {
        /// <inheritdoc/>
        public AccountService(
            IDbContextFactory<EulerFinancialContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override async Task<Account> CreateAsync(Account model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                context.AccountObjects.Add(model.AccountNavigation);

                //await context.SaveChangesAsync();

                model.AccountId = model.AccountNavigation.AccountObjectId;
                context.Accounts.Add(model);

                var count = await context.SaveChangesAsync();

                await transaction.CommitAsync();

                var result = count > 0;

                if (result)
                    _logger.ModelServiceCreatedModel(
                        new
                        {
                            Type = model.GetType().Name,
                            Id = model.AccountId,
                            Code = model.AccountCode
                        });

                return model;
            });
        }

        /// <inheritdoc/>
        public override async Task<bool> DeleteAsync(Account model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                try
                {
                    using var transaction = await context.Database.BeginTransactionAsync();

                    // Remove bank transaction children.
                    if (context.BankTransactions.Any(bt => bt.AccountId == model.AccountId))
                        context.BankTransactions.RemoveRange(
                            context.BankTransactions.Where(bt => bt.AccountId == model.AccountId));

                    // Remove broker transaction children.
                    if (context.BrokerTransactions.Any(bt => bt.AccountId == model.AccountId))
                        context.BrokerTransactions.RemoveRange(
                            context.BrokerTransactions.Where(bt => bt.AccountId == model.AccountId));

                    // Remove account wallet children.
                    if (context.AccountWallets.Any(aw => aw.AccountId == model.AccountId))
                        context.AccountWallets.RemoveRange(
                            context.AccountWallets.Where(w => w.AccountId == model.AccountId));

                    // Remove account attribute children.
                    if (context.AccountAttributeMemberEntries.Any(gm => gm.AccountObjectId == model.AccountId))
                        context.AccountAttributeMemberEntries.RemoveRange(
                            context.AccountAttributeMemberEntries.Where(
                                aa => aa.AccountObjectId == model.AccountId));

                    // Remove account group memberships.
                    if (context.AccountGroupMembers.Any(gm => gm.AccountId == model.AccountId))
                        context.AccountGroupMembers.RemoveRange(
                            context.AccountGroupMembers.Where(agm => agm.AccountId == model.AccountId));

                    // Save changes because cascade delete is not used.
                    await context.SaveChangesAsync();

                    // Remove account.
                    context.Accounts.Remove(model);

                    // Save changes because cascade delete is not used.
                    await context.SaveChangesAsync();

                    // Remove account object.
                    context.AccountObjects.Remove(
                        context.AccountObjects.Where(
                            a => a.AccountObjectId == model.AccountId).First());

                    var count = await context.SaveChangesAsync();
                    var result = count > 0;

                    await transaction.CommitAsync();

                    if (result)
                        _logger.ModelServiceDeletedModel(
                            model: new
                            {
                                Type = typeof(Account).Name,
                                model.AccountId,
                                model.AccountCode
                            });

                    return result;
                }
                catch (DbUpdateException dbe)
                {
                    _logger.ModelServiceSaveChangesFailed(dbe);

                    return !ModelExists(model.AccountId);
                }

            });
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
        public override async Task<Account> ReadAsync(int? id)
        {
            using var context = _contextFactory.CreateDbContext();

            try
            {
                var result = await context.Accounts
                                    .Include(a => a.AccountCustodian)
                                    .Include(a => a.AccountNavigation)
                                    .FirstOrDefaultAsync(a => a.AccountId == id);

                if (result is not null)
                    _logger.ModelServiceReadModel(
                        model: new
                        {
                            Type = typeof(Account).Name,
                            result.AccountId,
                            result.AccountCode
                        });

                return result;
            }
            catch (Exception exception)
            {
                _logger.ModelServiceReadSingleFailed(
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
        public override async Task<List<Account>> SelectAllAsync()
        {
            Expression<Func<Account, bool>> expression = x => true;

            var searchGuid = Guid.NewGuid();

            _logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(Account),
                predicate: expression.Body,
                recordLimit: int.MaxValue);

            using var context = _contextFactory.CreateDbContext();

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();

            _logger.ModelServiceSearchResultReturned(
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

            _logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(Account),
                predicate: predicate.Body,
                recordLimit: maxCount);

            using var context = _contextFactory.CreateDbContext();

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .Take(maxCount)
                            .ToListAsync();

            _logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(Account),
                resultCount: result?.Count ?? default);

            return result;
        }

        /// <inheritdoc/>
        public override async Task<bool> UpdateAsync(Account model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                context.Entry(model).State = EntityState.Modified;
                context.Entry(model.AccountNavigation).State = EntityState.Modified;

                var count = await context.SaveChangesAsync();
                var result = count > 0;

                if (result)
                    _logger.ModelServiceUpdatedModel(
                        model: new
                        {
                            Type = typeof(Account).Name,
                            model.AccountId,
                            model.AccountCode
                        });

                return result;
            });
        }
    }
}
