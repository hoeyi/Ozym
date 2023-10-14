using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace Ozym.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class SecurityPriceServiceTest : ModelCollectionServiceTest<SecurityPrice>
    {

        protected override Expression<Func<SecurityPrice, bool>> ParentExpression =>
            x => true;

        protected override IModelCollectionService<SecurityPrice> GetModelService() =>
            BuildModelService<SecurityPriceService>();

    }
}
