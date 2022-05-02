using System;
using System.Linq;
using System.Threading.Tasks;
using NjordFinance.ModelService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.DataModel;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Exceptions;

namespace NjordFinance.UnitTest.ModelService
{
    /// <summary>
    /// Test class for verifying each unit of work done by <see cref="AccountService"/>.
    /// </summary>
    [TestClass]
    public partial class AccountServiceTest
    {
        /// <summary>
        /// Verifies the unit of work for a reading a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task GetDefaultAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();

            var account = await service.GetDefaultAsync();

            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <summary>
        /// Verifies the unit of work for a creating a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task CreateAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();

            Account account = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TESTCRE",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #001",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000-00"
            };

            account = await service.CreateAsync(account);

            // Create a new context for checking results. Avoids dependency on model service.
            using var tmpContext = UnitTest.DbContextFactory.CreateDbContext();

            var savedAccount = tmpContext.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(a => a.AccountId == account.AccountId);

            // Verify the primary key is assigned.
            Assert.IsTrue(account.AccountId > 0);

            // Check the return attributes match the submitted object.
            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount, account));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount.AccountNavigation, account.AccountNavigation));
        }

        /// <summary>
        /// Verifies the unit of work for deleting a single <see cref="Account"/>.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteAsync_Returns_True()
        {
            UnitTest.DbContextFactory.RefreshDbContext();

            var service = CreateAccountService();

            var query = await service.SelectAllAsync();

            Account account = query.Where(a => a.AccountCode == "TESTSEED").First();

            var result = await service.DeleteAsync(account);

            using var tmpContext = UnitTest.DbContextFactory.CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && !tmpContext.Accounts.Any(a => a.AccountId == account.AccountId));
        }

        /// <summary>
        /// Verifies a deletion request for a non-existent account yields a 
        /// <see cref="DbUpdateException"/>.
        /// </summary>
        [TestMethod]
        public async Task DeleteAsync_InvalidAccount_ThrowsModelUpdateException()
        {
            UnitTest.DbContextFactory.RefreshDbContext();

            var service = CreateAccountService();

            Account account = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectId = 10,
                    AccountObjectCode = "TESTFAIL",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST DELETE ACCOUNT FAILURE",
                    ObjectDescription = "Test object for causing a failed delete request."
                },
                AccountNumber = "0000-0000-00",
                AccountId = 10
            };

            await Assert.ThrowsExceptionAsync<ModelUpdateException>(async () =>
            {
                await service.DeleteAsync(account);
            });
        }

        /// <summary>
        /// Verifies the unit of work for reading a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task ReadAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();
            using var tmpContext = UnitTest.DbContextFactory.CreateDbContext();

            var accountID = tmpContext.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(
                    a => a.AccountNavigation.AccountObjectCode == "TESTBROKER")?.AccountId ?? 0;

            var account = await service.ReadAsync(accountID);

            Assert.AreEqual("TESTBROKER", account?.AccountNavigation?.AccountObjectCode);
            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <summary>
        /// Verifies the unit of work for updating a single <see cref="Account"/>.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UpdateAsync_Returns_True()
        {
            UnitTest.DbContextFactory.RefreshDbContext();

            var service = CreateAccountService();

            var query = await service.SelectAllAsync();

            Account account = query.Where(a => a.AccountCode == "TESTSEED").First();

            // Change a few attributes of the model.
            account.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            account.IsComplianceTradable = !account.IsComplianceTradable;
            account.HasWallet = !account.HasWallet;
            account.AccountNavigation.StartDate = account.AccountNavigation.StartDate.AddDays(-273);
            account.AccountNavigation.CloseDate = account.AccountNavigation.StartDate.AddYears(5);

            // Send the updates to the database.
            var result = await service.UpdateAsync(account);

            // Open a context for checking results.
            using var tmpContext = UnitTest.DbContextFactory.CreateDbContext();

            var savedAccount = tmpContext.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(a => a.AccountId == account.AccountId);

            // Check the return attributes match the submitted object.
            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount, account));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount.AccountNavigation, account.AccountNavigation));
        }

        /// <summary>
        /// Verifies the method used to check the existance of a model given an integer key value.
        /// </summary>
        [TestMethod]
        public void ModelExists_UseKeyValue_Returns_True()
        {
            var service = CreateAccountService();

            var result = service.ModelExists(id: -1);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Verifies the method used to check the existance of a model given a model instance.
        /// </summary>
        [TestMethod]
        public void ModelExists_UseModel_Returns_True()
        {
            var service = CreateAccountService();

            var result = service.ModelExists(model: new()
            {
                AccountId = -1
            });

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Verifies the method used to return all <see cref="Account"/> objects matching 
        /// the given predicate, limited to 1 result.
        /// </summary>
        [TestMethod]
        public async Task SelectWhereAsync_Returns_Accounts_List()
        {
            var service = CreateAccountService();

            var result = await service.SelectWhereAysnc(
                predicate: a => a.AccountNavigation.AccountObjectCode == "TESTBANK",
                maxCount: 1);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].AccountCode == "TESTBANK");
        }

        /// <summary>
        /// Verifies the method used to return all <see cref="Account"/> objects.
        /// </summary>
        [TestMethod]
        public async Task SelectAllAsync_Returns_Accounts_List()
        {
            var service = CreateAccountService();

            var result = await service.SelectAllAsync();

            Assert.IsTrue(result.Count > 0);
        }
    }

    public partial class AccountServiceTest
    {
        private static AccountService CreateAccountService() => new(
            contextFactory: UnitTest.DbContextFactory,
            modelMetadata: new ModelMetadataService(),
            logger: UnitTest.Logger);
    }
}
