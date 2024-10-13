using Microsoft.EntityFrameworkCore;
using Moq;
using Ozym.BusinessLogic.Accounting;
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
        public async Task BankBalancesAsync_ShouldReturnAccountBalancesAndPaginationData()
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
    }
}
