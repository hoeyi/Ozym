using NjordFinance.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Test.EntityModelService
{
    [TestClass]
    public class InvestmentStrategyTargetServiceTest
        : ModelBatchServiceTest<InvestmentStrategyTarget>
    {
        private const int _investmentStrategyId = -3;
        protected override Expression<Func<InvestmentStrategyTarget, bool>> ParentExpression =>
            x => x.InvestmentStrategyId == _investmentStrategyId;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="ReadAsync_Returns_Single_Model"/> the 
        /// <see cref="InvestmentPerformanceEntry"/> entity does not have a single-integer key.</remarks>
        [TestMethod]
        public override Task ReadAsync_Returns_Single_Model()
        {
            return Task.CompletedTask;
        }

        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_ExpectedCollection()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            Expression<Func<InvestmentStrategyTarget, bool>> expression = x =>
                x.InvestmentStrategyId == model.InvestmentStrategyId
                && x.AttributeMemberId == model.AttributeMemberId
                && x.EffectiveDate == model.EffectiveDate;

            var models = await service.SelectWhereAysnc(predicate: expression, maxCount: 1);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Weight -= 0.15M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<InvestmentStrategyTarget> GetModelService() =>
            BuildModelService<InvestmentStrategyTargetService>().WithParent(parentId: _investmentStrategyId);

    }
}
