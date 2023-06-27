using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class AccountProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_WithProfileDependencies_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Configuration_WithoutProfileDependencies_IsInvalid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<AccountProfile>();
            });

            // Act

            // Assert
            Assert.ThrowsException<AutoMapperConfigurationException>(() => 
            config.AssertConfigurationIsValid());
        }

        [TestMethod]
        public async Task Account_MapTo_AccountDto_PopulatesAllProperties()
        {
            // Arrange
            var account = new Account()
            {
                AccountId = 1,
                AccountNumber = "####-####-####",
                HasBankTransaction = true,
                HasBrokerTransaction = true,
                AccountCustodianId  = 1,
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
                            Weight = 0.5M 
                        },
                        new() 
                        { 
                            AccountObjectId = 1, 
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
                                }
                            },
                            EffectiveDate = DateTime.UtcNow.Date, 
                            Weight = 0.5M 
                        }
                    }
                }
            };
            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            }));

            // Act
            var accountDto = mapper.Map<AccountDto>(account);

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
            var comparisons = new List<Task>()
            {
                Task.Run(() => Assert.AreEqual(accountDto.Id, account.AccountNavigation.AccountObjectId)),
                Task.Run(() => Assert.AreEqual(accountDto.ShortCode, account.AccountNavigation.AccountObjectCode)),
                Task.Run(() => Assert.AreEqual(accountDto.StartDate, account.AccountNavigation.StartDate)),
                Task.Run(() => Assert.AreEqual(accountDto.CloseDate, account.AccountNavigation.CloseDate)),
                Task.Run(() => Assert.AreEqual(accountDto.DisplayName, account.AccountNavigation.ObjectDisplayName)),
                Task.Run(() => Assert.AreEqual(accountDto.Description, account.AccountNavigation.ObjectDescription)),
                Task.Run(() => Assert.AreEqual(accountDto.ObjectType, account.AccountNavigation.ObjectType)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountCustodianId, account.AccountCustodianId)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountNumber, account.AccountNumber)),
                Task.Run(() => Assert.AreEqual(accountDto.HasWallet, account.HasWallet)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBankTransaction, account.HasBankTransaction)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction))
            };

            Task assertions = Task.WhenAll(comparisons);
            await assertions;

            if (assertions.Status == TaskStatus.Faulted)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Account_MapFrom_AccountDto_PopulatesAllProperties()
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
                        PercentWeight = 0.5M
                    },
                    new()
                    {
                        AccountObjectId = 1,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 2,
                            DisplayName = "Member 2",
                            DisplayOrder = 2,
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute 1"
                            }
                        },
                        EffectiveDate = DateTime.UtcNow.Date,
                        PercentWeight = 0.5M
                    }
                }
            };
            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            }));

            // Act
            var account = mapper.Map<Account>(accountDto);

            // Assert
            // Fact: Instance is created.
            Assert.IsInstanceOfType(account, typeof(Account));

            // Fact: Attributes property is non-empty collection with count matching source.
            Assert.AreEqual(
                accountDto.Attributes.Count,
                account.AccountNavigation.AccountAttributeMemberEntries.Count);

            // Fact: All property values match.
            var comparisons = new List<Task>() 
            { 
                Task.Run(() => Assert.AreEqual(accountDto.Id, account.AccountNavigation.AccountObjectId)),
                Task.Run(() => Assert.AreEqual(accountDto.ShortCode, account.AccountNavigation.AccountObjectCode)),
                Task.Run(() => Assert.AreEqual(accountDto.StartDate, account.AccountNavigation.StartDate)),
                Task.Run(() => Assert.AreEqual(accountDto.CloseDate, account.AccountNavigation.CloseDate)),
                Task.Run(() => Assert.AreEqual(accountDto.DisplayName, account.AccountNavigation.ObjectDisplayName)),
                Task.Run(() => Assert.AreEqual(accountDto.Description, account.AccountNavigation.ObjectDescription)),
                Task.Run(() => Assert.AreEqual(accountDto.ObjectType, account.AccountNavigation.ObjectType)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountCustodianId, account.AccountCustodianId)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountNumber, account.AccountNumber)),
                Task.Run(() => Assert.AreEqual(accountDto.HasWallet, account.HasWallet)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBankTransaction, account.HasBankTransaction)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction))
            };

            Task assertions = Task.WhenAll(comparisons);
            await assertions;

            if(assertions.Status == TaskStatus.Faulted)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Account_MapFrom_AccountDto_WithAddedAttributes_PopulatesAllProperties()
        {
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
                        PercentWeight = 0.5M
                    },
                    new()
                    {
                        AccountObjectId = 1,
                        AttributeMember = new()
                        {
                            AttributeMemberId = 2,
                            DisplayName = "Member 2",
                            DisplayOrder = 2,
                            Attribute = new()
                            {
                                AttributeId = 1,
                                DisplayName = "Attribute 1"
                            }
                        },
                        EffectiveDate = DateTime.UtcNow.Date,
                        PercentWeight = 0.5M
                    }
                }
            };

            accountDto.AttributeCollection.AddEntryForGrouping(
                new ModelAttributeDto()
                {
                    AttributeId = 10,
                    DisplayName = "Test added attribute"
                });

            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            }));

            // Act
            var account = mapper.Map<Account>(accountDto);

            // Assert
            // Fact: Instance is created.
            Assert.IsInstanceOfType(account, typeof(Account));

            // Fact: Attributes property is non-empty collection with count matching source.
            Assert.AreEqual(
                accountDto.Attributes.Count,
                account.AccountNavigation.AccountAttributeMemberEntries.Count);

            // Fact: All property values match.
            var comparisons = new List<Task>()
            {
                Task.Run(() => Assert.AreEqual(accountDto.Id, account.AccountNavigation.AccountObjectId)),
                Task.Run(() => Assert.AreEqual(accountDto.ShortCode, account.AccountNavigation.AccountObjectCode)),
                Task.Run(() => Assert.AreEqual(accountDto.StartDate, account.AccountNavigation.StartDate)),
                Task.Run(() => Assert.AreEqual(accountDto.CloseDate, account.AccountNavigation.CloseDate)),
                Task.Run(() => Assert.AreEqual(accountDto.DisplayName, account.AccountNavigation.ObjectDisplayName)),
                Task.Run(() => Assert.AreEqual(accountDto.Description, account.AccountNavigation.ObjectDescription)),
                Task.Run(() => Assert.AreEqual(accountDto.ObjectType, account.AccountNavigation.ObjectType)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountCustodianId, account.AccountCustodianId)),
                Task.Run(() => Assert.AreEqual(accountDto.AccountNumber, account.AccountNumber)),
                Task.Run(() => Assert.AreEqual(accountDto.HasWallet, account.HasWallet)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBankTransaction, account.HasBankTransaction)),
                Task.Run(() => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction))
            };

            Task assertions = Task.WhenAll(comparisons);
            await assertions;

            if (assertions.Status == TaskStatus.Faulted)
            {
                Assert.Fail();
            }
        }

        
    }
}
