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
    /// Class for unit test methods targeting <see cref="AccountProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class AccountProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            });

        /// <inheritdoc/>
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = TestConfiguration;

            // Assert
            config.AssertConfigurationIsValid();
        }
    }

    public partial class AccountProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class AccountMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountMapping"/> class.
            /// </summary>
            public AccountMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new Account()
                {
                    AccountId = 1,
                    AccountNumber = "####-####-####",
                    HasBankTransaction = true,
                    HasBrokerTransaction = true,
                    AccountCustodianId = 1,
                    AccountNavigation = new()
                    {
                        AccountObjectId = 1,
                        AccountObjectCode = "TEST",
                        ObjectDescription = "For testing purposes.",
                        ObjectType = "a",
                        ObjectDisplayName = "Test Account",
                        StartDate = DateTime.UtcNow.Date,
                        AccountAttributeMemberEntries = new List<AccountAttributeMemberEntry>()
                        {
                            new()
                            {
                                AccountObjectId = 1,
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
                                    }
                                },
                                EffectiveDate = DateTime.UtcNow.Date,
                                Weight = 1M
                            }
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<AccountDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(AccountDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Attributes.Count > 0);
                Assert.AreEqual(
                    expected: entity.AccountNavigation.AccountAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountNavigation.AccountObjectId, dto.Id);
                Assert.AreEqual(entity.AccountNavigation.AccountObjectCode, dto.ShortCode);
                Assert.AreEqual(entity.AccountNavigation.StartDate, dto.StartDate);
                Assert.AreEqual(entity.AccountNavigation.CloseDate, dto.CloseDate);
                Assert.AreEqual(entity.AccountNavigation.ObjectDisplayName, dto.DisplayName);
                Assert.AreEqual(entity.AccountNavigation.ObjectDescription, dto.Description);
                Assert.AreEqual(entity.AccountNavigation.ObjectType, dto.ObjectType);
                Assert.AreEqual(entity.AccountCustodianId, dto.AccountCustodianId);
                Assert.AreEqual(entity.AccountNumber, dto.AccountNumber);
                Assert.AreEqual(entity.HasWallet, dto.HasWallet);
                Assert.AreEqual(entity.HasBankTransaction, dto.HasBankTransaction);
                Assert.AreEqual(entity.HasBrokerTransaction, dto.HasBrokerTransaction);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new AccountDto()
                {
                    Id = 1,
                    AccountNumber = "####-####-####",
                    HasBankTransaction = true,
                    HasBrokerTransaction = true,
                    AccountCustodianId = 1,
                    ShortCode = "TEST",
                    Description = "For testing purposes.",
                    DisplayName = "Test Account",
                    StartDate = DateTime.UtcNow.Date,
                    Attributes = new List<AccountBaseAttributeDto>()
                    {
                        new()
                        {
                            AccountObjectId = 1,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 1,
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
                        },
                    }
                };

                // Act
                var entity = Mapper.Map<Account>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(Account));

                // Fact: AccountAttributeMemberEntries property is non-empty collection with
                // count matching source.
                Assert.IsTrue(entity.AccountNavigation.AccountAttributeMemberEntries.Count > 0);
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.AccountNavigation.AccountAttributeMemberEntries.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.Id, entity.AccountNavigation.AccountObjectId);
                Assert.AreEqual(dto.ShortCode, entity.AccountNavigation.AccountObjectCode);
                Assert.AreEqual(dto.StartDate, entity.AccountNavigation.StartDate);
                Assert.AreEqual(dto.CloseDate, entity.AccountNavigation.CloseDate);
                Assert.AreEqual(dto.DisplayName, entity.AccountNavigation.ObjectDisplayName);
                Assert.AreEqual(dto.Description, entity.AccountNavigation.ObjectDescription);
                Assert.AreEqual(dto.ObjectType, entity.AccountNavigation.ObjectType);
                Assert.AreEqual(dto.AccountCustodianId, entity.AccountCustodianId);
                Assert.AreEqual(dto.AccountNumber, entity.AccountNumber);
                Assert.AreEqual(dto.HasWallet, entity.HasWallet);
                Assert.AreEqual(dto.HasBankTransaction, entity.HasBankTransaction);
                Assert.AreEqual(dto.HasBrokerTransaction, entity.HasBrokerTransaction);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class AccountCompositeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountCompositeMapping"/> class.
            /// </summary>
            public AccountCompositeMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new AccountComposite()
                {
                    AccountCompositeId = 1,
                    AccountCompositeNavigation = new()
                    {
                        AccountObjectId = 1,
                        AccountObjectCode = "TEST",
                        ObjectDescription = "For testing purposes.",
                        ObjectType = "c",
                        ObjectDisplayName = "Test Account",
                        StartDate = DateTime.UtcNow.Date,
                        AccountAttributeMemberEntries = new List<AccountAttributeMemberEntry>()
                        {
                            new()
                            {
                                AccountObjectId = 1,
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
                                    }
                                },
                                EffectiveDate = DateTime.UtcNow.Date,
                                Weight = 1M
                            }
                        }
                    },
                    AccountCompositeMembers = new List<AccountCompositeMember>()
                    {
                        new()
                        {
                            AccountCompositeId = 1,
                            AccountId = 2,
                            EntryDate = DateTime.UtcNow.Date
                        }
                    }
                };

                // Act
                var dto = Mapper.Map<AccountCompositeDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(AccountCompositeDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Attributes.Count > 0);
                Assert.AreEqual(
                    expected: entity.AccountCompositeNavigation.AccountAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: AccountMembers property is non-empty collection with count matching source.
                Assert.IsTrue(dto.AccountMembers.Count > 0);
                Assert.AreEqual(
                    expected: dto.AccountMembers.Count,
                    actual: entity.AccountCompositeMembers.Count);

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountCompositeNavigation.AccountObjectId, dto.Id);
                Assert.AreEqual(entity.AccountCompositeNavigation.AccountObjectCode, dto.ShortCode);
                Assert.AreEqual(entity.AccountCompositeNavigation.StartDate, dto.StartDate);
                Assert.AreEqual(entity.AccountCompositeNavigation.CloseDate, dto.CloseDate);
                Assert.AreEqual(entity.AccountCompositeNavigation.ObjectDisplayName, dto.DisplayName);
                Assert.AreEqual(entity.AccountCompositeNavigation.ObjectDescription, dto.Description);
                Assert.AreEqual(entity.AccountCompositeNavigation.ObjectType, dto.ObjectType);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new AccountCompositeDto()
                {
                    Id = 1,
                    ShortCode = "TEST",
                    Description = "For testing purposes.",
                    DisplayName = "Test Account",
                    StartDate = DateTime.UtcNow.Date,
                    Attributes = new List<AccountBaseAttributeDto>()
                    {
                        new()
                        {
                            AccountObjectId = 1,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 1,
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
                        },
                    },
                    AccountMembers = new List<AccountCompositeMemberDto>()
                    {
                        new()
                        {
                            AccountCompositeId = 1,
                            AccountId = 2,
                            EntryDate = DateTime.UtcNow.Date
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<AccountComposite>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(AccountComposite));

                // Fact: AccountAttributeMemberEntries property is non-empty collection with
                // count matching source.
                Assert.IsTrue(
                    entity.AccountCompositeNavigation.AccountAttributeMemberEntries.Count > 0);
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.AccountCompositeNavigation.AccountAttributeMemberEntries.Count);

                // Fact: AccountCompositeMembers property is non-empty collection with count
                // matching source.
                Assert.IsTrue(entity.AccountCompositeMembers.Count > 0);
                Assert.AreEqual(
                    expected: dto.AccountMembers.Count,
                    actual: entity.AccountCompositeMembers.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.Id, entity.AccountCompositeNavigation.AccountObjectId);
                Assert.AreEqual(dto.ShortCode, entity.AccountCompositeNavigation.AccountObjectCode);
                Assert.AreEqual(dto.StartDate, entity.AccountCompositeNavigation.StartDate);
                Assert.AreEqual(dto.CloseDate, entity.AccountCompositeNavigation.CloseDate);
                Assert.AreEqual(dto.DisplayName, entity.AccountCompositeNavigation.ObjectDisplayName);
                Assert.AreEqual(dto.Description, entity.AccountCompositeNavigation.ObjectDescription);
                Assert.AreEqual(dto.ObjectType, entity.AccountCompositeNavigation.ObjectType);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class AccountCompositeMemberMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountCompositeMemberMapping"/> class.
            /// </summary>
            public AccountCompositeMemberMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new AccountCompositeMember()
                {
                    AccountId = 1,
                    AccountCompositeId = 2,
                    EntryDate = DateTime.UtcNow.Date,
                    ExitDate = DateTime.UtcNow.Date.AddDays(13),
                    Comment = "Some comment",
                    DisplayOrder = 1
                };

                // Act
                var dto = Mapper.Map<AccountCompositeMemberDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(AccountCompositeMemberDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountId, dto.AccountId);
                Assert.AreEqual(entity.AccountCompositeId, dto.AccountCompositeId);
                Assert.AreEqual(entity.EntryDate, dto.EntryDate);
                Assert.AreEqual(entity.ExitDate, dto.ExitDate);
                Assert.AreEqual(entity.Comment, dto.Comment);
                Assert.AreEqual(entity.DisplayOrder, dto.DisplayOrder);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new AccountCompositeMemberDto()
                {
                    AccountId = 1,
                    AccountCompositeId = 2,
                    EntryDate = DateTime.UtcNow.Date,
                    ExitDate = DateTime.UtcNow.Date.AddDays(13),
                    Comment = "Some comment",
                    DisplayOrder = 1
                };

                // Act
                var entity = Mapper.Map<AccountCompositeMember>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(AccountCompositeMember));

                // Fact: All property values match.
                Assert.AreEqual(dto.AccountId, entity.AccountId);
                Assert.AreEqual(dto.AccountCompositeId, entity.AccountCompositeId);
                Assert.AreEqual(dto.EntryDate, entity.EntryDate);
                Assert.AreEqual(dto.ExitDate, entity.ExitDate);
                Assert.AreEqual(dto.Comment, entity.Comment);
                Assert.AreEqual(dto.DisplayOrder, entity.DisplayOrder);
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
                var entity = new AccountAttributeMemberEntry()
                {
                    AccountObjectId = 1,
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
                var dto = Mapper.Map<AccountBaseAttributeDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(AccountBaseAttributeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountObjectId, dto.AccountObjectId);
                Assert.AreEqual(entity.AttributeMemberId, dto.AttributeMember.AttributeMemberId);
                Assert.AreEqual(entity.EffectiveDate, dto.EffectiveDate);
                Assert.AreEqual(entity.Weight, dto.PercentWeight);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new AccountBaseAttributeDto()
                {
                    AccountObjectId = 1,
                    EffectiveDate = DateTime.UtcNow.Date,
                    PercentWeight = 1M,
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
                var entity = Mapper.Map<AccountAttributeMemberEntry>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(AccountAttributeMemberEntry));

                // Fact: All property values match.
                Assert.AreEqual(dto.AccountObjectId, entity.AccountObjectId);
                Assert.AreEqual(dto.AttributeMember.AttributeMemberId, entity.AttributeMemberId);
                Assert.AreEqual(dto.EffectiveDate, entity.EffectiveDate);
                Assert.AreEqual(dto.PercentWeight, entity.Weight);
            }
        }
    }
}
