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

            Assert.IsTrue(result && UnitTest.SimplePropertiesAreEqual(updated, original));
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
            TransactionCode = "TDP",
            DisplayName = "Test delete pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
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
            TransactionCode = "TUP",
            DisplayName = "Test update pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.BrokerTransactionCode WHERE TransactionCodeId > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.TransactionCodeId,
                    DeleteModelSuccessSample.TransactionCode
                },
                new
                {
                    UpdateModelSuccessSample.TransactionCodeId,
                    UpdateModelSuccessSample.TransactionCode
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.TransactionCode == DeleteModelSuccessSample.TransactionCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.TransactionCode == UpdateModelSuccessSample.TransactionCode
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(BrokerTransactionCode model) => model.TransactionCodeId;

        protected override IModelService<BrokerTransactionCode> GetModelService() =>
            BuildModelService<BrokerTransactionCodeService>();
    }
}
