using EulerFinancial.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Services
{
    public class AccountService : Data.IAccountService
    {
        private readonly Data.Context.EulerFinancialContext context;
        public AccountService(Data.Context.EulerFinancialContext context)
        {
            this.context = context;
        }

        public Task<bool> Create(Account model)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Read(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Account model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Account model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AccountCustodian>> GetAccountCustodians()
        {
            throw new NotImplementedException();
        }

        public bool ModelExists(Account model)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Account>> SelectAllAsync()
        {
            return await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();
        }

        public Task<IList<Account>> SelectOneAsync(Expression<Func<Account, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Account>> SelectWhereAysnc(Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            throw new NotImplementedException();
        }

    }
}
