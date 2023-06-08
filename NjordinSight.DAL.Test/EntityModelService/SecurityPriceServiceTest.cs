using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class SecurityPriceServiceTest
        : ModelCollectionServiceTest<SecurityPrice>
    {

        protected override Expression<Func<SecurityPrice, bool>> ParentExpression =>
            x => true;

        // TODO: Finish writing this test.
        public override Task Update_PendingSave_HasChanges_IsFalse()
        {
            return Task.CompletedTask;
        }

        protected override IModelCollectionService<SecurityPrice> GetModelService() =>
            BuildModelService<SecurityPriceBatchService>();

    }
}
