﻿using AutoMapper;
using NjordinSight.DataTransfer.Profiles;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class ModelAttributeProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_WithProfileDependencies_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
