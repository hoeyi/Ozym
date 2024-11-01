using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.BusinessLogic.Functions;
using Ozym.DataTransfer;
using Ozym.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    /// <summary>
    /// A service for accounting-related operations in both banking and investing.
    /// </summary>
    public class AccountingService : IAccountingService
    {
        private readonly IDbContextFactory<FinanceDbContext> _factory;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingService"/> class.
        /// </summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingService"/> class.
        /// </summary>
        /// <param name="factory">The factory used to create instances of <see cref="FinanceDbContext"/>.</param>
        /// <param name="logger">The logger to use.</param>
        public AccountingService(
            IDbContextFactory<FinanceDbContext> factory,
            ILogger logger)
        {
            ArgumentNullException.ThrowIfNull(factory);
            ArgumentNullException.ThrowIfNull(logger);

            _factory = factory;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<AccountBalanceResult>, PaginationData)> BankBalancesAsync(
            int[] accountIds,
            DateTime asOfDate,
            int pageNumber,
            int pageSize)
        {
            using var context = await _factory.CreateDbContextAsync();

            var queryable = from a in context.Accounts.Include(a => a.AccountNavigation)
                            where accountIds.Contains(a.AccountId)
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
                var recordResult = result.Select(x => new AccountBalanceResult()
                {
                    AccountId = x.Id,
                    DisplayName = x.DisplayName,
                    Balance = x.Balance,
                    AsOfDate = x.AsOfDate
                });

                return (recordResult, pageData);
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: "Unhandled query exception.");
                throw;
            }

        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<BankTransactionResult>, PaginationData)> RecentBankTransactionsAsync(
            int[] accountIds,
            DateTime asOfDate,
            short dayOffset,
            int pageNumber,
            int pageSize)
        {
            dayOffset = BusinessMath.Clamp<short>(dayOffset, -365, -1);

            using var context = await _factory.CreateDbContextAsync();

#pragma warning disable IDE0037 // Use inferred member name
            var queryable = from bt in context.BankTransactions
                            where accountIds.Contains(bt.AccountId) &&
                                bt.TransactionDate >= asOfDate.AddDays(dayOffset) &&
                                bt.TransactionDate <= asOfDate &&
                                bt.Account.HasBankTransaction.Equals(true)
                            orderby bt.TransactionDate
                            select new BankTransactionResult
                            {
                                AccountId = bt.AccountId,
                                AccountName = bt.Account.AccountName,
                                TransactionDate = bt.TransactionDate,
                                Amount = bt.Amount,
                                Comment = bt.Comment,
                                TransactionCode = bt.TransactionCode.DisplayName
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

        /// <inheritdoc/>
        public async Task<IEnumerable<BankTransactionResult>> BankTransactionReportAsync(
            int[] accountIds,
            DateTime fromDate,
            DateTime toDate,
            int? attributeId1 = null,
            int? attributeId2 = null)
        {
            string idsDelimited = string.Join(",", accountIds);

            using var context = await _factory.CreateDbContextAsync();

            using var sqlConnection = new SqlConnection(context.Database.GetConnectionString());

            using var sqlCommand = new SqlCommand(
                cmdText: "FinanceApp.pReportBankTransactions",
                connection: sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Map method parameters to SqlCommand parameters.
            sqlCommand.Parameters.AddRange([
                    new()
                    {
                        ParameterName = "AccountIds",
                        SqlDbType = SqlDbType.NVarChar,
                        IsNullable = false,
                        Value = idsDelimited
                    },
                    new()
                    {
                        ParameterName = "FromDate",
                        SqlDbType = SqlDbType.Date,
                        IsNullable = false,
                        Value = fromDate
                    },
                    new()
                    {
                        ParameterName = "ThruDate",
                        SqlDbType = SqlDbType.Date,
                        IsNullable = false,
                        Value = toDate
                    },
                    new()
                    {
                        ParameterName = "AttributeId1",
                        SqlDbType = SqlDbType.Int,
                        IsNullable = true,
                        Value = attributeId1
                    },
                    new()
                    {
                        ParameterName = "AttributeId2",
                        SqlDbType = SqlDbType.Int,
                        IsNullable = true,
                        Value = attributeId2
                    }
                ]);
            try
            {
                await sqlConnection.OpenAsync();
                var dataTable = new DataTable();
                using (var reader = await sqlCommand.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }

                var recordResult = dataTable.AsEnumerable()
                    .Select(row => new BankTransactionResult
                    {
                        AccountId = row.Field<int>("AccountId"),
                        AccountName = row.Field<string>("AccountName"),
                        TransactionCode = row.Field<string>("TransactionCode"),
                        TransactionDate = row.Field<DateTime>("TransactionDate"),
                        Amount = row.Field<decimal>("Amount"),
                        Comment = row.Field<string>("Comment"),
                        Attribute1Name = row.Field<string>("Attribute1Name"),
                        Attribute1Value = row.Field<string>("Attribute1Value"),
                        Attribute2Name = row.Field<string>("Attribute2Name"),
                        Attribute2Value = row.Field<string>("Attribute2Value"),
                    })
                    .ToList();

                return (recordResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: "Unhandled query exception.");
                throw;
            }
        }
    }
}
