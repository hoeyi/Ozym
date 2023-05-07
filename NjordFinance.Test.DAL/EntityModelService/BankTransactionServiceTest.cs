using NjordFinance.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class BankTransactionServiceTest : ModelBatchServiceTest<BankTransaction>
    {
        private const int _accountId = -6;
        protected override Expression<Func<BankTransaction, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Amount *= 1.37M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<BankTransaction> GetModelService()
            => BuildModelService<BankTransactionService>().WithParent(_accountId);
    }
}
