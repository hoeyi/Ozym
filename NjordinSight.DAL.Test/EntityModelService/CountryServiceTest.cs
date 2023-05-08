using NjordinSight.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public partial class CountryServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Country deleted = (await service.SelectWhereAysnc(
                predicate: x => x.IsoCode3 == DeleteModelSuccessSample.IsoCode3,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.CountryAttributeMemberEntries
                .Any(x => x.CountryId == deleted.CountryId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            Country original = (await service.SelectWhereAysnc(
                predicate: x => x.IsoCode3 == UpdateModelSuccessSample.IsoCode3,
                maxCount: 1))
                .First();

            original.DisplayName = $"{original.DisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.Countries
                .FirstOrDefault(a => a.CountryId == original.CountryId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
        
    }

    public partial class CountryServiceTest : ModelServiceTest<Country>
    {
        protected override Country CreateModelSuccessSample => new()
        {
            AttributeMemberNavigation = new()
            {
                AttributeId = -60,
                DisplayName = "ZZZ",
                DisplayOrder = 0
            },
            IsoCode3 = "ZZZ",
            DisplayName = "ZanzibarbarianLand"
        };

        protected override Country DeleteModelSuccessSample => new()
        {
            IsoCode3 = "DEU"
        };

        protected override Country DeleteModelFailSample => new()
        {
            CountryId = -1000,
            IsoCode3 = "FAL",
            DisplayName = "TEST DELETE FAIL"
        };

        protected override Country UpdateModelSuccessSample => new()
        {
            IsoCode3 = "USA"
        };

        protected override IModelService<Country> GetModelService() =>
            BuildModelService<CountryService>();
    }
}
