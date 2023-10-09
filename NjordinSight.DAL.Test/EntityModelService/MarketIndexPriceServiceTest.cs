using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class MarketIndexPriceServiceTest : ModelCollectionServiceTest<MarketIndexPrice>
    {
        /// <inheritdoc/>
        protected override Expression<Func<MarketIndexPrice, bool>> ParentExpression => x => true;

        /// <inheritdoc/>
        protected override IModelCollectionService<MarketIndexPrice> GetModelService() =>
            BuildModelService<MarketIndexPriceService>();

    }
}
