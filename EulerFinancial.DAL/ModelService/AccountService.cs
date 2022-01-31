using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EulerFinancial.Context;
using EulerFinancial.Model;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// Worker class for servicing CRUD operations against 
    /// a data store of <see cref="Account"/> models.
    /// </summary>
    public class AccountService : IModelService<Account>
    {
        private readonly EulerFinancialContext context;

        public AccountService(EulerFinancialContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<Account> CreateAsync(Account model)
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
        public async Task<Account> ReadAsync(int? id)
        {
            return await context.Accounts
                                .Include(a => a.AccountCustodian)
                                .Include(a => a.AccountNavigation)
                                .FirstOrDefaultAsync(a => a.AccountId == id);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateAsync(Account model)
        {

            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(Account model)
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
            catch(DbUpdateException)
            {
                return !ModelExists(model.AccountId);
            }
        }

        /// <inheritdoc/>
        public bool ModelExists(int? id)
        {
            if (id is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == id);
        }

        /// <inheritdoc/>
        public bool ModelExists(Account model)
        {
            if (model is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == model.AccountId);
        }

        /// <inheritdoc/>
        public async Task<List<Account>> SelectAllAsync()
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Account> SelectOneAsync(Expression<Func<Account, bool>> predicate)
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<List<Account>> SelectWhereAysnc(Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .ToListAsync();
        }

    }
}
