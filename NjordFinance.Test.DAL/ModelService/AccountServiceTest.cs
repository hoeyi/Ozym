using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class AccountServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Account deleted = (await service.SelectWhereAysnc(
                predicate: a => 
                    a.AccountNavigation.AccountObjectCode == DeleteModelSuccessSample.AccountCode, 
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            // Check delete action was successful and the account is not found in the DbContext.
            Assert.IsTrue(result && 
                !context.Accounts.Any(a => a.AccountId == deleted.AccountId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Account original = (await service.SelectWhereAysnc(
                predicate: x =>
                    x.AccountNavigation.AccountObjectCode == UpdateModelSuccessSample.AccountCode,
                maxCount: 1))
                .First();
            
            // Change a few attributes of the model.
            original.AccountNavigation.ObjectDisplayName = "TEST ACCOUNT #002 - UPDATED";
            original.IsComplianceTradable = !original.IsComplianceTradable;
            original.HasWallet = !original.HasWallet;
            original.AccountNavigation.StartDate = original.AccountNavigation.StartDate.AddDays(-273);
            original.AccountNavigation.CloseDate = original.AccountNavigation.StartDate.AddYears(5);

            // Send the updates to the database.
            var result = await service.UpdateAsync(original);

            // Open a context for checking results.
            using var context = CreateDbContext();

            var updated = context.Accounts
                .Include(a => a.AccountNavigation)
                .FirstOrDefault(a => a.AccountId == original.AccountId);

            // Check the return attributes match the submitted object.
            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                updated, original));

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                updated.AccountNavigation, original.AccountNavigation));
        }
    }

    public partial class AccountServiceTest : ModelServiceTest<Account>
    {
        private readonly Random _random = new();


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

        protected override Account DeleteModelSuccessSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectCode = "TESTDELPASS"
            }
        };

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

        protected override Account UpdateModelSuccessSample => new()
        {
            AccountNavigation = new()
            {
                AccountObjectCode = "TESTUPDPASS"
            }
        };

        protected override Expression<Func<Account, object>>[] IncludePaths => 
            new Expression<Func<Account, object>>[]
            {
                a => a.AccountNavigation
            };

        protected override int GetKey(Account model) => model.AccountId;

        protected override IModelService<Account> GetModelService() =>
            BuildModelService<AccountService>();

    }
}
