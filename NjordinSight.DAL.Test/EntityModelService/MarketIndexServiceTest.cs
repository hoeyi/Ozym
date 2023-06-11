using NjordinSight.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public partial class MarketIndexServiceTest
        : ModelServiceTest<MarketIndex>
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketIndex deleted = (await service.SelectAsync(
                predicate: x => x.IndexCode == DeleteModelSuccessSample.IndexCode,
                pageSize: 1))
                .Item1.First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.MarketIndices
                .Any(x => x.IndexId == deleted.IndexId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            MarketIndex original = (await service.SelectAsync(
                predicate: x => x.IndexCode == UpdateModelSuccessSample.IndexCode,
                pageSize: 1))
                .Item1.First();

            original.IndexCode = $"{original.IndexCode}-u";
            original.IndexDescription = $"{original.IndexDescription} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.MarketIndices
                .FirstOrDefault(a => a.IndexId == original.IndexId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
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
            IndexCode = "DELETEPASS"
        };

        protected override MarketIndex DeleteModelFailSample => new()
        {
            IndexId = -1000,
            IndexCode = "DELETEFAIL",
            IndexDescription = "Test delete fail"
        };

        protected override MarketIndex UpdateModelSuccessSample => new()
        {
            IndexCode = "UPDATEPASS"
        };

        protected override IModelService<MarketIndex> GetModelService() =>
            BuildModelService<MarketIndexService>();
    }
}
