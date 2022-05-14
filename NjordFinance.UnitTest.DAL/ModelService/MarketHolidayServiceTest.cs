using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
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

            MarketHoliday original = (await service.SelectWhereAysnc(
                predicate: x => x.MarketHolidayName == UpdateModelSuccessSample.MarketHolidayName,
                maxCount: 1))
                .First();

            original.MarketHolidayName = $"{original.MarketHolidayName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.MarketHolidays
                .FirstOrDefault(a => a.MarketHolidayId == original.MarketHolidayId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class MarketHolidayServiceTest : ModelServiceBaseTest<MarketHoliday>
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

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", nameof(MarketHolidayServiceTest));

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.MarketHoliday WHERE MarketHolidayID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.MarketHolidayName,
                },
                new
                {
                    UpdateModelSuccessSample.MarketHolidayName
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.MarketHolidayName == DeleteModelSuccessSample.MarketHolidayName
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.MarketHolidayName == UpdateModelSuccessSample.MarketHolidayName
                ));

            Logger.LogInformation("{Test} initialized.", nameof(MarketHolidayService));
        }

        protected override int GetKey(MarketHoliday model) => model.MarketHolidayId;

        protected override IModelService<MarketHoliday> GetModelService() =>
            BuildModelService<MarketHolidayService>();
    }
}
