using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class MarketIndexPriceServiceTest
        : ModelCollectionServiceTest<MarketIndexPrice>
    {
        protected override Expression<Func<MarketIndexPrice, bool>> ParentExpression => x => true;

        //TODO: 1. Determine what is meant here. 2. Find a better way to say it.
        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="Update_PendingSave_HasChanges_IsFalse"/> the 
        /// <see cref="MarketIndexPrice"/> entity does not have updatable members.</remarks>
        [TestMethod]
        public override Task Update_PendingSave_HasChanges_IsFalse()
        {
            return Task.CompletedTask;
        }

        protected override IModelCollectionService<MarketIndexPrice> GetModelService() =>
            BuildModelService<MarketIndexPriceBatchService>();

    }
}
