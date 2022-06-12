using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class InvestmentStrategyServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            using var context = CreateDbContext();
            InvestmentStrategy deleted = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == DeleteModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);


            Assert.IsTrue(result && !context.InvestmentStrategies
                .Any(x => x.InvestmentStrategyId == deleted.InvestmentStrategyId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            InvestmentStrategy original = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == UpdateModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            original.DisplayName = $"{original.DisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.InvestmentStrategies
                .FirstOrDefault(a => a.InvestmentStrategyId == original.InvestmentStrategyId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class InvestmentStrategyServiceTest
        : ModelServiceTest<InvestmentStrategy>
    {
        protected override InvestmentStrategy CreateModelSuccessSample => new()
        {
            DisplayName = "Test create pass"
        };

        protected override InvestmentStrategy DeleteModelSuccessSample => new()
        {
            DisplayName = "Test delete pass"
        };

        protected override InvestmentStrategy DeleteModelFailSample => new()
        {
            InvestmentStrategyId = -1000,
            DisplayName = "Test delete fail"
        };

        protected override InvestmentStrategy UpdateModelSuccessSample => new()
        {
            DisplayName = "Test update pass"
        };

        protected override IModelService<InvestmentStrategy> GetModelService() =>
            BuildModelService<InvestmentStrategyService>();

    }
}
