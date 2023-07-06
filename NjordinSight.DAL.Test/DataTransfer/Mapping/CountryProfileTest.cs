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
    /// Class for unit test methods targeting <see cref="CountryProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class CountryProfileTest : IProfileTest, IProfileWithDependencyTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<CountryProfile>();
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
                x.AddProfile<CountryProfile>();
            });

            // Act

            // Assert
            Assert.ThrowsException<AutoMapperConfigurationException>(() =>
                config.AssertConfigurationIsValid());
        }

    }

    public partial class CountryProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class CountryMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CountryMapping"/> class.
            /// </summary>
            public CountryMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new Country()
                {
                    CountryId = 1,
                    DisplayName = "United States",
                    IsoCode3 = "USA",
                    AttributeMemberNavigation = new()
                    {
                        AttributeMemberId = 1,
                        DisplayName = "UnitedStates",
                        DisplayOrder = 1
                    },
                    CountryAttributeMemberEntries = new List<CountryAttributeMemberEntry>()
                    {
                        new()
                        {
                            AttributeMemberId = 1,
                            CountryId = 1,
                            EffectiveDate = new DateTime(2022, 12, 31),
                            Weight = 1M,
                            AttributeMember = new()
                            {
                                
                                AttributeMemberId = 1,
                                AttributeId = 1,
                                DisplayName = "Member 1",
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 1"
                                }
                            }
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<CountryDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(CountryDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.AreEqual(
                    expected: entity.CountryAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.CountryId, dto.CountryId),
                    () => Assert.AreEqual(entity.IsoCode3, dto.IsoCode3),
                    () => Assert.AreEqual(entity.DisplayName, dto.DisplayName),
                    () => Assert.AreEqual(entity.AttributeMemberNavigation.DisplayOrder, dto.DisplayOrder)
                };

                assertions.ForEach(x => x.Invoke());
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new CountryDto()
                {
                    CountryId = 1,
                    DisplayName = "United States",
                    DisplayOrder = 0,
                    Attributes = new List<CountryAttributeDto>()
                    {
                        new()
                        {
                            CountryId = 1,
                            AttributeMember = new()
                            {
                                DisplayName = "Member 1",
                                DisplayOrder = 1,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 1"
                                }
                            },
                            EffectiveDate = DateTime.UtcNow.Date,
                            PercentWeight = 1M
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<Country>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(Country));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.CountryAttributeMemberEntries.Count);

                // Fact: All property values match.
                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(dto.CountryId, entity.CountryId),
                    () => Assert.AreEqual(dto.IsoCode3, entity.IsoCode3),
                    () => Assert.AreEqual(dto.DisplayName, entity.DisplayName),
                    () => Assert.AreEqual(dto.DisplayOrder, entity.AttributeMemberNavigation.DisplayOrder)
                };

                assertions.ForEach(x => x.Invoke());
            }
        }
    }
}
