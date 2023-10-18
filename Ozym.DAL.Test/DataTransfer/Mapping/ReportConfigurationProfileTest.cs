using AutoMapper;
using Ozym.DataTransfer.Common;
using Ozym.DataTransfer.Profiles;
using Ozym.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozym.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="ReportConfigurationProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class ReportConfigurationProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ReportConfigurationProfile>();
            });

        /// <summary>
        /// Class for unit test methods targeting <see cref="AccountCustodianProfile"/>.
        /// </summary>
        public void Configuration_IsValid()
        {
            // Arrange
            var config = TestConfiguration;

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }
    }

    public partial class ReportConfigurationProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class ReportConfigurationMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReportConfigurationMapping"/> class.
            /// </summary>
            public ReportConfigurationMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new ReportConfiguration()
                {
                    ConfigurationId = 1,
                    ConfigurationCode = "DEFAULT",
                    ConfigurationDescription = "Default description",
                    XmlDefinition = "does not need to be valid xml for this test"
                };

                // Act
                var dto = Mapper.Map<ReportConfigurationDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(ReportConfigurationDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.ConfigurationId, dto.ConfigurationId);
                Assert.AreEqual(entity.ConfigurationCode, dto.ConfigurationCode);
                Assert.AreEqual(entity.ConfigurationDescription, dto.ConfigurationDescription);
                Assert.AreEqual(entity.XmlDefinition, dto.XmlDefinition);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ReportConfigurationDto()
                {
                    ConfigurationId = 1,
                    ConfigurationCode = "DEFAULT",
                    ConfigurationDescription = "Default description",
                    XmlDefinition = "does not need to be valid xml for this test"
                };

                // Act
                var entity = Mapper.Map<ReportConfiguration>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(ReportConfiguration));

                // Fact: All property values match.
                Assert.AreEqual(dto.ConfigurationId, entity.ConfigurationId);
                Assert.AreEqual(dto.ConfigurationCode, entity.ConfigurationCode);
                Assert.AreEqual(dto.ConfigurationDescription, entity.ConfigurationDescription);
                Assert.AreEqual(dto.XmlDefinition, entity.XmlDefinition);
            }
        }
    }
}