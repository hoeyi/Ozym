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

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
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
            ImageDescription = "Test delete pass",
            ImageBinary = Resources.Images.fractal_circle_icon_dark,
            FileExtension = "PNG"
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
            ImageDescription = "Test update pass",
            ImageBinary = Resources.Images.fractal_circle_icon_dark,
            FileExtension = "JPG"
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.ResourceImage WHERE ImageID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.ImageDescription,
                },
                new
                {
                    UpdateModelSuccessSample.ImageDescription
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.ImageDescription == DeleteModelSuccessSample.ImageDescription
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.ImageDescription == UpdateModelSuccessSample.ImageDescription
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(ResourceImage model) => model.ImageId;

        protected override IModelService<ResourceImage> GetModelService() =>
            BuildModelService<ResourceImageService>();
    }
}
