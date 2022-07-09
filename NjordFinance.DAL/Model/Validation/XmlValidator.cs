using NjordFinance.ModelMetadata.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace NjordFinance.Model.Validation
{
    /// <summary>
    /// Validator class for verifying XML-formatted strings against an XML Schema defintiion.
    /// </summary>
    class XmlValidator : DomainValidator
    {
        private readonly string _xmlSchemaDefinition;

        /// <summary>
        /// Creates a new instance of <see cref="XmlValidator"/> 
        /// </summary>
        /// <param name="xmlSchemaResourceName">The name of the *.xsd resource XML strings are 
        /// checked against.</param>
        /// <param name="xmlSchemaHashSHA256"></param>
        public XmlValidator(string xmlSchemaResourceName) : base()
        {
            _xmlSchemaDefinition = GetXmlSchema(xmlSchemaResourceName);
        }

        /// <summary>
        /// Checks whether given XML-formatted string is valid for the schema of this validator.
        /// </summary>
        /// <param name="textXml">The XML-formatted string to test.</param>
        /// <param name="errors">The collection of error messages created during the check. The 
        /// collection is empty if no errors were found.</param>
        /// <returns>True if the test XML string conforms to the expected schema, else false.</returns>
        public bool XmlIsValid(string textXml, out IEnumerable<string> errors)
        {
            var validationErrors = new List<string>();

            try
            {
                if (XmlIsValid(_xmlSchemaDefinition, textXml))
                {
                    errors = validationErrors;
                    return true;
                }
                else
                {
                    throw new ValidationException();
                }
            }
            catch (ValidationException)
            {
                validationErrors.Add(ModelValidation.Validation_Xml_General);

                errors = validationErrors;
                return false;
            }
        }

        /// <summary>
        /// Gets a string representation of the XML schema definition with the given resource name.
        /// </summary>
        /// <param name="resourceName">The name of the embedded resource.</param>
        /// <returns></returns>
        private static string GetXmlSchema(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            return result;
        }

        /// <summary>
        /// Checks whether given XML-formatted string is valid for the given schema.
        /// </summary>
        /// <param name="xmlSchema">The schema to test against.</param>
        /// <param name="testXml">The XML-formatted string to test.</param>
        /// <returns></returns>
        private static bool XmlIsValid(string xmlSchema, string testXml)
        {
            var xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.Add("", XmlReader.Create(new StringReader(xmlSchema)));

            // Parse the string XML into an XDocument for validation.
            var xmlDoc = XDocument.Parse(testXml);

            bool errors = false;
            xmlDoc.Validate(xmlSchemaSet, (objectParam, args) => { errors = true; });

            return !errors;
        }
    }
}
