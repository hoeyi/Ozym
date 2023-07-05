using AutoMapper;
using NjordinSight.DataTransfer.Profiles;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="SecurityProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityProfileTest : IProfileTest, IProfileWithDependencyTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<SecurityProfile>();
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
            throw new System.NotImplementedException();
        }
    }

    public partial class SecurityProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class SecurityMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityMapping"/> class.
            /// </summary>
            public SecurityMapping() : base(new Mapper(TestConfiguration))
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

        [TestClass]
        [TestCategory("Unit")]
        public class SecurityAttributeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityAttributeMapping"/> class.
            /// </summary>
            public SecurityAttributeMapping() : base(new Mapper(TestConfiguration))
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

        [TestClass]
        [TestCategory("Unit")]
        public class SecuritySymbolMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecuritySymbolMapping"/> class.
            /// </summary>
            public SecuritySymbolMapping() : base(new Mapper(TestConfiguration))
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

        [TestClass]
        [TestCategory("Unit")]
        public class SecuritySymbolTypeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecuritySymbolTypeMapping"/> class.
            /// </summary>
            public SecuritySymbolTypeMapping() : base(new Mapper(TestConfiguration))
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

        [TestClass]
        [TestCategory("Unit")]
        public class SecuritySymbolMapMapping: MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecuritySymbolMapMapping"/> class.
            /// </summary>
            public SecuritySymbolMapMapping() : base(new Mapper(TestConfiguration))
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
