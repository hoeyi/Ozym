using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerFinancial.Web.Components.Graphics;

namespace EulerFinancial.Test.Web
{
    [TestClass]
    public class SvgHelperTest
    {
        [TestMethod]
        public void ValidPath_ReturnsMarkupString()
        {
            var expected = typeof(MarkupString);
            var observed = new SvgHelper().GetSvg("add");

            Assert.IsInstanceOfType(observed, expected);
        }
    }
}