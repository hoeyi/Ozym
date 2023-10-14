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
    /// Class for unit test methods targeting <see cref="InvestmentModelProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class InvestmentModelProfileTest : IProfileTest
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
                var entity = new InvestmentStrategy()
                {
                    InvestmentStrategyId = 1,
                    DisplayName = "Strategy",
                    Notes = "Notes",
                    InvestmentStrategyTargets = new List<InvestmentStrategyTarget>()
                    {
                        new()
                        {
                            InvestmentStrategyId = 1,
                            AttributeMemberId = 1,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 1,
                                DisplayName = "Member 1",
                                DisplayOrder = 1,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 1"
                                },
                            },
                            EffectiveDate = DateTime.UtcNow.Date,
                            Weight = 0.5M
                        },
                        new()
                        {
                            InvestmentStrategyId = 1,
                            AttributeMemberId = 2,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 2,
                                DisplayName = "Member 2",
                                DisplayOrder = 2,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 1"
                                },
                            },
                            EffectiveDate = DateTime.UtcNow.Date,
                            Weight = 0.5M
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<InvestmentModelDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(InvestmentModelDto));

                // Fact: Targets property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Targets.Count > 0);
                Assert.AreEqual(
                    expected: entity.InvestmentStrategyTargets.Count,
                    actual: dto.Targets.Count);

                // Fact: All targets have AttributeMember complex property defined.
                Assert.IsTrue(dto.Targets.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Targets.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.InvestmentStrategyId, dto.InvestmentModelId),
                    () => Assert.AreEqual(entity.DisplayName, dto.DisplayName),
                    () => Assert.AreEqual(entity.Notes, dto.Notes)
                };

                assertions.ForEach(x => x.Invoke());
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new InvestmentModelDto()
                {
                    InvestmentModelId = 1,
                    DisplayName = "Investment model",
                    Notes = "Notes",
                    Targets = new List<InvestmentModelTargetDto>()
                    {
                        new()
                        {
                            InvestmentModelId = 1,
                            AttributeMemberId = 1,
                            EffectiveDate = DateTime.UtcNow.Date,
                            PercentWeight = 0.5M,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 1,
                                DisplayName = "Attribute value 1",
                                DisplayOrder = 1,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute"
                                }
                            }
                        },
                        new()
                        {
                            InvestmentModelId = 1,
                            AttributeMemberId = 2,
                            EffectiveDate = DateTime.UtcNow.Date,
                            PercentWeight = 0.5M,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 2,
                                DisplayName = "Attribute value 2",
                                DisplayOrder = 2,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute"
                                }
                            }
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<InvestmentStrategy>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(InvestmentStrategy));

                // Fact: InvestmentStrategyTargets property is non-empty collection with count matching source.
                Assert.IsTrue(entity.InvestmentStrategyTargets.Count > 0);
                Assert.AreEqual(
                    expected: dto.Targets.Count,
                    actual: entity.InvestmentStrategyTargets.Count);

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(dto.InvestmentModelId, entity.InvestmentStrategyId),
                    () => Assert.AreEqual(dto.DisplayName, entity.DisplayName),
                    () => Assert.AreEqual(dto.Notes, entity.Notes)
                };

                assertions.ForEach(x => x.Invoke());
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class InvestmentModelTargetMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InvestmentModelTargetMapping"/> class.
            /// </summary>
            public InvestmentModelTargetMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new InvestmentStrategyTarget()
                {
                    InvestmentStrategyId = 1,
                    AttributeMemberId = 2,
                    EffectiveDate = DateTime.UtcNow.Date,
                    Weight = 1M,
                    AttributeMember = new()
                    {
                        Attribute = new()
                        {
                            AttributeId = 1,
                            DisplayName = "Attribute"
                        },
                        AttributeId = 1,
                        AttributeMemberId = 2,
                        DisplayName = "Attribute value",
                        DisplayOrder = 1
                    }
                };

                // Act
                var dto = Mapper.Map<InvestmentModelTargetDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(InvestmentModelTargetDto));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.InvestmentStrategyId, dto.InvestmentModelId),
                    () => Assert.AreEqual(entity.AttributeMemberId, dto.AttributeMember.AttributeMemberId),
                    () => Assert.AreEqual(entity.EffectiveDate, dto.EffectiveDate),
                    () => Assert.AreEqual(entity.Weight, dto.PercentWeight)
                };

                assertions.ForEach(x => x.Invoke());
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new InvestmentModelTargetDto()
                {
                    InvestmentModelId = 1,
                    EffectiveDate = DateTime.UtcNow.Date,
                    PercentWeight = 1M,
                    AttributeMemberId = 2,
                    AttributeMember = new()
                    {
                        Attribute = new()
                        {
                            AttributeId = 1,
                            DisplayName = "Attribute"
                        },
                        AttributeMemberId = 2,
                        DisplayName = "Attribute value",
                        DisplayOrder = 1
                    }
                };

                // Act
                var entity = Mapper.Map<InvestmentStrategyTarget>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(InvestmentStrategyTarget));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(dto.InvestmentModelId, entity.InvestmentStrategyId),
                    () => Assert.AreEqual(dto.AttributeMember.AttributeMemberId, entity.AttributeMemberId),
                    () => Assert.AreEqual(dto.EffectiveDate, entity.EffectiveDate),
                    () => Assert.AreEqual(dto.PercentWeight, entity.Weight)
                };

                assertions.ForEach(x => x.Invoke());
            }
        }
    }
}
