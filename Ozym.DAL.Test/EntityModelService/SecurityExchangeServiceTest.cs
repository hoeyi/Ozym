using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ozym.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public partial class SecurityExchangeServiceTest : ModelCollectionServiceTest<SecurityExchange>
    {
        /// <inheritdoc/>
        protected override Expression<Func<SecurityExchange, bool>> ParentExpression => x => true;

        /// <inheritdoc/>
        protected override IModelCollectionService<SecurityExchange> GetModelService() =>
            BuildModelService<SecurityExchangeService>();
    }
}
