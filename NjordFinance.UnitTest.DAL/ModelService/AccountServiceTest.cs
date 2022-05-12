using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public partial class AccountServiceTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            Account account = await service.CreateAsync(CreateModelSuccessSample);

            // Create a new context for checking results. Avoids dependency
            // on model service.
            using var context = CreateDbContext();

            var savedAccount = context.Accounts
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
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Account account = (await service.SelectWhereAysnc(
                predicate: a => 
                    a.AccountNavigation.AccountObjectCode == DeleteModelSuccessSample.AccountCode, 
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(account);

            using var context = CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && 
                !context.Accounts.Any(a => a.AccountId == account.AccountId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_List()
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
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Account account = (await service.SelectWhereAysnc(
                predicate: x =>
                    x.AccountNavigation.AccountObjectCode == UpdateModelSuccessSample.AccountCode,
                maxCount: 1))
                .First();
            
            // Change a few attributes of the model.
            account.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            account.IsComplianceTradable = !account.IsComplianceTradable;
            account.HasWallet = !account.HasWallet;
            account.AccountNavigation.StartDate = account.AccountNavigation.StartDate.AddDays(-273);
            account.AccountNavigation.CloseDate = account.AccountNavigation.StartDate.AddYears(5);

            // Send the updates to the database.
            var result = await service.UpdateAsync(account);

            // Open a context for checking results.
            using var context = CreateDbContext();

            var savedAccount = context.Accounts
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
        private readonly Random _random = new();

        protected override int GetKey(Account model) => model.AccountId;

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
            Logger.LogInformation("Cleaning up {test}.", nameof(AccountServiceTest));

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.Account WHERE AccountID > 0;" +
                "DELETE FROM NjordDbTest.FinanceApp.AccountObject WHERE AccountObjectID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.AccountId,
                    DeleteModelSuccessSample.AccountCode
                },
                new
                {
                    UpdateModelSuccessSample.AccountId,
                    UpdateModelSuccessSample.AccountCode
                }
            });

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
