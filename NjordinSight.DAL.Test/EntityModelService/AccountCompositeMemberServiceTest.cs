using Microsoft.Extensions.Logging;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    public class AccountCompositeMemberServiceTest
        : ModelBatchServiceTest<AccountCompositeMember>

    {
        private const int _parentID = -8;

        protected override Expression<Func<AccountCompositeMember, bool>> ParentExpression =>
            x => x.AccountCompositeId == _parentID;

        [TestInitialize]
        public void Initialize()
        {
            TestExpressions.Add(
                nameof(SelectWhereAsync_Returns_Model_ExpectedCollection),
                SelectWhereExpression);
        }

        [TestMethod]
        public override Task ReadAsync_Returns_Single_Model()
        {
            TestUtility.Logger.LogInformation(
                $"{nameof(ReadAsync_Returns_Single_Model)} passed, because base method " +
                $"does not apply.");

            return Task.CompletedTask;
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Comment = $"{model.Comment} - u";

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<AccountCompositeMember> GetModelService()
            => BuildModelService<AccountCompositeMemberService>().WithParent(_parentID);

        private Expression<Func<AccountCompositeMember, bool>> SelectWhereExpression(
            AccountCompositeMember model)
        {
            return x => x.AccountCompositeId == model.AccountCompositeId &&
                    x.AccountId == model.AccountId;
        }
    }
}
