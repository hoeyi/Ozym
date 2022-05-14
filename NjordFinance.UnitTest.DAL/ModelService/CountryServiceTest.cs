using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    /// <inheritdoc/>
    [TestClass]
    public partial class CountryServiceTest
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }
        
    }

    /// <inheritdoc/>
    public partial class CountryServiceTest : ModelServiceBaseTest<Country>
    {
        /// <inheritdoc/>
        protected override Country CreateModelSuccessSample => new()
        {
            IsoCode3 = "FRA",
            DisplayName = "France"
        };

        /// <inheritdoc/>
        protected override Country DeleteModelSuccessSample => new()
        {
            IsoCode3 = "DEU",
            DisplayName = "Germany"
        };

        /// <inheritdoc/>
        protected override Country DeleteModelFailSample => new()
        {
            CountryId = -1000,
            IsoCode3 = "FAL",
            DisplayName = "TEST DELETE FAIL"
        };

        /// <inheritdoc/>
        protected override Country UpdateModelSuccessSample => new()
        {
            IsoCode3 = "MEX",
            DisplayName = "Mexico"
        };

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", nameof(CountryServiceTest));

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.Country WHERE CountryID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.IsoCode3,
                    DeleteModelSuccessSample.DisplayName
                },
                new
                {
                    UpdateModelSuccessSample.IsoCode3,
                    UpdateModelSuccessSample.DisplayName
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.IsoCode3 == DeleteModelSuccessSample.IsoCode3
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.IsoCode3 == UpdateModelSuccessSample.IsoCode3
                ));
        }

        /// <inheritdoc/>
        protected override int GetKey(Country model) => model.CountryId;

        /// <inheritdoc/>
        protected override IModelService<Country> GetModelService() =>
            BuildModelService<CountryService>();
    }
}
