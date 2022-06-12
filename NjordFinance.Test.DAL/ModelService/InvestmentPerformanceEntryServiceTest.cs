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
    public class InvestmentPerformanceEntryServiceTest 
        : ModelBatchServiceTest<InvestmentPerformanceEntry>
    {
        private const int _accountObjectId = -8;
        protected override Expression<Func<InvestmentPerformanceEntry, bool>> ParentExpression =>
               x => x.AccountObjectId == _accountObjectId;

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.AverageCapital *= 1.37M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<InvestmentPerformanceEntry> GetModelService() =>
            BuildModelService<InvestmentPerformanceEntryService>().WithParent(_accountObjectId);
    }
}
