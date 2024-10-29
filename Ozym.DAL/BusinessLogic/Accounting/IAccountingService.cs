using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.BusinessLogic.Functions;
using Ozym.DataTransfer;
using Ozym.DataTransfer.Common;
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
                        orderby a.AccountCode ascending
                        select new
                        {
                            Id = a.AccountId,
                            DisplayName = a.AccountName,
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
                _logger.LogError(e, message: "Unhandled query exception.");
                throw;
            }

        }

        public async Task<(IEnumerable<RecentTransactionRecord>, PaginationData)> RecentBankTransactionsAsync(
            DateTime asOfDate,
            short dayOffset,
            int pageNumber,
            int pageSize,
            params int[] ids)
        {
            dayOffset = BusinessMath.Clamp<short>(dayOffset, -30, -1);

            using var context = await _factory.CreateDbContextAsync();

#pragma warning disable IDE0037 // Use inferred member name
            var queryable = from bt in context.BankTransactions
                            where ids.Contains(bt.AccountId) && 
                                bt.TransactionDate >= asOfDate.AddDays(dayOffset) &&
                                bt.TransactionDate <= asOfDate &&
                                bt.Account.HasBankTransaction.Equals(true)
                            orderby bt.TransactionDate
                            select new RecentTransactionRecord
                            {
                                AccountId = bt.AccountId,
                                AccountName = bt.Account.AccountName,
                                TransactionDate = bt.TransactionDate,
                                Amount = bt.Amount,
                                Comment = bt.Comment,
                                Category = bt.TransactionCode.DisplayName
                            };
#pragma warning restore IDE0037 // Use inferred member name

            PaginationData pageData = new()
            {
                ItemCount = await queryable.CountAsync(),
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            try
            {
                var result = await queryable
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToListAsync();

                return (result, pageData);
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: "Unhandled query exception.");
                throw;
            }
        }
    }
}
