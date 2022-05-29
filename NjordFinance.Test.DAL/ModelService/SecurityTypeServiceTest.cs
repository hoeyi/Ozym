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
    public partial class SecurityTypeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityType deleted = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityTypeName ==
                    DeleteModelSuccessSample.SecurityTypeName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.SecurityTypes
                .Any(x => x.SecurityTypeId == deleted.SecurityTypeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityType original = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityTypeName ==
                    UpdateModelSuccessSample.SecurityTypeName,
                maxCount: 1))
                .First();

            original.SecurityTypeName = $"{original.SecurityTypeName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.SecurityTypes
                .FirstOrDefault(a => a.SecurityTypeId == original.SecurityTypeId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class SecurityTypeServiceTest
        : ModelServiceTest<SecurityType>
    {
        protected override SecurityType CreateModelSuccessSample => new()
        {
            SecurityTypeNavigation = new()
            {
                AttributeId = -30,
                DisplayName = "Test create pass",
                DisplayOrder = 0,
            },
            SecurityTypeName = "Test create pass",
            CanHavePosition = false,
            CanHaveDerivative = true,
            ValuationFactor = 0M,
            SecurityTypeGroupId = -200
        };

        protected override SecurityType DeleteModelSuccessSample => new()
        {
            SecurityTypeNavigation = new()
            {
                AttributeId = -3,
                DisplayName = "Test delete pass",
                DisplayOrder = 1,
            },
            SecurityTypeName = "Test delete pass",
            CanHaveDerivative = true,
            CanHavePosition = true,
            ValuationFactor = -1M,
            SecurityTypeGroupId = -201
        };

        protected override SecurityType DeleteModelFailSample => new()
        {
            SecurityTypeNavigation = new()
            {
                AttributeMemberId = -1000,
                AttributeId = -3,
                DisplayName = "Test delete fail",
                DisplayOrder = 2,
            },
            SecurityTypeId = -1000,
            SecurityTypeName = "Test delete fail",
            SecurityTypeGroupId = -202
        };

        protected override SecurityType UpdateModelSuccessSample => new()
        {
            SecurityTypeNavigation = new()
            {
                AttributeId = -3,
                DisplayName = "Test update pass",
                DisplayOrder = 2,
            },
            SecurityTypeName = "Test update pass",
            CanHaveDerivative = true,
            CanHavePosition = true,
            ValuationFactor = 1M,
            SecurityTypeGroupId = -203
        };

        protected override IModelService<SecurityType> GetModelService() =>
            BuildModelService<SecurityTypeService>();
    }
}
