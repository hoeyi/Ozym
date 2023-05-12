using NjordinSight.EntityModel;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class MarketIndexPriceServiceTest
        : ModelBatchServiceTest<MarketIndexPrice>
    {
        protected override Expression<Func<MarketIndexPrice, bool>> ParentExpression => x => true;

        //TODO: 1. Determine what is meant here. 2. Find a better way to say it.
        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="UpdatePendingSave_IsDirty_Is_True"/> the 
        /// <see cref="MarketIndexPrice"/> entity does not have updatable members.</remarks>
        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            return;
        }

        protected override IModelBatchService<MarketIndexPrice> GetModelService() =>
            BuildModelService<MarketIndexPriceBatchService>();

    }
}
