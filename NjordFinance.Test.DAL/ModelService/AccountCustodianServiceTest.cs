using NjordFinance.EntityModel;
using NjordFinance.EntityModelService;
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
            CustodianCode = "TESTDELPASS"
        };

        protected override AccountCustodian DeleteModelFailSample => new()
        {
            AccountCustodianId = -1000,
            CustodianCode = "TESTDELFAIL",
            DisplayName = "Test custodian delete FAIL."
        };

        protected override AccountCustodian UpdateModelSuccessSample => new()
        {
            CustodianCode = "TESTUPDATE"
        };

        protected override IModelService<AccountCustodian> GetModelService() =>
            BuildModelService<AccountCustodianService>();
    }
}
