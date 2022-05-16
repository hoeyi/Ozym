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
    public partial class MarketIndexServiceTest
        : ModelServiceTest<MarketIndex>
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketIndex deleted = (await service.SelectWhereAysnc(
                predicate: x => x.IndexCode == DeleteModelSuccessSample.IndexCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.MarketIndices
                .Any(x => x.IndexId == deleted.IndexId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketIndex original = (await service.SelectWhereAysnc(
                predicate: x => x.IndexCode == UpdateModelSuccessSample.IndexCode,
                maxCount: 1))
                .First();

            original.IndexCode = $"{original.IndexCode}-u";
            original.IndexDescription = $"{original.IndexDescription} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.MarketIndices
                .FirstOrDefault(a => a.IndexId == original.IndexId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class MarketIndexServiceTest
    {
        protected override MarketIndex CreateModelSuccessSample => new()
        {
            IndexCode = "CREATEPASS",
            IndexDescription = "Test create pass"
        };

        protected override MarketIndex DeleteModelSuccessSample => new()
        {
            IndexCode = "DELETEPASS",
            IndexDescription = "Test delete pass"
        };

        protected override MarketIndex DeleteModelFailSample => new()
        {
            IndexId = -1000,
            IndexCode = "DELETEFAIL",
            IndexDescription = "Test delete fail"
        };

        protected override MarketIndex UpdateModelSuccessSample => new()
        {
            IndexCode = "UPDATEPASS",
            IndexDescription = "Test update pass"
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.MarketIndex WHERE IndexID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }


        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.IndexCode,
                },
                new
                {
                    UpdateModelSuccessSample.IndexCode
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.IndexCode == DeleteModelSuccessSample.IndexCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.IndexCode == UpdateModelSuccessSample.IndexCode
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(MarketIndex model) => model.IndexId;

        protected override IModelService<MarketIndex> GetModelService() =>
            BuildModelService<MarketIndexService>();
    }
}
