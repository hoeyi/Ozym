using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class SecuritySymbolServiceTest
        : ModelBatchServiceTest<SecuritySymbol>
    {
        private const int _securityId = -1;
        protected override Expression<Func<SecuritySymbol, bool>> ParentExpression =>
            x => x.SecurityId == _securityId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Ticker = $"{model.Ticker}-u";

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<SecuritySymbol> GetModelService() =>
            BuildModelService<SecuritySymbolService>().WithParent(parentId: _securityId);

    }
}
