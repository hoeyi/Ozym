using NjordinSight.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class BrokerTransactionServiceTest : ModelBatchServiceTest<BrokerTransaction>
    {
        private const int _accountId = -5;
        protected override Expression<Func<BrokerTransaction, bool>> ParentExpression =>
               x => x.AccountId == _accountId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAsync().Result.FirstOrDefault();

            model.Amount *= 1.37M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<BrokerTransaction> GetModelService() => 
            BuildModelService<BrokerTransactionService>().WithParent(_accountId);
    }
}
