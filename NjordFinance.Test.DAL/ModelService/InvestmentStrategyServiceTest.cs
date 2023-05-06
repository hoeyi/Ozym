using NjordFinance.EntityModel;
using NjordFinance.EntityModelService;
using System;
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

        [TestMethod]
        public async Task UpdateAsync_WhereChildCompositeKeyIsAltered_Returns_True()
        {
            var service = GetModelService();

            InvestmentStrategy original = await service.ReadAsync(id: -4);

            var newDate = DateTime.Now.Date;

            foreach(var target in original.InvestmentStrategyTargets)
            {
                target.EffectiveDate = newDate;
            }

            var result = await service.UpdateAsync(original);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateAsync_WhereChildValuesAreAltered_Returns_True()
        {
            var service = GetModelService();

            InvestmentStrategy original = await service.ReadAsync(id: -4);

            original.InvestmentStrategyTargets.First().Weight = 0.1M;
            original.InvestmentStrategyTargets.Skip(1).First().Weight = 0.9M;

            var result = await service.UpdateAsync(original);

            Assert.IsTrue(result);
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
