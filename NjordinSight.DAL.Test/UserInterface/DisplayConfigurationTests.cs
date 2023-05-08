using NjordinSight.EntityModel;
using NjordinSight.UserInterface;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NjordinSight.Test.UserInterface
{
    [TestClass]
    public class DisplayConfigurationTests
    {
        [TestMethod]
        public void DisplayConfiguration_Serialize_YieldString()
        {
            var displayConfig = CreateDefaultDisplayConfiguration();

            var displayConfigJson = JsonConvert.SerializeObject(displayConfig, Formatting.Indented);

            Assert.IsInstanceOfType(displayConfigJson, typeof(string));
        }

        [TestMethod]
        public void DisplayConfiguration_Deserialize_YieldsInstance()
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
