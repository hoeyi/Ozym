using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class SecuritySymbolTypeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecuritySymbolType deleted = (await service.SelectWhereAysnc(
                predicate: x => x.SymbolTypeName == DeleteModelSuccessSample.SymbolTypeName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.SecuritySymbolTypes
                .Any(x => x.SymbolTypeId == deleted.SymbolTypeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecuritySymbolType original = (await service.SelectWhereAysnc(
                predicate: x => x.SymbolTypeName == UpdateModelSuccessSample.SymbolTypeName,
                maxCount: 1))
                .First();

            original.SymbolTypeName = $"{original.SymbolTypeName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.SecuritySymbolTypes
                .FirstOrDefault(a => a.SymbolTypeId == original.SymbolTypeId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class SecuritySymbolTypeServiceTest
        : ModelServiceTest<SecuritySymbolType>
    {
        protected override SecuritySymbolType CreateModelSuccessSample => new()
        {
            SymbolTypeName = "TestCreatePass"
        };

        protected override SecuritySymbolType DeleteModelSuccessSample => new()
        {
            SymbolTypeName = "TestDeletePass"
        };

        protected override SecuritySymbolType DeleteModelFailSample => new()
        {
            SymbolTypeId = -1000,
            SymbolTypeName = "TestDeleteFail"
        };

        protected override SecuritySymbolType UpdateModelSuccessSample => new()
        {
            SymbolTypeName = "TestUpdatePass"
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.SecuritySymbolType WHERE SymbolTypeID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.SymbolTypeName,
                },
                new
                {
                    UpdateModelSuccessSample.SymbolTypeName
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.SymbolTypeName == DeleteModelSuccessSample.SymbolTypeName
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.SymbolTypeName == UpdateModelSuccessSample.SymbolTypeName
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }


        protected override int GetKey(SecuritySymbolType model) => model.SymbolTypeId;

        protected override IModelService<SecuritySymbolType> GetModelService() =>
            BuildModelService<SecuritySymbolTypeService>();
    }
}
