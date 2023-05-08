using NjordinSight.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public partial class MarketHolidayServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketHoliday deleted = (await service.SelectWhereAysnc(
                predicate: x => x.MarketHolidayName == DeleteModelSuccessSample.MarketHolidayName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.MarketHolidays
                .Any(x => x.MarketHolidayId == deleted.MarketHolidayId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketHoliday original = await service.ReadAsync(id: -2);

            original.MarketHolidayName = $"{original.MarketHolidayName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.MarketHolidays
                .FirstOrDefault(a => a.MarketHolidayId == original.MarketHolidayId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class MarketHolidayServiceTest : ModelServiceTest<MarketHoliday>
    {
        protected override MarketHoliday CreateModelSuccessSample => new()
        {
            MarketHolidayName = "Test create pass"
        };

        protected override MarketHoliday DeleteModelSuccessSample => new()
        {
            MarketHolidayName = "Test delete pass"
        };

        protected override MarketHoliday DeleteModelFailSample => new()
        {
            MarketHolidayId = -1000,
            MarketHolidayName = "Test delete fail"
        };

        protected override MarketHoliday UpdateModelSuccessSample => new()
        {
            MarketHolidayName = "Test update pass"
        };

        protected override IModelService<MarketHoliday> GetModelService() =>
            BuildModelService<MarketHolidayService>();
    }
}
