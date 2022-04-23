using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerFinancial.ModelService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.DataModel;
using EulerFinancial.Model;
using EulerFinancial.ModelMetadata;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.UnitTest.ModelService
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

            int initialID = 0;

            Account account = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST001_CREATE",
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
            Assert.IsTrue(account.AccountId > initialID);

            // Check the return attributes match the submitted object.
            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount, account));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount.AccountNavigation, account.AccountNavigation));
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
                    a => a.AccountNavigation.AccountObjectCode == "TEST000_SEED")?.AccountId ?? 0;

            var account = await service.ReadAsync(accountID);

            Assert.AreEqual("TEST000_SEED", account?.AccountNavigation?.AccountObjectCode);
            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <summary>
        /// Verifies the unit of work for updating a single <see cref="Account"/>.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UpdateAsync_Returns_True()
        {
            var service = CreateAccountService();

            Account account = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST002_UPDATE",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #002",
                    ObjectDescription = "Account used for testing purposes.",
                    StartDate = new DateTime(2020, 1, 1)
                },
                AccountNumber = "0000-0000-00"
            };

            // Create the new account record to be modified.
            account = await service.CreateAsync(account);

            // Change a few attributes of the model.
            account.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            account.IsComplianceTradable = !account.IsComplianceTradable;
            account.HasWallet = !account.HasWallet;
            account.AccountNavigation.StartDate = account.AccountNavigation.StartDate.AddDays(-5);
            account.AccountNavigation.CloseDate = account.AccountNavigation.StartDate.AddYears(2);

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
        /// Verifies the unit of work for deleting a single <see cref="Account"/>.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteAsync_Returns_True()
        {
            var service = CreateAccountService();

            Account account = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST003_DELETE",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #003",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000-00"
            };

            account = await service.CreateAsync(account);

            var result = await service.DeleteAsync(account);

            using var tmpContext = UnitTest.DbContextFactory.CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && !tmpContext.Accounts.Any(a => a.AccountId == account.AccountId));
        }

        /// <summary>
        /// Verifies the method used to check the existance of a model given an integer key value.
        /// </summary>
        [TestMethod]
        public void ModelExists_UseKeyValue_Returns_True()
        {
            var service = CreateAccountService();

            var result = service.ModelExists(id: 1);

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
                AccountId = 1
            });

            Assert.IsTrue(result);
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
