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
    public partial class AccountCustodianServiceTest
    {

    }

    /// <inheritdoc/>
    public partial class AccountCustodianServiceTest : ModelServiceBaseTest<AccountCustodian>
    {
        /// <inheritdoc/>
        protected override AccountCustodian CreateModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelFailSample => throw new NotImplementedException();
        
        /// <inheritdoc/>
        protected override AccountCustodian UpdateModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override IModelService<AccountCustodian> GetModelService()
        {
            throw new NotImplementedException();
        }
    }
}
