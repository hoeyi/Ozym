using NjordinSight.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class InvestmentPerformanceEntryServiceTest 
        : ModelBatchServiceTest<InvestmentPerformanceEntry>
    {
        private const int _accountObjectId = -8;
        protected override Expression<Func<InvestmentPerformanceEntry, bool>> ParentExpression =>
               x => x.AccountObjectId == _accountObjectId;

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

            Expression<Func<InvestmentPerformanceEntry, bool>> expression = x =>
                x.AccountObjectId == model.AccountObjectId && x.FromDate == model.FromDate;

            var models = (await service.SelectAsync(predicate: expression, pageSize: 1)).Item1;;

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAsync().Result.FirstOrDefault();

            model.AverageCapital *= 1.37M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<InvestmentPerformanceEntry> GetModelService() =>
            BuildModelService<InvestmentPerformanceService>().WithParent(_accountObjectId);
    }
}
