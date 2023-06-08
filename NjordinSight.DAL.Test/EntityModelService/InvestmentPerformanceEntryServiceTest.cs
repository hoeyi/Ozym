using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class InvestmentPerformanceEntryServiceTest 
        : ModelCollectionServiceTest<InvestmentPerformanceEntry>
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
        public override async Task Update_PendingSave_HasChanges_IsFalse()
        {
            var service = GetModelService();

            var model = (await service.SelectAsync()).FirstOrDefault();

            model.AverageCapital *= 1.37M;

            Assert.IsFalse(service.HasChanges);
        }

        protected override IModelCollectionService<InvestmentPerformanceEntry, int> GetModelService() =>
            BuildModelService<InvestmentPerformanceService, int>().WithParent(_accountObjectId);
    }
}
