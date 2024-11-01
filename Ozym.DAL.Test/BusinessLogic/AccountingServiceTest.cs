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
                await _accountingService.BankBalancesAsync(accountIds, asOfDate, pageNumber, pageSize);

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
            DateTime asOfDate = new(2017, 9, 30);
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
            var (result, paginationData) =
                await _accountingService.RecentBankTransactionsAsync(
                    accountIds, asOfDate, 30, pageNumber, pageSize);

            // Assert
            // Instances are present.
            Assert.IsNotNull(result);
            Assert.IsNotNull(paginationData);

            // Inconclusive if there are no results.
            if (!result.Any())
                Assert.Inconclusive("Test database is missing sample data.");
        }

        [TestMethod]
        public async Task BankTransactionReportAsync_NoAttributes_ShouldReturnBankTransactionReport()
        {
            // Arrange
            using var context = TestUtility.DbContextFactory.CreateDbContext();

            int[] accountIds = await (
                                    from a in context.Accounts
                                    where a.HasBankTransaction.Equals(true)
                                    select a.AccountId
                                )
                                .ToArrayAsync();

            DateTime fromDate = new(2020, 1, 1);
            DateTime toDate = new(2023, 12, 31);
            int? attributeId1 = null;
            int? attributeId2 = null;

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var result = await _accountingService.BankTransactionReportAsync(accountIds, fromDate, toDate, attributeId1, attributeId2);

            // Assert
            // Instances are present.
            Assert.IsNotNull(result);

            // Result counts are as expected.
            Assert.AreNotEqual(notExpected: 0, actual: result.Count());
        }

        [TestMethod]
        public async Task BankTransactionReportAsync_WithAttributes_ShouldReturnBankTransactionReport()
        {
            // Arrange
            using var context = TestUtility.DbContextFactory.CreateDbContext();

            int[] accountIds = await context.Accounts
                                              .Where(x => x.HasBankTransaction.Equals(true))
                                              .Select(x => x.AccountId)
                                              .ToArrayAsync();

            string scopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode();
            int[] attributeIds = await context.ModelAttributes
                                        .Include(m => m.ModelAttributeScopes)
                                        .Where(x => x.ModelAttributeScopes
                                                    .Any(x => x.ScopeCode.Equals(scopeCode)))
                                        .Select(x => x.AttributeId)
                                        .ToArrayAsync();
            
            // Short-circuit here. This test requires two attributes.
            if(attributeIds.Length < 2)
                Assert.Inconclusive($"Test requires at least two attributes.");

            DateTime fromDate = new(2020, 1, 1);
            DateTime toDate = new(2023, 12, 31);
            int? attributeId1 = attributeIds[0];
            int? attributeId2 = attributeIds[1];

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var result = await _accountingService.BankTransactionReportAsync(accountIds, fromDate, toDate, attributeId1, attributeId2);

            // Assert
            // Instances are present.
            Assert.IsNotNull(result);

            // Result counts are as expected.
            Assert.AreNotEqual(notExpected: 0, actual: result.Count());

            // All of Attribute{1|2} -Name and -Value members are not null.
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute1Name)));
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute1Value)));
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute2Name)));
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute2Value)));
        }

        [TestMethod]
        public async Task BankTransactionReportAsync_Attribute1Null_ShouldReturnBankTransactionReport()
        {
            // Arrange
            using var context = TestUtility.DbContextFactory.CreateDbContext();

            int[] accountIds = await context.Accounts
                                              .Where(x => x.HasBankTransaction.Equals(true))
                                              .Select(x => x.AccountId)
                                              .ToArrayAsync();

            string scopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode();
            int[] attributeIds = await context.ModelAttributes
                                        .Include(m => m.ModelAttributeScopes)
                                        .Where(x => x.ModelAttributeScopes
                                                    .Any(x => x.ScopeCode.Equals(scopeCode)))
                                        .Select(x => x.AttributeId)
                                        .ToArrayAsync();

            // Short-circuit here. This test requires at least one attribute.
            if (attributeIds.Length < 1)
                Assert.Inconclusive($"Test requires at least 1 attribute.");

            DateTime fromDate = new(2020, 1, 1);
            DateTime toDate = new(2023, 12, 31);
            int? attributeId1 = null;
            int? attributeId2 = attributeIds[0];

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var result = await _accountingService.BankTransactionReportAsync(accountIds, fromDate, toDate, attributeId1, attributeId2);

            // Assert
            // Instances are present.
            Assert.IsNotNull(result);

            // Inconclusive if there are no results.
            if (!result.Any())
                Assert.Inconclusive("Test database is missing sample data.");

            // All of Attribute1 -Name and -Value members are null.
            Assert.IsTrue(result.All(x => string.IsNullOrEmpty(x.Attribute1Name)));
            Assert.IsTrue(result.All(x => string.IsNullOrEmpty(x.Attribute1Value)));

            // Some of Attribute2 -Name and -Value members are not null.
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute2Name)));
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute2Value)));
        }

        [TestMethod]
        public async Task BankTransactionReportAsync_Attribute2Null_ShouldReturnBankTransactionReport()
        {
            // Arrange
            using var context = TestUtility.DbContextFactory.CreateDbContext();

            int[] accountIds = await context.Accounts
                                              .Where(x => x.HasBankTransaction.Equals(true))
                                              .Select(x => x.AccountId)
                                              .ToArrayAsync();

            string scopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode();
            int[] attributeIds = await context.ModelAttributes
                                        .Include(m => m.ModelAttributeScopes)
                                        .Where(x => x.ModelAttributeScopes
                                                    .Any(x => x.ScopeCode.Equals(scopeCode)))
                                        .Select(x => x.AttributeId)
                                        .ToArrayAsync();

            // Short-circuit here. This test requires at least one attribute.
            if (attributeIds.Length < 1)
                Assert.Inconclusive($"Test requires at least 1 attribute.");

            DateTime fromDate = new(2020, 1, 1);
            DateTime toDate = new(2023, 12, 31);
            int? attributeId1 = attributeIds[0];
            int? attributeId2 = null;

            var _accountingService = new AccountingService(TestUtility.DbContextFactory, TestUtility.Logger);

            // Act
            var result = await _accountingService.BankTransactionReportAsync(accountIds, fromDate, toDate, attributeId1, attributeId2);

            // Assert
            // Instances are present.
            Assert.IsNotNull(result);

            // Inconclusive if there are no results.
            if (!result.Any())
                Assert.Inconclusive("Test database is missing sample data.");

            // Some of Attribute1 -Name and -Value members are not null.
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute1Name)));
            Assert.IsTrue(result.Any(x => !string.IsNullOrEmpty(x.Attribute1Value)));

            // All of Attribute2 -Name and -Value members are null.
            Assert.IsTrue(result.All(x => string.IsNullOrEmpty(x.Attribute2Name)));
            Assert.IsTrue(result.All(x => string.IsNullOrEmpty(x.Attribute2Value)));
        }
    }
}
