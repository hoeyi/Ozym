using NjordFinance.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class AccountWalletServiceTest : ModelBatchServiceTest<AccountWallet>
    {
        private const int _accountId = -7;
        protected override Expression<Func<AccountWallet, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.AddressCode = $"{model.AddressCode}-u";

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<AccountWallet> GetModelService() =>
            BuildModelService<AccountWalletService>().WithParent(parentId: _accountId);
    }
}
