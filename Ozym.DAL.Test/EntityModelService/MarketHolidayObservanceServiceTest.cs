using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace Ozym.Test.EntityModelService
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
