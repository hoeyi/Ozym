using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="InvestmentPerformanceProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class InvestmentPeformanceProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<InvestmentPerformanceProfile>();
            });

        /// <inheritdoc/>
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = TestConfiguration;

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
