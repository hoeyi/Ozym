using NjordFinance.EntityModel;
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

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
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

        protected override IModelService<Security> GetModelService() =>
            BuildModelService<SecurityService>();
    }
}
