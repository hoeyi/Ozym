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
    public class AccountAttributeMemberServiceTest 
        : ModelBatchServiceTest<AccountAttributeMemberEntry>
    {
        private const int _accountObjectId = -3;

        protected override Expression<Func<AccountAttributeMemberEntry, bool>> ParentExpression =>
            x => x.AccountObjectId == _accountObjectId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Weight = model.Weight * 0.5M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<AccountAttributeMemberEntry> GetModelService() =>
            BuildModelService<AccountAttributeMemberService>().WithParent(parentId: _accountObjectId);
    }
}
