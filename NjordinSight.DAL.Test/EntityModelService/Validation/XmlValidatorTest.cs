using System.Collections.Generic;
using System.Linq;
using NjordinSight.EntityModel.Validation;
using System.Xml;
using NjordinSight.Configuration;

namespace NjordinSight.Test.EntityModelService.Validation
{
    [TestClass]
    [TestCategory("Unit")]
    public class XmlValidatorTest
    {
        private const string TestXmlSchemaDefitintion = 
            "NjordinSight.EntityModel.Metadata.ReportStyleSheet.xsd";

        private readonly XmlValidator _testValidator = new(TestXmlSchemaDefitintion);

        [TestMethod]
        public void Check_IsValid_ForValidInput_ReturnsTrue()
        {
            string testXml = DefaultConfiguration.Report_StyleSheet;

            Assert.IsTrue(_testValidator.XmlIsValid(testXml, out _));
        }

        [TestMethod]
        public void Check_XmlIsValid_ForInvalidInput_ReturnsFalse()
        {
            // Test setup
            string testXml = DefaultConfiguration.Report_StyleSheet;

            // Load the XML stirng into a document for editing
            XmlDocument document = new();
            document.LoadXml(testXml);

            // add a node so that the document is no longer valid
            
            var styleSheetNode = document.SelectSingleNode("//StyleSheet");
            var fontsNode = document.SelectSingleNode("//Fonts");

            var newNode = document.CreateNode(XmlNodeType.Element, "ExtraNodes", null);

            styleSheetNode.InsertAfter(newNode, fontsNode);

            string invalidXmlString = document.OuterXml;

            // Test assertion
            Assert.IsFalse(_testValidator.XmlIsValid(invalidXmlString, out IEnumerable<string> errors));
            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void Check_XmlIsValid_ForInvalidXml_ThrowsExcpetion()
        {
            string invalidString = "This is not xml.";

            Assert.ThrowsException<XmlException>(() => _testValidator.XmlIsValid(invalidString, out _));
        }
    }
}
