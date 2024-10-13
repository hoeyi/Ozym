using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public AccountingService(IDbContextFactory<FinanceDbContext> factory, ILogger logger)
        {
            ArgumentNullException.ThrowIfNull(factory);
            ArgumentNullException.ThrowIfNull(logger);

            _factory = factory;
            _logger = logger;
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

            try
            {
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
            catch(Exception e)
            {
                _logger.LogError(e, message: "Query exception raised.");
                throw;
            }

        }
    }
}
