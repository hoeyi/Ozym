using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace EulerFinancial.Validation
{
    class XmlValidator : DomainValidator
    {
        private readonly string xmlSchemaResourceName;
        private readonly string xmlSchemaHashSHA256;

        protected XmlValidator(string xmlSchemaResourceName, string xmlSchemaHashSHA256)
            : base()
        {
            this.xmlSchemaResourceName = xmlSchemaResourceName;
            this.xmlSchemaHashSHA256 = xmlSchemaHashSHA256;
        }

        protected bool XmlIsValid(string textXml, out IList<string> errors)
        {
            var validationErrors = new List<string>();
            string xmlSchema;
            try
            {
                xmlSchema = GetXmlSchema();
            }
            catch (ValidationException)
            {
                validationErrors.Add(
                    string.Format(
                        Resources.ExceptionString.Validation_Xml_SchemaMismatch, 
                        xmlSchemaResourceName));

                errors = validationErrors;
                return false;
            }

            try
            {
                if (XmlIsValid(xmlSchema, textXml))
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
                validationErrors.Add(Resources.ExceptionString.Validation_Xml_General);
                
                errors = validationErrors;
                return false;
            }
        }

        private string GetXmlSchema()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(xmlSchemaResourceName);
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            var sha256Hash = GetSHA256Hash(result);
            if (xmlSchemaHashSHA256 == sha256Hash)
            {
                return result;
            }
            else
            {
                throw new ValidationException();
            }

        }

        private static bool XmlIsValid(string xmlSchema, string testXml)
        {
            var xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.Add("", XmlReader.Create(new StringReader(xmlSchema)));

            var xmlDoc = XDocument.Parse(testXml);

            bool errors = false;
            xmlDoc.Validate(xmlSchemaSet, (o, e) =>
            {
                errors = true;
            });

            return !errors;
        }

        private static string GetSHA256Hash(string text)
        {
            using var sha256 = SHA256.Create();
            var sha256Hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            return BitConverter.ToString(sha256Hash).Replace("-", "").ToUpperInvariant(); ;
        }
    }
}
