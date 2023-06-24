using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class MarketIndexPriceServiceTest
        : ModelCollectionServiceTest<MarketIndexPrice>
    {
        protected override Expression<Func<MarketIndexPrice, bool>> ParentExpression => x => true;

        protected override IModelCollectionService<MarketIndexPrice> GetModelService() =>
            BuildModelService<MarketIndexPriceBatchService>();

    }
}
