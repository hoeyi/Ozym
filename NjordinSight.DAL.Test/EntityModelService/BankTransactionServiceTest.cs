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

        protected override IModelCollectionService<BankTransaction, int> GetModelService() =>
            BuildModelService<BankTransactionService, int>().WithParent(_accountId);
    }
}
