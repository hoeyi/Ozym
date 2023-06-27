using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class AccountWalletServiceTest : ModelCollectionServiceTest<AccountWallet>
    {
        private const int _accountId = -7;
        protected override Expression<Func<AccountWallet, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        protected override IModelCollectionService<AccountWallet, int> GetModelService() =>
            BuildModelService<AccountWalletService, int>().WithParent(_accountId);
    }
}
