using AutoMapper;
using NjordinSight.DataTransfer.Profiles;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="ModelAttributeProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class ModelAttributeProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
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

    public partial class ModelAttributeProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class ModelAttributeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ModelAttributeMapping"/> class.
            /// </summary>
            public ModelAttributeMapping() : base(new Mapper(TestConfiguration))
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
