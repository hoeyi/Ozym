using NjordinSight.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public partial class SecurityExchangeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityExchange deleted = (await service.SelectWhereAysnc(
                predicate: x => x.ExchangeCode == DeleteModelSuccessSample.ExchangeCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.SecurityExchanges
                .Any(x => x.ExchangeId == deleted.ExchangeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityExchange original = (await service.SelectWhereAysnc(
                predicate: x => x.ExchangeCode == UpdateModelSuccessSample.ExchangeCode,
                maxCount: 1))
                .First();

            original.ExchangeCode = $"{original.ExchangeCode}-u";
            original.ExchangeDescription = $"{original.ExchangeDescription} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.SecurityExchanges
                .FirstOrDefault(a => a.ExchangeId == original.ExchangeId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class SecurityExchangeServiceTest
        : ModelServiceTest<SecurityExchange>
    {
        protected override SecurityExchange CreateModelSuccessSample => new()
        {
            ExchangeCode = "TestCreatePass",
            ExchangeDescription = "Test create pass"
        };

        protected override SecurityExchange DeleteModelSuccessSample => new()
        {
            ExchangeCode = "TestDeletePass",
            ExchangeDescription = "Test delete pass"
        };

        protected override SecurityExchange DeleteModelFailSample => new()
        {
            ExchangeId = -1000,
            ExchangeCode = "TestDeleteFail",
            ExchangeDescription = "Test delete fail"
        };

        protected override SecurityExchange UpdateModelSuccessSample => new()
        {
            ExchangeCode = "TestUpdatePass",
            ExchangeDescription = "Test update pass"
        };

        protected override IModelService<SecurityExchange> GetModelService() =>
            BuildModelService<SecurityExchangeService>();
    }
}
