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
    /// Class for unit test methods targeting <see cref="ReportStyleSheetProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class ReportStyleSheetProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ReportStyleSheetProfile>();
            });

        /// <inheritdoc/>
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = TestConfiguration;

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }
    }

    public partial class ReportStyleSheetProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class ReportStyleSheetMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReportStyleSheetMapping"/> class.
            /// </summary>
            public ReportStyleSheetMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new ReportStyleSheet()
                {
                    StyleSheetId = 1,
                    StyleSheetCode = "DEFAULT-THEME",
                    StyleSheetDescription = "Default description",
                    XmlDefinition = "does not need to be valid xml for this test"
                };

                // Act
                var dto = Mapper.Map<ReportStyleSheetDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(ReportStyleSheetDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.StyleSheetId, dto.StyleSheetId);
                Assert.AreEqual(entity.StyleSheetCode, dto.StyleSheetCode);
                Assert.AreEqual(entity.StyleSheetDescription, dto.StyleSheetDescription);
                Assert.AreEqual(entity.XmlDefinition, dto.XmlDefinition);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ReportStyleSheetDto()
                {
                    StyleSheetId = 1,
                    StyleSheetCode = "DEFAULT-THEME",
                    StyleSheetDescription = "Default description",
                    XmlDefinition = "does not need to be valid xml for this test"
                };

                // Act
                var entity = Mapper.Map<ReportStyleSheet>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(ReportStyleSheet));

                // Fact: All property values match.
                Assert.AreEqual(dto.StyleSheetId, entity.StyleSheetId);
                Assert.AreEqual(dto.StyleSheetCode, entity.StyleSheetCode);
                Assert.AreEqual(dto.StyleSheetDescription, entity.StyleSheetDescription);
                Assert.AreEqual(dto.XmlDefinition, entity.XmlDefinition);
            }
        }
    }
}