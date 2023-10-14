using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class BankTransactionServiceTest : ModelCollectionServiceTest<BankTransaction>
    {
        private const int _accountId = -6;

        /// <inheritdoc/>
        protected override Expression<Func<BankTransaction, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        /// <inheritdoc/>
        protected override IModelCollectionService<BankTransaction> GetModelService() =>
            BuildModelService<BankTransactionService>();
    }
}
