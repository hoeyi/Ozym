using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Profiles;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="SecurityTypeProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityTypeProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<SecurityTypeProfile>();
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

    public partial class SecurityTypeProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class SecurityTypeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityTypeMapping"/> class.
            /// </summary>
            public SecurityTypeMapping() : base(new Mapper(TestConfiguration))
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

        [TestClass]
        [TestCategory("Unit")]
        public class SecurityTypeGroupMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityTypeGroupMapping"/> class.
            /// </summary>
            public SecurityTypeGroupMapping() : base(new Mapper(TestConfiguration))
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
