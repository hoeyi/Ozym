using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class SecurityServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Security deleted = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityDescription == DeleteModelSuccessSample.SecurityDescription,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.Securities
                .Any(x => x.SecurityId == deleted.SecurityId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Security original = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityDescription == UpdateModelSuccessSample.SecurityDescription,
                maxCount: 1))
                .First();

            original.SecurityDescription = $"{original.SecurityDescription}-u";
            original.HasPerpetualPrice = !original.HasPerpetualPrice;
            original.HasPerpetualMarket = !original.HasPerpetualPrice;
            original.SecurityExchangeId = original.SecurityExchangeId == -1 ? -2 : -1;

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.Securities
                .FirstOrDefault(a => a.SecurityId == original.SecurityId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class SecurityServiceTest
        : ModelServiceTest<Security>
    {
        protected override Security CreateModelSuccessSample => new()
        {
            SecurityDescription = "TestCreatePass",
            SecurityExchangeId = -1,
            HasPerpetualMarket = true,
            HasPerpetualPrice = false,
            SecurityTypeId = -300
        };

        protected override Security DeleteModelSuccessSample => new()
        {
            SecurityDescription = "Test delete pass",
            SecurityExchangeId = -2,
            HasPerpetualMarket = true,
            HasPerpetualPrice = false,
            SecurityTypeId = -302
        };

        protected override Security DeleteModelFailSample => new()
        {
            SecurityId = -1000,
            SecurityDescription = "Test delete fail",
            SecurityTypeId = -301
        };

        protected override Security UpdateModelSuccessSample => new()
        {
            SecurityDescription = "Test update pass",
            SecurityExchangeId = -1,
            HasPerpetualMarket = true,
            HasPerpetualPrice = false,
            SecurityTypeId = -310
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.SecurityExchange WHERE ExchangeID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.SecurityDescription,
                },
                new
                {
                    UpdateModelSuccessSample.SecurityDescription
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.SecurityDescription == DeleteModelSuccessSample.SecurityDescription
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.SecurityDescription == UpdateModelSuccessSample.SecurityDescription
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(Security model) => model.SecurityId;

        protected override IModelService<Security> GetModelService() =>
            BuildModelService<SecurityService>();
    }
}
