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
    public partial class AccountCustodianServiceTest : ModelCollectionServiceTest<AccountCustodian>
    {
        /// <inheritdoc/>
        protected override Expression<Func<AccountCustodian, bool>> ParentExpression => x => true;

        /// <inheritdoc/>
        protected override IModelCollectionService<AccountCustodian> GetModelService() =>
            BuildModelService<AccountCustodianService>();
    }
}
