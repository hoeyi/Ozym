using Microsoft.EntityFrameworkCore;
using Moq;
using Ozym.BusinessLogic.Accounting;
using Ozym.DataTransfer;
using Ozym.EntityModel;
using Ozym.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Integration")]
    public class AccountingServiceTest
    {
        [TestMethod]
        public async Task BankBalancesAsync_ShouldReturnAccountBalances()
        {
            // Arrange
            DateTime asOfDate = DateTime.Now;
            int pageNumber = 1;
            int pageSize = 10;

            using var context = TestUtility.DbContextFactory.CreateDbContext();
            int[] accountIds = await (
                                    from a in context.Accounts
                                    where a.HasBankTransaction.Equals(true)
                                    select a.AccountId
                                )
                                .ToArrayAsync();

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var (accountBalances, paginationData) =
                await _accountingService.BankBalancesAsync(asOfDate, pageNumber, pageSize, accountIds);

            // Assert
            // Instances are present.
            Assert.IsNotNull(accountBalances);
            Assert.IsNotNull(paginationData);

            // Result counts are as expected.
            Assert.AreEqual(expected: accountIds.Length, actual: accountBalances.Count());
            Assert.AreNotEqual(notExpected: 0, actual: accountBalances.Count());
        }

        [TestMethod]
        public async Task RecentBankTransactionsAsync_ShouldReturnRecentBankTransactions()
        {
            // Arrange
            DateTime asOfDate = new(2023, 3, 31);
            int pageNumber = 1;
            int pageSize = 10;

            using var context = TestUtility.DbContextFactory.CreateDbContext();
            int[] accountIds = await (
                                    from a in context.Accounts
                                    where a.HasBankTransaction.Equals(true)
                                    select a.AccountId
                                )
                                .ToArrayAsync();

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var (recentBankTransactions, paginationData) =
                await _accountingService.RecentBankTransactionsAsync(
                    asOfDate, -30, pageNumber, pageSize, accountIds);

            // Assert
            // Instances are present.
            Assert.IsNotNull(recentBankTransactions);
            Assert.IsNotNull(paginationData);

            // Result counts are as expected. Zero expected because test database is missing
            // required data.
            Assert.AreNotEqual(notExpected: 0, actual: recentBankTransactions.Count());
        }
    }
}
