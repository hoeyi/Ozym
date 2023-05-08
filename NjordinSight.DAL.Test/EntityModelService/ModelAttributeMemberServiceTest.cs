using NjordinSight.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class ModelAttributeMemberServiceTest
        : ModelBatchServiceTest<ModelAttributeMember>
    {
        private const int _attributeId = -3;

        protected override Expression<Func<ModelAttributeMember, bool>> ParentExpression =>
            x => x.AttributeId == _attributeId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.DisplayOrder++;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<ModelAttributeMember> GetModelService() =>
            BuildModelService<ModelAttributeMemberService>().WithParent(parentId: _attributeId);
    }
}
