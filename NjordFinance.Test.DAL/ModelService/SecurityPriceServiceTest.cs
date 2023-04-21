using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq.Expressions;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class SecurityPriceServiceTest
        : ModelBatchServiceTest<SecurityPrice>
    {

        protected override Expression<Func<SecurityPrice, bool>> ParentExpression =>
            x => true;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="UpdatePendingSave_IsDirty_Is_True"/> the 
        /// <see cref="SecurityPrice"/> entity does not have updatable members.</remarks>
        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            return;
        }

        protected override IModelBatchService<SecurityPrice> GetModelService() =>
            BuildModelService<SecurityPriceService>();

    }
}
