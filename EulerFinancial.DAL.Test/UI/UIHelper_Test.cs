using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EulerFinancial.UI;
using EulerFinancial.Model;

namespace EulerFinancial.Test.UI
{
    [TestClass]
    public class UIHelper_Test
    {
        [TestMethod]
        public void GetAccountMetadata_YieldsExpectedCollection()
        {
            var uiHelper = new UserInterfaceHelper();

            var metadata = uiHelper.GetModelMetadata<Account>();
            var baseMetadata = uiHelper.GetModelMetadata<AccountObject>();

            Assert.IsInstanceOfType(metadata, typeof(IEnumerable<ModelMetadata>));
            Assert.IsInstanceOfType(baseMetadata, typeof(IEnumerable<ModelMetadata>));
        }
    }
}
