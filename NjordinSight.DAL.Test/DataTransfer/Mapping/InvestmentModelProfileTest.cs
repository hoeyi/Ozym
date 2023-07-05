using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="InvestmentModelProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class InvestmentModelProfileTest : IProfileTest, IProfileWithDependencyTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<InvestmentModelProfile>();
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

        /// <inheritdoc/>
        [TestMethod]
        public void Configuration_WithoutProfileDependencies_IsInvalid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<InvestmentModelProfile>();
            });

            // Act

            // Assert
            Assert.ThrowsException<AutoMapperConfigurationException>(() =>
                config.AssertConfigurationIsValid());
        }
    }

    public partial class InvestmentModelProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class InvestmentModelMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InvestmentModelMapping"/> class.
            /// </summary>
            public InvestmentModelMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange

                // Act

                // Assert
                // Fact: Instance is created 
                // Fact: Attributes property is non-empty collection with count matching source.
                // Fact: All attributes have AttributeMember complex property defined.
                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                // Fact: All property values match.
                throw new System.NotImplementedException();
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange

                // Act

                // Assert
                // Fact: Instance is created.
                // Fact: All property values match.
                throw new System.NotImplementedException();
            }
        }
    }
}
