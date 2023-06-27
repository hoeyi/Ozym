using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class SecurityPriceServiceTest : ModelCollectionServiceTest<SecurityPrice>
    {

        protected override Expression<Func<SecurityPrice, bool>> ParentExpression =>
            x => true;

        protected override IModelCollectionService<SecurityPrice> GetModelService() =>
            BuildModelService<SecurityPriceBatchService>();

    }
}
