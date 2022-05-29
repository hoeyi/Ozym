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
    public class CountryAttributeServiceTest : ModelBatchServiceTest<CountryAttributeMemberEntry>
    {
        protected override Expression<Func<CountryAttributeMemberEntry, bool>> ParentExpression => throw new NotImplementedException();

        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            throw new NotImplementedException();
        }

        protected override IModelBatchService<CountryAttributeMemberEntry> GetModelService()
        {
            throw new NotImplementedException();
        }
    }
}
