using NjordFinance.EntityModel;
using NjordFinance.EntityModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class ModelAttributeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ModelAttribute deleted = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == DeleteModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.ModelAttributes
                .Any(x => x.AttributeId == deleted.AttributeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ModelAttribute original = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == UpdateModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            original.DisplayName = $"{original.DisplayName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.ModelAttributes
                .FirstOrDefault(a => a.AttributeId == original.AttributeId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
        
    }
    public partial class ModelAttributeServiceTest
        : ModelServiceTest<ModelAttribute>
    {
        protected override ModelAttribute CreateModelSuccessSample => new()
        {
            DisplayName = "Test create pass"
        };

        protected override ModelAttribute DeleteModelSuccessSample => new()
        {
            DisplayName = "Test delete pass"
        };

        protected override ModelAttribute DeleteModelFailSample => new()
        {
            AttributeId = -1000,
            DisplayName = "Test delete fail"
        };

        protected override ModelAttribute UpdateModelSuccessSample => new()
        {
            DisplayName = "Test update pass"
        };

        protected override IModelService<ModelAttribute> GetModelService() =>
            BuildModelService<ModelAttributeService>();
    }
}
