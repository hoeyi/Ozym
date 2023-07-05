using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using System;
using System.Threading.Tasks;

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
                throw new System.NotImplementedException();
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}