using AutoMapper;
using MathNet.Numerics.Statistics.Mcmc;
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
        public void Dto_MapFrom_Entity_MappedProperties_AreEqual()
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
                () => Assert.IsTrue(
                    Compare(
                        attributeDto: accountDto.Attributes.First(),
                        attribute: account.AccountNavigation.AccountAttributeMemberEntries.First()))
            };

            assertions.ForEach(x => x.Invoke());
        }

        [TestMethod]
        public void Entity_MapFrom_Dto_MappedProperties_AreEqual()
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
            // We do not test colleciton equality because that overlaps with testing the mapping 
            // behavior of the colleciton type.
            Assert.AreEqual(
                accountDto.Attributes.Count,
                account.AccountNavigation.AccountAttributeMemberEntries.Count);

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
                () => Assert.IsTrue(
                    Compare(
                        attributeDto: accountDto.Attributes.First(),
                        attribute: account.AccountNavigation.AccountAttributeMemberEntries.First()))
            };

            assertions.ForEach(x => x.Invoke());
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
