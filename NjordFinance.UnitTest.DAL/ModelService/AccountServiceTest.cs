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
    /// <summary>
    /// Test class for verifying each unit of work done by <see cref="AccountService"/>.
    /// </summary>
    [TestClass]
    public partial class AccountServiceTest : AbstractModelServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            using var context = CreateDbContext();

            if(!context.AccountObjects
                .Any(a => a.AccountObjectCode == DeleteSuccessAccountSample.AccountCode))
            {
                context.Add(DeleteSuccessAccountSample);
            }

            if(!context.AccountObjects
                .Any(a => a.AccountObjectCode == UpdateAccountSample.AccountCode))
            {
                context.Add(UpdateAccountSample);
            }

            context.SaveChanges();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using var context = CreateDbContext();

            context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.Account WHERE AccountID > 0;" +
                "DELETE FROM NjordDbTest.FinanceApp.AccountObject WHERE AccountObjectID > 0");
        }

        /// <summary>
        /// Verifies the unit of work for a reading a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task GetDefaultAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();

            var account = await service.Writer.GetDefaultAsync();

            Assert.IsInstanceOfType(account, typeof(Account));
        }

        /// <summary>
        /// Verifies the unit of work for a creating a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task CreateAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();

            Account account = await service.Writer.CreateAsync(CreateAccountSample);

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

        /// <summary>
        /// Verifies the unit of work for deleting a single <see cref="Account"/>.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task DeleteAsync_Returns_True()
        {
            var service = CreateAccountService();

            Account account = (await service.Reader.SelectWhereAysnc(a =>
                a.AccountNavigation.AccountObjectCode == "TESTDELPASS", 1))
                .First();

            var result = await service.Writer.DeleteAsync(account);

            using var tmpContext = CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && 
                !tmpContext.Accounts.Any(a => a.AccountId == account.AccountId));
        }

        /// <summary>
        /// Verifies a deletion request for a non-existent account yields a 
        /// <see cref="DbUpdateException"/>.
        /// </summary>
        [TestMethod]
        public async Task DeleteAsync_InvalidAccount_ThrowsModelUpdateException()
        {
            var service = CreateAccountService();

            await Assert.ThrowsExceptionAsync<ModelUpdateException>(async () =>
            {
                await service.Writer.DeleteAsync(DeleteFailAccountSample);
            });
        }

        /// <summary>
        /// Verifies the unit of work for reading a single <see cref="Account"/>.
        /// </summary>
        [TestMethod]
        public async Task ReadAsync_Returns_Single_Account()
        {
            var service = CreateAccountService();

            using var tmpContext = CreateDbContext();

            var accountID = tmpContext.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(
                    a => a.AccountNavigation.AccountObjectCode == "TESTUPDATE")?.AccountId ?? 0;

            var account = await service.Reader.ReadAsync(accountID);

            Assert.AreEqual("TESTUPDATE", account?.AccountNavigation?.AccountObjectCode);
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

            var query = await service.Reader.SelectAllAsync();

            Account account = query.Where(a => a.AccountCode == "TESTUPDATE").First();

            // Change a few attributes of the model.
            account.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            account.IsComplianceTradable = !account.IsComplianceTradable;
            account.HasWallet = !account.HasWallet;
            account.AccountNavigation.StartDate = account.AccountNavigation.StartDate.AddDays(-273);
            account.AccountNavigation.CloseDate = account.AccountNavigation.StartDate.AddYears(5);

            // Send the updates to the database.
            var result = await service.Writer.UpdateAsync(account);

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

        /// <summary>
        /// Verifies the method used to check the existance of a model given an integer key value.
        /// </summary>
        [TestMethod]
        public void ModelExists_UseKeyValue_Returns_True()
        {
            var service = CreateAccountService();

            var result = service.Reader.ModelExists(id: -1);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Verifies the method used to check the existance of a model given a model instance.
        /// </summary>
        [TestMethod]
        public void ModelExists_UseModel_Returns_True()
        {
            Account account = GetLast<Account>();
            
            // Use the servied to verify model existance.
            var service = CreateAccountService();
            var result = service.Reader.ModelExists(model: account);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Verifies the method used to return all <see cref="Account"/> objects matching 
        /// the given predicate, limited to 1 result.
        /// </summary>
        [TestMethod]
        public async Task SelectWhereAsync_Returns_Accounts_List()
        {
            Account expected = GetLast<Account>(a => a.AccountNavigation);

            var service = CreateAccountService();

            var observed = (await service.Reader.SelectWhereAysnc(
                predicate: a => a.AccountNavigation.AccountObjectId == expected.AccountId,
                maxCount: 1))
                .First();

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(expected, observed));
        }

        /// <summary>
        /// Verifies the method used to return all <see cref="Account"/> objects.
        /// </summary>
        [TestMethod]
        public async Task SelectAllAsync_Returns_Accounts_List()
        {
            var service = CreateAccountService();

            var result = await service.Reader.SelectAllAsync();

            Assert.IsTrue(result.Count > 0);
        }
    }

    public partial class AccountServiceTest
    {
        private static readonly Random _random = new();

        private static Account CreateAccountSample => new()
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

        private static Account DeleteSuccessAccountSample => new()
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

        private static Account DeleteFailAccountSample => new()
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

        private static Account UpdateAccountSample => new()
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

        private static AccountService CreateAccountService() => new(
            contextFactory: UnitTest.DbContextFactory,
            modelMetadata: new ModelMetadataService(),
            logger: UnitTest.Logger);
    }
}
