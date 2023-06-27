using AutoMapper;
using NjordinSight.DataTransfer.Profiles;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class ReportStyleSheetProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_WithProfileDependencies_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ReportStyleSheetProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}