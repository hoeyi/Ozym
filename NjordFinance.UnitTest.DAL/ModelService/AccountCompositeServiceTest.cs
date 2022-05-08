using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    [TestClass]
    public partial class AccountCompositeServiceTest
    {

    }

    /// <inheritdoc/>
    public partial class AccountCompositeServiceTest : ModelServiceBaseTest<AccountComposite>
    {
        /// <inheritdoc/>
        protected override AccountComposite CreateModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountComposite DeleteModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountComposite DeleteModelFailSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountComposite UpdateModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        public override void CleanUp()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override IModelService<AccountComposite> GetModelService()
        {
            throw new NotImplementedException();
        }
    }
}
