using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class SecurityPriceProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_WithProfileDependencies_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<SecurityPriceProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
