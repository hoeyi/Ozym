using EulerFinancial.Context;
using EulerFinancial.Model;
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
    /// The class for servicing single CRUD requests agains the <see cref="Account"/> 
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
        public override async Task<Account> GetDefault()
        {
            var defaultTask = Task.Run(() => new Account()
            {
                AccountNavigation = new AccountObject()
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

            await context.SaveChangesAsync();

            await transaction.CommitAsync();

            return model;
        }

        /// <inheritdoc/>   
        public override async Task<Account> ReadAsync(int? id)
        {
            return await context.Accounts
                                .Include(a => a.AccountCustodian)
                                .Include(a => a.AccountNavigation)
                                .FirstOrDefaultAsync(a => a.AccountId == id);
        }

        /// <inheritdoc/>
        public override async Task<bool> UpdateAsync(Account model)
        {
            logger?.LogDebug("Update called on {Model} with {EntityState}",
                model, context.Entry(model).State);

            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return true;
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

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (DbUpdateException)
            {
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
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();
        }

        /// <inheritdoc/>
        public override async Task<Account> SelectOneAsync(
            Expression<Func<Account, bool>> predicate)
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public override async Task<List<Account>> SelectWhereAysnc(
            Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .Take(maxCount)
                            .ToListAsync();
        }

    }
}
