using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class ResourceImageServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ResourceImage deleted = (await service.SelectWhereAysnc(
                predicate: x => x.ImageDescription == DeleteModelSuccessSample.ImageDescription,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.ResourceImages
                .Any(x => x.ImageId == deleted.ImageId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ResourceImage original = (await service.SelectWhereAysnc(
                predicate: x => x.ImageDescription == UpdateModelSuccessSample.ImageDescription,
                maxCount: 1))
                .First();

            original.ImageDescription = $"{original.ImageDescription}-u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.ResourceImages
                .FirstOrDefault(a => a.ImageId == original.ImageId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class ResourceImageServiceTest
        : ModelServiceTest<ResourceImage>
    {
        protected override ResourceImage CreateModelSuccessSample => new()
        {
            ImageDescription = "TestCreatePass",
            ImageBinary = Resources.Images.fractal_circle_icon_dark,
            FileExtension = "JPG"
        };

        protected override ResourceImage DeleteModelSuccessSample => new()
        {
            ImageDescription = "Test delete pass"
        };

        protected override ResourceImage DeleteModelFailSample => new()
        {
            ImageId = -1000,
            ImageDescription = "Test delete fail",
            ImageBinary = Resources.Images.fractal_circle_icon_dark,
            FileExtension = "PNG"
        };

        protected override ResourceImage UpdateModelSuccessSample => new()
        {
            ImageDescription = "Test update pass"
        };

        protected override IModelService<ResourceImage> GetModelService() =>
            BuildModelService<ResourceImageService>();
    }
}
