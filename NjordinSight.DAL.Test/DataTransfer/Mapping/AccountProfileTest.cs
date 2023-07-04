using AutoMapper;
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
    [TestClass]
    [TestCategory("Unit")]
    public class AccountProfileTest : IProfileTest, IProfileWithDependencyTest
    {
        [TestMethod]
        public void Configuration_IsValid()
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
        public async Task Dto_MapFrom_Entity_MappedProperties_AreEqual()
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
                Task.Run(() => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction)),
                Task.Run(() => Assert.IsTrue(
                    Compare(
                        attributeDto: accountDto.Attributes.First(),
                        attribute: account.AccountNavigation.AccountAttributeMemberEntries.First())))
            };

            Task assertions = Task.WhenAll(comparisons);
            await assertions;

            if (assertions.Status == TaskStatus.Faulted)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Entity_MapFrom_Dto_MappedProperties_AreEqual()
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
                Task.Run(() => Assert.AreEqual(accountDto.HasBrokerTransaction, account.HasBrokerTransaction)),
                Task.Run(() => Assert.IsTrue(
                    Compare(
                        attributeDto: accountDto.Attributes.First(),
                        attribute: account.AccountNavigation.AccountAttributeMemberEntries.First())))
            };

            Task assertions = Task.WhenAll(comparisons);
            await assertions;

            if (assertions.Status == TaskStatus.Faulted)
            {
                Assert.Fail();
            }
        }

        private static bool Compare(
            AccountBaseAttributeDto attributeDto, AccountAttributeMemberEntry attribute)
        {
            return attribute.AttributeMemberId == attributeDto.AttributeMember.AttributeMemberId
                && attribute.EffectiveDate == attributeDto.EffectiveDate 
                && attribute.AccountObjectId == attributeDto.AccountObjectId
                && attribute.Weight == attributeDto.PercentWeight;
        }
    }
}
