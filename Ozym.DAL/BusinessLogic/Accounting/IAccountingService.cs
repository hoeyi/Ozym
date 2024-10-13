using Microsoft.EntityFrameworkCore;
using Ozym.DataTransfer;
using Ozym.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    public class AccountingService
    {
        private readonly IDbContextFactory<FinanceDbContext> _factory;
        public AccountingService(IDbContextFactory<FinanceDbContext> factory)
        {
            ArgumentNullException.ThrowIfNull(factory);
            _factory = factory;
        }

        public async Task<(IEnumerable<AccountBalanceRecord>, PaginationData)> BankBalancesAsync(
            DateTime asOfDate,
            int pageNumber,
            int pageSize,
            params int[] ids)
        {
            using var context = await _factory.CreateDbContextAsync();

            var queryable = from a in context.Accounts
                        where ids.Contains(a.AccountId)
                        select new
                        {
                            Id = a.AccountId,
                            DisplayName = a.AccountCode,
                            Balance = context.BankBalance(a.AccountId, asOfDate),
                            AsOfDate = asOfDate
                        };

            PaginationData pageData = new()
            {
                ItemCount = await queryable.CountAsync(),
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            // TODO: This needs an ORDER BY clause in order to generate consistent results.
            var result = await queryable
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            var recordResult = result.Select(x => new AccountBalanceRecord()
            {
                AccountId = x.Id,
                DisplayName = x.DisplayName,
                Balance = x.Balance,
                AsOfDate = x.AsOfDate
            });

            return (recordResult, pageData);
        }
    }
}
