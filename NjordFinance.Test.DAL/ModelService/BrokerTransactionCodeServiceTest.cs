using NjordFinance.Model;
using NjordFinance.ModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class BrokerTransactionCodeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            BrokerTransactionCode deleted = (await service.SelectWhereAysnc(
                predicate: x => x.TransactionCode == DeleteModelSuccessSample.TransactionCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result &&
                !context.BrokerTransactionCodes.Any(
                    x => x.TransactionCodeId == deleted.TransactionCodeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            BrokerTransactionCode original = (await service.SelectWhereAysnc(
                predicate: x => x.TransactionCode == UpdateModelSuccessSample.TransactionCode,
                maxCount: 1))
                .First();

            original.DisplayName = $"{original.DisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.BrokerTransactionCodes
                .FirstOrDefault(x => x.TransactionCodeId == original.TransactionCodeId);

            Assert.IsTrue(result && !TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }
    public partial class BrokerTransactionCodeServiceTest
        : ModelServiceTest<BrokerTransactionCode>
    {
        protected override BrokerTransactionCode CreateModelSuccessSample => new()
        {
            TransactionCode = "TCP",
            DisplayName = "Test create pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        protected override BrokerTransactionCode DeleteModelSuccessSample => new()
        {
            TransactionCode = "TDP"
        };

        protected override BrokerTransactionCode DeleteModelFailSample => new()
        {
            TransactionCodeId = -1000,
            TransactionCode = "TDF",
            DisplayName = "Test delete fail",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        protected override BrokerTransactionCode UpdateModelSuccessSample => new()
        {
            TransactionCode = "TUP"
        };

        protected override IModelService<BrokerTransactionCode> GetModelService() =>
            BuildModelService<BrokerTransactionCodeService>();
    }
}
