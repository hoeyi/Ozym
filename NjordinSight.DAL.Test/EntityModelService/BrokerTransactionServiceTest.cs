using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class BrokerTransactionServiceTest : ModelCollectionServiceTest<BrokerTransaction>
    {
        private const int _accountId = -5;

        /// <inheritdoc/>
        protected override Expression<Func<BrokerTransaction, bool>> ParentExpression =>
               x => x.AccountId == _accountId;

        /// <inheritdoc/>
        protected override IModelCollectionService<BrokerTransaction> GetModelService() =>
            BuildModelService<BrokerTransactionService>();
    }
}
