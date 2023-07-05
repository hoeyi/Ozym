using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using System;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
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