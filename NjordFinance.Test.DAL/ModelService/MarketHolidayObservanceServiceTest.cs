using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq.Expressions;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class MarketHolidayObservanceServiceTest
        : ModelBatchServiceTest<MarketHolidayObservance>
    {
        protected override Expression<Func<MarketHolidayObservance, bool>> ParentExpression =>
            x => true;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="UpdatePendingSave_IsDirty_Is_True"/> the 
        /// <see cref="MarketHolidayObservance"/> entity does not have updatable members.</remarks>
        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            return;
        }

        protected override IModelBatchService<MarketHolidayObservance> GetModelService() =>
            BuildModelService<MarketHolidayObservanceService>();

    }
}
