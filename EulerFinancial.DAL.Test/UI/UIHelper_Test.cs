using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EulerFinancial.UI;
using EulerFinancial.Model;
using Newtonsoft.Json;

namespace EulerFinancial.Test.UI
{
    [TestClass]
    public class UIHelper_Test
    {
        //[TestMethod]
        //public void GetAccountMetadata_YieldsExpectedCollection()
        //{
        //    var metadata = uiHelper.GetModelMemberMetadata<Account>();
        //    var baseMetadata = uiHelper.GetModelMemberMetadata<AccountObject>();

        //    Assert.IsInstanceOfType(metadata, typeof(IEnumerable<ModelMemberMetadata>));
        //    Assert.IsInstanceOfType(baseMetadata, typeof(IEnumerable<ModelMemberMetadata>));
        //}

        [TestMethod]
        public void DisplayConfigurationSerialize_YieldString()
        {
            var displayConfig = CreateDefaultDisplayConfiguration();

            var displayConfigJson = JsonConvert.SerializeObject(displayConfig, Formatting.Indented);

            Assert.IsInstanceOfType(displayConfigJson, typeof(string));
        }

        [TestMethod]
        public void DisplayConfigurationDeserialize_YieldsInstance()
        {
            var displayConfigJson = GetDefaultDisplayConfigurationJson();

            var displayConfig = JsonConvert.DeserializeObject<DisplayConfiguration>(displayConfigJson);

            Assert.IsInstanceOfType(displayConfig, typeof(DisplayConfiguration));
        }

        private static DisplayConfiguration CreateDefaultDisplayConfiguration()
        {
            var displayConfig = new DisplayConfiguration
            {
                Name = $"Display.{nameof(Account)}",
                ApplicableTo = typeof(Account),
                DisplayOrder = new Dictionary<string, int>()
                {
                    { $"{nameof(AccountObject)}.{nameof(AccountObject.AccountObjectCode)}", 0 },
                    { $"{nameof(AccountObject)}.{nameof(AccountObject.StartDate)}", 1 },
                    { $"{nameof(AccountObject)}.{nameof(AccountObject.CloseDate)}", 2 }
                }
            };

            return displayConfig;
        }

        private static string GetDefaultDisplayConfigurationJson()
        {
            var displayConfig = CreateDefaultDisplayConfiguration();

            return JsonConvert.SerializeObject(displayConfig);
        }
    }
}
