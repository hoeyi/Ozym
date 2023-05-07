using NjordFinance.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class InvestmentPerformanceAttributeServiceTest
        : ModelBatchServiceTest<InvestmentPerformanceAttributeMemberEntry>
    {
        private const int _accountObjectId = -5;
        private const int _attributeMemberId = -100;

        protected override Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>>
            ParentExpression => x => x.AccountObjectId == _accountObjectId &&
                x.AttributeMemberId == _attributeMemberId;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="ReadAsync_Returns_Single_Model"/> the 
        /// <see cref="AccountAttributeMemberEntry"/> entity does not have a single-integer key.</remarks>
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

            Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> expression = x =>
                x.AccountObjectId == model.AccountObjectId && x.AttributeMemberId == model.AttributeMemberId
                && x.FromDate == model.FromDate;

            var models = await service.SelectWhereAysnc(predicate: expression, maxCount: 1);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.AverageCapital *= 1.1M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<InvestmentPerformanceAttributeMemberEntry> GetModelService() =>
            BuildModelService<
                InvestmentPerformanceAttributeService,
                (AccountObject, ModelAttributeMember)>()
                .WithParent((
                    new() { AccountObjectId = _accountObjectId, },
                    new() { AttributeMemberId = _attributeMemberId }
                ));
    }
}
