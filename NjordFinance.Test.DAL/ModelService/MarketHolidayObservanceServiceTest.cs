using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
