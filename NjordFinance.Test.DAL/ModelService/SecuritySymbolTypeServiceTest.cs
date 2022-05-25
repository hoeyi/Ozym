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

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
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

        protected override int GetKey(SecuritySymbolType model) => model.SymbolTypeId;

        protected override IModelService<SecuritySymbolType> GetModelService() =>
            BuildModelService<SecuritySymbolTypeService>();
    }
}
