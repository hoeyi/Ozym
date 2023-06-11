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
    public class BankTransactionServiceTest : ModelCollectionServiceTest<BankTransaction>
    {
        private const int _accountId = -6;
        protected override Expression<Func<BankTransaction, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        [TestMethod]
        public override async Task Update_PendingSave_HasChanges_IsFalse()
        {
            var service = GetModelService();

            var model = (await service.SelectAsync()).FirstOrDefault();

            model.Amount *= 1.37M;

            Assert.IsFalse(service.HasChanges);
        }

        protected override IModelCollectionService<BankTransaction, int> GetModelService() =>
            BuildModelService<BankTransactionService, int>().WithParent(_accountId);
    }
}
