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
    /// Class for unit test methods targeting <see cref="SecurityProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityProfileTest : IProfileTest
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
                var entity = new Security()
                {
                    SecurityId = 100,
                    SecurityTypeId = 10,
                    SecurityExchangeId = 1,
                    SecurityDescription = "SECURITY_DESCRIPTION",
                    Issuer = "ISSUER",
                    HasPerpetualMarket = true,
                    HasPerpetualPrice = true,
                    SecurityAttributeMemberEntries = new List<SecurityAttributeMemberEntry>()
                    {
                        new()
                        {
                            SecurityId = 100,
                            AttributeMemberId = 90,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 90,
                                DisplayName = "Member 1",
                                DisplayOrder = 1,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 1"
                                }
                            },
                            EffectiveDate = DateTime.UtcNow.Date,
                            Weight = 1M
                        }
                    },
                    SecuritySymbols = new List<SecuritySymbol>()
                    {
                        new()
                        {
                            SymbolId = 10,
                            SecurityId = 100,
                            EffectiveDate = DateTime.UtcNow.Date,
                            SymbolTypeId = -40,
                            Ticker = "TICKER",
                            OptionTicker = "OPTION_TICKER",
                            CustomSymbol = "CUSTOM_SYMBOL",
                            Cusip = "CUSIP"
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<SecurityDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(SecurityDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Attributes.Count > 0);
                Assert.AreEqual(
                    expected: entity.SecurityAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));
                
                // Fact: Symbols property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Symbols.Count > 0);
                Assert.AreEqual(
                    expected: entity.SecuritySymbols.Count,
                    actual: dto.Symbols.Count);

                // Fact: All property values match.
                Assert.AreEqual(entity.SecurityId, dto.SecurityId);
                Assert.AreEqual(entity.SecurityTypeId, dto.SecurityTypeId);
                Assert.AreEqual(entity.SecurityExchangeId, dto.SecurityExchangeId);
                Assert.AreEqual(entity.SecurityDescription, dto.SecurityDescription);
                Assert.AreEqual(entity.Issuer, dto.Issuer);
                Assert.AreEqual(entity.HasPerpetualMarket, dto.HasPerpetualMarket);
                Assert.AreEqual(entity.HasPerpetualPrice, dto.HasPerpetualPrice);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecurityDto()
                {
                    SecurityId = 100,
                    SecurityTypeId = 10,
                    SecurityExchangeId = 1,
                    SecurityDescription = "SECURITY_DESCRIPTION",
                    Issuer = "ISSUER",
                    HasPerpetualMarket = true,
                    HasPerpetualPrice = true,
                    Attributes = new List<SecurityAttributeDto>()
                    {
                        new()
                        {
                            SecurityId = 100,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 90,
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
                    },
                    Symbols = new List<SecuritySymbolDto>()
                    {
                        new()
                        {
                            SymbolId = 10,
                            SecurityId = 100,
                            EffectiveDate = DateTime.UtcNow.Date,
                            SymbolTypeId = -40,
                            Ticker = "TICKER",
                            OptionTicker = "OPTION_TICKER",
                            CustomSymbol = "CUSTOM_SYMBOL",
                            Cusip = "CUSIP"
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<Security>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(Security));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(entity.SecurityAttributeMemberEntries.Count > 0);
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.SecurityAttributeMemberEntries.Count);

                // Fact: Symbols property is non-empty collection with count matching source.
                Assert.IsTrue(entity.SecuritySymbols.Count > 0);
                Assert.AreEqual(
                    expected: dto.Symbols.Count,
                    actual: entity.SecuritySymbols.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.SecurityId, entity.SecurityId);
                Assert.AreEqual(dto.SecurityTypeId, entity.SecurityTypeId);
                Assert.AreEqual(dto.SecurityExchangeId, entity.SecurityExchangeId);
                Assert.AreEqual(dto.SecurityDescription, entity.SecurityDescription);
                Assert.AreEqual(dto.Issuer, entity.Issuer);
                Assert.AreEqual(dto.HasPerpetualMarket, entity.HasPerpetualMarket);
                Assert.AreEqual(dto.HasPerpetualPrice, entity.HasPerpetualPrice);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class AttributeEntryMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AttributeEntryMapping"/> class.
            /// </summary>
            public AttributeEntryMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecurityAttributeMemberEntry()
                {
                    SecurityId = 10,
                    AttributeMemberId = 20,
                    EffectiveDate = DateTime.UtcNow.Date,
                    Weight = 1M,
                    AttributeMember = new()
                    {
                        Attribute = new()
                        {
                            AttributeId = 1,
                            DisplayName = "Attribute"
                        },
                        AttributeId = 10,
                        AttributeMemberId = 20,
                        DisplayName = "Attribute value",
                        DisplayOrder = 1
                    }
                };

                // Act
                var dto = Mapper.Map<SecurityAttributeDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecurityAttributeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SecurityId, dto.SecurityId);
                Assert.AreEqual(entity.AttributeMemberId, dto.AttributeMember.AttributeMemberId);
                Assert.AreEqual(entity.EffectiveDate, dto.EffectiveDate);
                Assert.AreEqual(entity.Weight, dto.PercentWeight);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecurityAttributeDto()
                {
                    SecurityId = 1,
                    EffectiveDate = DateTime.UtcNow.Date,
                    PercentWeight = 1M,
                    AttributeMemberId = 20,
                    AttributeMember = new()
                    {
                        Attribute = new()
                        {
                            AttributeId = 1,
                            DisplayName = "Attribute"
                        },
                        AttributeMemberId = 20,
                        DisplayName = "Attribute value",
                        DisplayOrder = 1
                    }
                };

                // Act
                var entity = Mapper.Map<SecurityAttributeMemberEntry>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecurityAttributeMemberEntry));

                // Fact: All property values match.
                Assert.AreEqual(dto.SecurityId, entity.SecurityId);
                Assert.AreEqual(dto.AttributeMember.AttributeMemberId, entity.AttributeMemberId);
                Assert.AreEqual(dto.EffectiveDate, entity.EffectiveDate);
                Assert.AreEqual(dto.PercentWeight, entity.Weight);
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
                var entity = new SecuritySymbol()
                {
                    SymbolId = 10,
                    SecurityId = 1,
                    EffectiveDate = DateTime.UtcNow.Date,
                    SymbolTypeId = -40,
                    Ticker = "TICKER",
                    OptionTicker = "OPTION_TICKER",
                    CustomSymbol = "CUSTOM_SYMBOL",
                    Cusip = "CUSIP"
                };

                // Act
                var dto = Mapper.Map<SecuritySymbolDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecuritySymbolDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SymbolId, dto.SymbolId);
                Assert.AreEqual(entity.SecurityId, dto.SecurityId);
                Assert.AreEqual(entity.EffectiveDate, dto.EffectiveDate);
                Assert.AreEqual(entity.SymbolTypeId, dto.SymbolTypeId);
                Assert.AreEqual(entity.Ticker, dto.Ticker);
                Assert.AreEqual(entity.OptionTicker, dto.OptionTicker);
                Assert.AreEqual(entity.CustomSymbol, dto.CustomSymbol);
                Assert.AreEqual(entity.Cusip, dto.Cusip);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto1 = new SecuritySymbolDto()
                {
                    SymbolId = 10,
                    SecurityId = 1,
                    EffectiveDate = DateTime.UtcNow.Date,
                    SymbolTypeId = -40,
                    Symbol = "TICKER",
                    Ticker = "TICKER",
                    OptionTicker = "OPTION_TICKER",
                    CustomSymbol = "CUSTOM_SYMBOL",
                    Cusip = "CUSIP"
                };

                // Act
                var entity = Mapper.Map<SecuritySymbol>(dto1);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecuritySymbol));

                // Fact: SymbolCode computed property is not mapped from the DTO.
                Assert.IsTrue(string.IsNullOrEmpty(entity.SymbolCode));

                // Fact: All property values match.
                Assert.AreEqual(dto1.SymbolId, entity.SymbolId);
                Assert.AreEqual(dto1.SecurityId, entity.SecurityId);
                Assert.AreEqual(dto1.EffectiveDate, entity.EffectiveDate);
                Assert.AreEqual(dto1.SymbolTypeId, entity.SymbolTypeId);
                Assert.AreEqual(dto1.Ticker, entity.Ticker);
                Assert.AreEqual(dto1.OptionTicker, entity.OptionTicker);
                Assert.AreEqual(dto1.CustomSymbol, entity.CustomSymbol);
                Assert.AreEqual(dto1.Cusip, entity.Cusip);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class SymbolTypeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SymbolTypeMapping"/> class.
            /// </summary>
            public SymbolTypeMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecuritySymbolType()
                {
                    SymbolTypeId = 1,
                    SymbolTypeName = "Symbol Type"
                };

                // Act
                var dto = Mapper.Map<SecuritySymbolTypeDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecuritySymbolTypeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SymbolTypeId, dto.SymbolTypeId);
                Assert.AreEqual(entity.SymbolTypeName, dto.SymbolTypeName);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecuritySymbolTypeDto()
                {
                    SymbolTypeId = 1,
                    SymbolTypeName = "Symbol Type"
                };

                // Act
                var entity = Mapper.Map<SecuritySymbolType>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecuritySymbolType));

                // Fact: All property values match.
                Assert.AreEqual(dto.SymbolTypeId, entity.SymbolTypeId);
                Assert.AreEqual(dto.SymbolTypeName, entity.SymbolTypeName);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class SymbolMapMapping: MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SymbolMapMapping"/> class.
            /// </summary>
            public SymbolMapMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecuritySymbolMap()
                {
                    SymbolMapId = 1,
                    SecuritySymbolId = 10,
                    CustodianSymbol = "CUSTODIAN_SYMBOL"
                };

                // Act
                var dto = Mapper.Map<SecuritySymbolMapDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecuritySymbolMapDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SymbolMapId, dto.SymbolMapId);
                Assert.AreEqual(entity.SecuritySymbolId, dto.SecuritySymbolId);
                Assert.AreEqual(entity.CustodianSymbol, dto.CustodianSymbol);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecuritySymbolMapDto()
                {
                    SymbolMapId = 1,
                    SecuritySymbolId = 10,
                    CustodianSymbol = "CUSTODIAN_SYMBOL"
                };

                // Act
                var entity = Mapper.Map<SecuritySymbolMap>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecuritySymbolMap));

                // Fact: All property values match.
                Assert.AreEqual(dto.SymbolMapId, entity.SymbolMapId);
                Assert.AreEqual(dto.SecuritySymbolId, entity.SecuritySymbolId);
                Assert.AreEqual(dto.CustodianSymbol, entity.CustodianSymbol);
            }
        }
    }
}
