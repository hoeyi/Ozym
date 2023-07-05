using AutoMapper;
using MathNet.Numerics.Statistics.Mcmc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Test class targeting <see cref="AccountProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class AccountProfileTest : IProfileTest, IProfileWithDependencyTest
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

        /// <inheritdoc/>
        [TestMethod]
        public void Configuration_WithoutProfileDependencies_IsInvalid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                // Act
                x.AddProfile<AccountProfile>();
            });

            // Assert
            Assert.ThrowsException<AutoMapperConfigurationException>(() =>
                config.AssertConfigurationIsValid());
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
                var account = new Account()
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
                var accountDto = Mapper.Map<AccountDto>(account);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(accountDto, typeof(AccountDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.AreEqual(
                    accountDto.Attributes.Count,
                    account.AccountNavigation.AccountAttributeMemberEntries.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(accountDto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(accountDto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(account.AccountNavigation.AccountObjectId, accountDto.Id),
                    () => Assert.AreEqual(account.AccountNavigation.AccountObjectCode, accountDto.ShortCode),
                    () => Assert.AreEqual(account.AccountNavigation.StartDate, accountDto.StartDate),
                    () => Assert.AreEqual(account.AccountNavigation.CloseDate, accountDto.CloseDate),
                    () => Assert.AreEqual(account.AccountNavigation.ObjectDisplayName, accountDto.DisplayName),
                    () => Assert.AreEqual(account.AccountNavigation.ObjectDescription, accountDto.Description),
                    () => Assert.AreEqual(account.AccountNavigation.ObjectType, accountDto.ObjectType),
                    () => Assert.AreEqual(account.AccountCustodianId, accountDto.AccountCustodianId),
                    () => Assert.AreEqual(account.AccountNumber, accountDto.AccountNumber),
                    () => Assert.AreEqual(account.HasWallet, accountDto.HasWallet),
                    () => Assert.AreEqual(account.HasBankTransaction, accountDto.HasBankTransaction),
                    () => Assert.AreEqual(account.HasBrokerTransaction, accountDto.HasBrokerTransaction),
                };

                assertions.ForEach(x => x.Invoke());
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var accountDto = new AccountDto()
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
                var account = Mapper.Map<Account>(accountDto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(account, typeof(Account));

                // Fact: Attributes property is non-empty collection with count matching source.
                // We do not test colleciton equality because that overlaps with testing the mapping 
                // behavior of the colleciton type.

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(accountDto.Id, account.AccountNavigation.AccountObjectId),
                    () => Assert.AreEqual(accountDto.ShortCode, account.AccountNavigation.AccountObjectCode),
                    () => Assert.AreEqual(accountDto.StartDate, account.AccountNavigation.StartDate),
                    () => Assert.AreEqual(accountDto.CloseDate, account.AccountNavigation.CloseDate),
                    () => Assert.AreEqual(accountDto.DisplayName, account.AccountNavigation.ObjectDisplayName),
                    () => Assert.AreEqual(accountDto.Description, account.AccountNavigation.ObjectDescription),
                    () => Assert.AreEqual(accountDto.ObjectType, account.AccountNavigation.ObjectType),
                    () => Assert.AreEqual(accountDto.AccountCustodianId, account.AccountCustodianId),
                    () => Assert.AreEqual(accountDto.AccountNumber, account.AccountNumber),
                    () => Assert.AreEqual(accountDto.HasWallet, account.HasWallet),
                    () => Assert.AreEqual(accountDto.HasBankTransaction, account.HasBankTransaction),
                    () => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction),
                    () => Assert.AreEqual(
                            accountDto.Attributes.Count,
                            account.AccountNavigation.AccountAttributeMemberEntries.Count)
                };

                assertions.ForEach(x => x.Invoke());
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
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                throw new NotImplementedException();
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
                    EffectiveDate = new DateTime(2030, 12, 31),
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
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.AccountObjectId, dto.AccountObjectId),
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
                var dto = new AccountBaseAttributeDto()
                {
                    AccountObjectId = 1,
                    EffectiveDate = new DateTime(2030, 12, 31),
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
                Assert.IsInstanceOfType(dto, typeof(AccountBaseAttributeDto));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(dto.AccountObjectId, entity.AccountObjectId),
                    () => Assert.AreEqual(dto.AttributeMember.AttributeMemberId, entity.AttributeMemberId),
                    () => Assert.AreEqual(dto.EffectiveDate, entity.EffectiveDate),
                    () => Assert.AreEqual(dto.PercentWeight, entity.Weight)
                };

                assertions.ForEach(x => x.Invoke());
            }
        }
    }
}
