using NjordFinance.EntityModel;
using System;
using System.Linq.Expressions;

namespace NjordFinance.Test.EntityModelService
{
    [TestClass]
    public class MarketIndexPriceServiceTest
        : ModelBatchServiceTest<MarketIndexPrice>
    {
        private const int _marketIndexId = -4;
        protected override Expression<Func<MarketIndexPrice, bool>> ParentExpression => x => true;

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
