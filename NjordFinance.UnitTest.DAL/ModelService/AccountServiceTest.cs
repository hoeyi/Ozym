using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Exceptions;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    /// <inheritdoc/>
    [TestClass]
    public partial class AccountServiceTest : IModelServiceBaseTest<Account>
    {
        /// <inheritdoc/>
        [TestMethod]
        public async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            Account account = await service.CreateAsync(CreateModelSuccessSample);

            // Create a new context for checking results. Avoids dependency
            // on model service.
            using var tmpContext = CreateDbContext();

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

        /// <inheritdoc/>
        [TestMethod]
        public async Task DeleteAsync_InvalidModel_ThrowsModelUpdateException()
        {
            var service = GetModelService();

            await Assert.ThrowsExceptionAsync<ModelUpdateException>(async () =>
            {
                await service.DeleteAsync(DeleteModelFailSample);
            });
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Account account = (await service.SelectWhereAysnc(a =>
                a.AccountNavigation.AccountObjectCode == "TESTDELPASS", 1))
                .First();

            var result = await service.DeleteAsync(account);

            using var tmpContext = CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && 
                !tmpContext.Accounts.Any(a => a.AccountId == account.AccountId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task GetDefaultAsync_Returns_Single_Model()
        {
            var service = GetModelService();

            var account = await service.GetDefaultAsync();

            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <inheritdoc/>v
        [TestMethod]
        public void ModelExists_KeyIsPresent_Returns_True()
        {
            var service = GetModelService();

            var result = service.ModelExists(id: -1);

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ModelExists_ModelIsPresent_Returns_True()
        {
            Account account = GetLast();
            
            // Use the servied to verify model existance.
            var service = GetModelService();
            var result = service.ModelExists(model: account);

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task ReadAsync_Returns_Single_Model()
        {
            var service = GetModelService();

            using var tmpContext = CreateDbContext();

            var accountID = tmpContext.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(
                    a => a.AccountNavigation.AccountObjectCode == "TESTUPDATE")?.AccountId ?? 0;

            var account = await service.ReadAsync(accountID);

            Assert.AreEqual("TESTUPDATE", account?.AccountNavigation?.AccountObjectCode);
            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task SelectAllAsync_Returns_Model_List()
        {
            var service = GetModelService();

            var result = await service.SelectAllAsync();

            Assert.IsTrue(result.Count > 0);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task SelectWhereAsync_Returns_Model_List()
        {
            Account expected = GetLast(a => a.AccountNavigation);

            var service = GetModelService();

            var observed = (await service.SelectWhereAysnc(
                predicate: a => a.AccountNavigation.AccountObjectId == expected.AccountId,
                maxCount: 1))
                .First();

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(expected, observed));
        }

        /// <inheritdoc/>s
        [TestMethod]
        public async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            var query = await service.SelectAllAsync();

            Account account = query.Where(a => a.AccountCode == "TESTUPDATE").First();

            // Change a few attributes of the model.
            account.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            account.IsComplianceTradable = !account.IsComplianceTradable;
            account.HasWallet = !account.HasWallet;
            account.AccountNavigation.StartDate = account.AccountNavigation.StartDate.AddDays(-273);
            account.AccountNavigation.CloseDate = account.AccountNavigation.StartDate.AddYears(5);

            // Send the updates to the database.
            var result = await service.UpdateAsync(account);

            // Open a context for checking results.
            using var tmpContext = CreateDbContext();

            var savedAccount = tmpContext.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(a => a.AccountId == account.AccountId);

            // Check the return attributes match the submitted object.
            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount, account));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedAccount.AccountNavigation, account.AccountNavigation));
        }
    }

    /// <inheritdoc/>
    public partial class AccountServiceTest : ModelServiceBaseTest<Account>
    {
        private static readonly Random _random = new();

        /// <inheritdoc/>
        protected override Account CreateModelSuccessSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectCode = "TESTCREATE",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "TEST CREATE PASS",
                ObjectDescription = "consectetur adipiscing elit"
            },
            AccountNumber = "0000-0000-00"
        };

        /// <inheritdoc/>
        protected override Account DeleteModelSuccessSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectCode = "TESTDELPASS",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "TEST DELETE PASS",
                ObjectDescription = "Lorem ipsum dolor sit amet"
            },
            AccountNumber = "0000-0000-00",
        };

        /// <inheritdoc/>
        protected override Account DeleteModelFailSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectId = -1000,
                AccountObjectCode = "TESTDELFAIL",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "TEST DELETE FAILURE",
                ObjectDescription = "Lorem ipsum dolor sit amet"
            },
            AccountNumber = "0000-0000-00",
            AccountId = -1000
        };

        /// <inheritdoc/>
        protected override Account UpdateModelSuccessSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectCode = "TESTUPDATE",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "TEST UPDATE",
                ObjectDescription = "sed do eiusmod ",
                StartDate = new DateTime(
                            _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1, 28))
            },
            AccountNumber = "0000-0000-00"
        };

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            using var context = CreateDbContext();

            context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.Account WHERE AccountID > 0;" +
                "DELETE FROM NjordDbTest.FinanceApp.AccountObject WHERE AccountObjectID > 0");
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            SeedModelsIfNotExists(
                including: a => a.AccountNavigation,
                (
                    DeleteModelSuccessSample, 
                    x => x.AccountNavigation.AccountObjectCode == 
                        DeleteModelSuccessSample.AccountCode),
                (
                    UpdateModelSuccessSample, 
                    x => x.AccountNavigation.AccountObjectCode == 
                        UpdateModelSuccessSample.AccountCode));
        }

        /// <inheritdoc/>
        protected override IModelService<Account> GetModelService() =>
            BuildModelService<AccountService>();
    }
}
