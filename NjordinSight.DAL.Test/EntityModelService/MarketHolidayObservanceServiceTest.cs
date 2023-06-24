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

        protected override IModelCollectionService<MarketHolidayObservance> GetModelService() =>
            BuildModelService<MarketHolidayObservanceService>();

    }
}
