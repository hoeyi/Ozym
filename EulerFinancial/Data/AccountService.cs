using EulerFinancial.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Data
{
    public class AccountService : IAccountService
    {
        private readonly Context.EulerFinancialContext context;
        public AccountService(Context.EulerFinancialContext context)
        {
            this.context = context;
        }

        public async Task<IList<AccountCustodian>> GetAccountCustodians()
        {
            return await context.AccountCustodians.ToListAsync();
        }

        public Task<bool> CreateAsync(Account model)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> ReadAsync(int? id)
        {
            return await context.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
        }

        public Task<bool> UpdateAsync(Account model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Account model)
        {
            throw new NotImplementedException();
        }

        public bool ModelExists(int? id)
        {
            if(id is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == id);
        }

        public bool ModelExists(Account model)
        {
            if(model is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == model.AccountId);
        }

        public async Task<IList<Account>> SelectAllAsync()
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();
        }

        public async Task<Account> SelectOneAsync(Expression<Func<Account, bool>> predicate)
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .FirstOrDefaultAsync(predicate);
        }

        public async Task<IList<Account>> SelectWhereAysnc(Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .ToListAsync();
        }

    }
}
