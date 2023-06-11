using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class BrokerTransactionServiceTest : ModelCollectionServiceTest<BrokerTransaction>
    {
        private const int _accountId = -5;
        protected override Expression<Func<BrokerTransaction, bool>> ParentExpression =>
               x => x.AccountId == _accountId;

        [TestMethod]
        public override async Task Update_PendingSave_HasChanges_IsFalse()
        {
            var service = GetModelService();

            var model = (await service.SelectAsync()).FirstOrDefault();

            model.Amount *= 1.37M;

            Assert.IsFalse(service.HasChanges);
        }

        protected override IModelCollectionService<BrokerTransaction, int> GetModelService() => 
            BuildModelService<BrokerTransactionService, int>().WithParent(_accountId);
    }
}
