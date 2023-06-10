using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using NjordinSight.EntityModelService;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class AccountWalletServiceTest : ModelCollectionServiceTest<AccountWallet>
    {
        private const int _accountId = -7;
        protected override Expression<Func<AccountWallet, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        [TestMethod]
        public override async Task Update_PendingSave_HasChanges_IsFalse()
        {
            var service = GetModelService();

            var model = (await service.SelectAsync()).FirstOrDefault();

            model.AddressCode = $"{model.AddressCode}-u";

            Assert.IsFalse(service.HasChanges);
        }

        protected override IModelCollectionService<AccountWallet, int> GetModelService() =>
            BuildModelService<AccountWalletService, int>().WithParent(_accountId);
    }
}
