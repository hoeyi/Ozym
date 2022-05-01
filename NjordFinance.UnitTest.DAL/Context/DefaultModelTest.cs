using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Context.Configuration;
using NjordFinance.Model;

namespace NjordFinance.UnitTest.Context
{
    [TestClass]
    public class DefaultModelTest
    {
        [TestMethod]
        public void DefaultModel_SecurityTypeGroups_ReturnsArray()
        {
            IDefaultModel defaultModel = new DefaultModel();

            Assert.IsInstanceOfType(defaultModel.SecurityTypeGroups, typeof(SecurityTypeGroup[]));
        }
    }
}
