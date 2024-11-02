using Ozym.DataTransfer;
using Ozym.DataTransfer.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    /// <summary>
    /// Represents a service for accounting-related operations in both banking and investing.
    /// </summary>
    public interface IAccountingService
    {
        /// <summary>
        /// Retrieves the bank balances for the specified accounts as of a given date.
        /// </summary>
        /// <param name="accountIds">The account IDs to retrieve the balances for.</param>
        /// <param name="asOfDate">The date to retrieve the bank balances.</param>
        /// <param name="pageNumber">The page number of the results.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>A tuple containing the account balance records and pagination data.</returns>
        Task<(IEnumerable<AccountBalanceResult>, PaginationData)> BankBalancesAsync(
            int[] accountIds,
            DateTime asOfDate, 
            int pageNumber, 
            int pageSize);

        /// <summary>
        /// Retrieves the bank transaction report for the specified accounts within a date range.
        /// </summary>
        /// <param name="accountIds">The account IDs to retrieve the transactions for.</param>
        /// <param name="fromDate">The start date of the date range.</param>
        /// <param name="toDate">The end date of the date range.</param>
        /// <param name="attributeId1">Optional attribute ID 1 to include in the result set.</param>
        /// <param name="attributeId2">Optional attribute ID 2 to include in the result set.</param>
        /// <returns>The bank transaction records.</returns>
        Task<IEnumerable<BankTransactionResult>> BankTransactionReportAsync(
            int[] accountIds, 
            DateTime fromDate, 
            DateTime toDate, 
            int? attributeId1 = null, 
            int? attributeId2 = null);

        /// <summary>
        /// Retrieves the recent bank transactions for the specified accounts based on a given date and day offset.
        /// </summary>
        /// <param name="accountIds">The account IDs to retrieve the transactions for.</param>
        /// <param name="asOfDate">The reference date for retrieving recent transactions.</param>
        /// <param name="dayOffset">The number of days to offset from the reference date. Limited to range [0, 365].</param>
        /// <param name="pageNumber">The page number of the results.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>A tuple containing the recent bank transaction records and pagination data.</returns>
        /// <exception cref="ArgumentOutOfRangeException">See <paramref name="dayOffset"/> for allowable range.</exception>
        Task<(IEnumerable<BankTransactionResult>, PaginationData)> RecentBankTransactionsAsync(
            int[] accountIds, 
            DateTime asOfDate, 
            int dayOffset, 
            int pageNumber, 
            int pageSize);
    }
}
