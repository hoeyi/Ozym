using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class AccountCustodianServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountCustodian deleted = (await service.SelectWhereAysnc(a =>
                a.CustodianCode == DeleteModelSuccessSample.CustodianCode, 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result &&
                !context.AccountCustodians.Any(
                    a => a.AccountCustodianId == DeleteModelSuccessSample.AccountCustodianId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountCustodian original = (await service.SelectWhereAysnc(
                predicate: x =>
                    x.CustodianCode == UpdateModelSuccessSample.CustodianCode,
                maxCount: 1))
                .First();

            original.DisplayName = "Test custodian UPDATED";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.AccountCustodians.FirstOrDefault(a =>
                a.AccountCustodianId == original.AccountCustodianId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                updated, original));
        }
    }

    public partial class AccountCustodianServiceTest : ModelServiceTest<AccountCustodian>
    {
        protected override AccountCustodian CreateModelSuccessSample => new()
        {
            CustodianCode = "TESTCREATE",
            DisplayName = "Test custodian create."
        };

        protected override AccountCustodian DeleteModelSuccessSample => new()
        {
            CustodianCode = "TESTDELPASS",
            DisplayName = "Test custodian delete."
        };

        protected override AccountCustodian DeleteModelFailSample => new()
        {
            AccountCustodianId = -1000,
            CustodianCode = "TESTDELFAIL",
            DisplayName = "Test custodian delete FAIL."
        };

        protected override AccountCustodian UpdateModelSuccessSample => new()
        {
            CustodianCode = "TESTUPDATE",
            DisplayName = "Test custodian update."
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.AccountCustodian WHERE AccountCustodianID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
                        {
                new
                {
                    DeleteModelSuccessSample.CustodianCode,
                    DeleteModelSuccessSample.DisplayName
                },
                new
                {
                    DeleteModelFailSample.CustodianCode,
                    DeleteModelFailSample.DisplayName
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample, 
                    x => x.CustodianCode == DeleteModelSuccessSample.CustodianCode),
                (
                    UpdateModelSuccessSample, 
                    x => x.CustodianCode == UpdateModelSuccessSample.CustodianCode));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(AccountCustodian model) => model.AccountCustodianId;

        protected override IModelService<AccountCustodian> GetModelService() =>
            BuildModelService<AccountCustodianService>();
    }
}
