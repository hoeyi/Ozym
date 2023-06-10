using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class MarketHolidayObservanceServiceTest
        : ModelCollectionServiceTest<MarketHolidayObservance>
    {
        protected override Expression<Func<MarketHolidayObservance, bool>> ParentExpression =>
            x => true;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="Update_PendingSave_HasChanges_IsFalse"/> the 
        /// <see cref="MarketHolidayObservance"/> entity does not have updatable members.</remarks>
        [TestMethod]
        public override Task Update_PendingSave_HasChanges_IsFalse()
        {
            return Task.CompletedTask;
        }

        protected override IModelCollectionService<MarketHolidayObservance> GetModelService() =>
            BuildModelService<MarketHolidayObservanceService>();

    }
}
