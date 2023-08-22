using AutoMapper;
using Castle.DynamicProxy;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
                // Arrange
                var entity = new ModelAttribute()
                {
                    AttributeId = 1,
                    DisplayName = "Attribute"
                };

                // Act
                var dto = Mapper.Map<ModelAttributeDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(ModelAttributeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AttributeId, dto.AttributeId);
                Assert.AreEqual(entity.DisplayName, dto.DisplayName);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ModelAttributeDto()
                {
                    AttributeId = 1,
                    DisplayName = "Attribute"
                };

                // Act
                var entity = Mapper.Map<ModelAttribute>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(ModelAttribute));

                // Fact: All property values match.
                Assert.AreEqual(dto.AttributeId, entity.AttributeId);
                Assert.AreEqual(dto.DisplayName, entity.DisplayName);
            }

            /// <summary>
            /// Verify a DTO instance mapped from an entity instance has all built-in mapped
            /// properties equal to the source. Complex members and collections of complex members are
            /// ignored.
            /// </summary>
            [TestMethod]
            public void DtoForEdit_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new ModelAttribute()
                {
                    AttributeId = 1,
                    DisplayName = "Attribute",
                    ModelAttributeMembers = new List<ModelAttributeMember>()
                    {
                        new()
                        {
                            AttributeId = 1,
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute"
                            },
                            AttributeMemberId = 1,
                            DisplayName = "Attribute value 1",
                            DisplayOrder = 1
                        },
                        new()
                        {
                            AttributeId = 1,
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute"
                            },
                            AttributeMemberId = 2,
                            DisplayName = "Attribute value 2",
                            DisplayOrder = 2
                        }
                    },
                    ModelAttributeScopes = new List<ModelAttributeScope>()
                    {
                        new()
                        {
                            AttributeId = 1,
                            ScopeCode = "sec"
                        },
                        new()
                        {
                            AttributeId = 1,
                            ScopeCode = "cou"
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<ModelAttributeDtoForEdit>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(ModelAttributeDto));

                // Fact: AttributeValues property is non-empty collection with count matching source.
                Assert.IsTrue(dto.AttributeValues.Count > 0);
                Assert.AreEqual(
                    expected: entity.ModelAttributeMembers.Count,
                    actual: dto.AttributeValues.Count);

                // Fact: All attribute members have Attribute complex property defined.
                Assert.IsTrue(dto.AttributeValues.All(x => x.Attribute is not null));

                // Fact: AttributeScopes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.AttributeScopes.Count > 0);
                Assert.AreEqual(
                    expected: entity.ModelAttributeScopes.Count,
                    actual: dto.AttributeScopes.Count);

                // Fact: All property values match.
                Assert.AreEqual(entity.AttributeId, dto.AttributeId);
                Assert.AreEqual(entity.DisplayName, dto.DisplayName);
            }

            /// <summary>
            /// Verify an entity instance mapped from a DTO instance has all mapped properties equal 
            /// to the source.
            /// </summary>
            [TestMethod]
            public void Entity_MapFrom_DtoForEdit_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ModelAttributeDtoForEdit()
                {
                    AttributeId = 1,
                    DisplayName = "Attribute",
                    AttributeValues = new List<ModelAttributeMemberDto>()
                    {
                        new()
                        {
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute"
                            },
                            AttributeMemberId = 1,
                            DisplayName = "Attribute value 1",
                            DisplayOrder = 1
                        },
                        new()
                        {
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute"
                            },
                            AttributeMemberId = 2,
                            DisplayName = "Attribute value 2",
                            DisplayOrder = 2
                        }
                    },
                    AttributeScopes = new List<ModelAttributeScopeDto>()
                    {
                        new()
                        {
                            AttributeId = 1,
                            ScopeCode = "sec"
                        },
                        new()
                        {
                            AttributeId = 1,
                            ScopeCode = "cou"
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<ModelAttribute>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(ModelAttribute));

                // Fact: AttributeValues property is non-empty collection with count matching source.
                Assert.IsTrue(entity.ModelAttributeMembers.Count > 0);
                Assert.AreEqual(
                    expected: dto.AttributeValues.Count,
                    actual: entity.ModelAttributeMembers.Count);

                // Fact: AttributeScopes property is non-empty collection with count matching source.
                Assert.IsTrue(entity.ModelAttributeScopes.Count > 0);
                Assert.AreEqual(
                    expected: dto.AttributeScopes.Count,
                    actual: entity.ModelAttributeScopes.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.AttributeId, entity.AttributeId);
                Assert.AreEqual(dto.DisplayName, entity.DisplayName);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class ModelAttributeMemberMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ModelAttributeMemberMapping"/> class.
            /// </summary>
            public ModelAttributeMemberMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new ModelAttributeMember()
                {
                    AttributeId = 1,
                    AttributeMemberId = 1,
                    DisplayName = "Attribute value",
                    DisplayOrder = 0,
                    Attribute = new()
                    {
                        AttributeId = 1,
                        DisplayName = "Attribute"
                    }
                };

                // Act
                var dto = Mapper.Map<ModelAttributeMemberDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(ModelAttributeMemberDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AttributeId, dto.Attribute.AttributeId);
                Assert.AreEqual(entity.AttributeMemberId, dto.AttributeMemberId);
                Assert.AreEqual(entity.DisplayName, dto.DisplayName);
                Assert.AreEqual(entity.DisplayOrder, dto.DisplayOrder);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ModelAttributeMemberDto()
                {
                    AttributeMemberId = 1,
                    DisplayName = "Attribute value",
                    DisplayOrder = 0,
                    Attribute = new()
                    {
                        AttributeId = 1,
                        DisplayName = "Attribute"
                    }
                };

                // Act
                var entity = Mapper.Map<ModelAttributeMember>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(ModelAttributeMember));

                // Fact: All property values match.
                Assert.AreEqual(dto.Attribute.AttributeId, entity.AttributeId);
                Assert.AreEqual(dto.AttributeMemberId, entity.AttributeMemberId);
                Assert.AreEqual(dto.DisplayName, entity.DisplayName);
                Assert.AreEqual(dto.DisplayOrder, entity.DisplayOrder);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class ModelAttributeScopeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ModelAttributeScopeMapping"/> class.
            /// </summary>
            public ModelAttributeScopeMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new ModelAttributeScope()
                {
                    AttributeId = 1,
                    ScopeCode = "acc"
                };

                // Act
                var dto = Mapper.Map<ModelAttributeScopeDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(ModelAttributeScopeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AttributeId, dto.AttributeId);
                Assert.AreEqual(entity.ScopeCode, dto.ScopeCode);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ModelAttributeScopeDto()
                {
                    AttributeId = 1,
                    ScopeCode = "acc"
                };

                // Act
                var entity = Mapper.Map<ModelAttributeScope>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(ModelAttributeScope));

                // Fact: All property values match.
                Assert.AreEqual(dto.AttributeId, entity.AttributeId);
                Assert.AreEqual(dto.ScopeCode, entity.ScopeCode);
            }
        }
    }
}
