using AutoMapper;
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
    public partial class BrokerTransactionProfileTest : IProfileTest
    {
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
                x.AddProfile<SecurityProfile>();
                x.AddProfile<BrokerTransactionProfile>();
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

    public partial class BrokerTransactionProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class BrokerTransactionCodeMapping : MappingTest
        {
            public BrokerTransactionCodeMapping()
                : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new BrokerTransactionCode()
                {
                    TransactionCodeId = 1,
                    TransactionCode = "buy",
                    DisplayName = "Buy",
                    QuantityEffect = 1,
                    CashEffect = -1,
                    ContributionWithdrawalEffect = 1,
                    BrokerTransactionCodeAttributeMemberEntries =
                        new List<BrokerTransactionCodeAttributeMemberEntry>()
                        {
                            new()
                            {
                                TransactionCodeId = 1,
                                AttributeMemberId = 1,
                                EffectiveDate = DateTime.UtcNow.Date,
                                Weight = 1M,
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
                                }
                            },
                            new()
                            {
                                TransactionCodeId = 1,
                                AttributeMemberId = 2,
                                EffectiveDate = DateTime.UtcNow.Date,
                                Weight = 1M,
                                AttributeMember = new()
                                {
                                    AttributeMemberId = 2,
                                    DisplayName = "Member 2",
                                    DisplayOrder = 2,
                                    Attribute = new()
                                    {
                                        AttributeId = 2,
                                        DisplayName = "Attribute 2"
                                    }
                                }
                            }
                        }
                };

                // Act
                var dto = Mapper.Map<BrokerTransactionCodeDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(BrokerTransactionCodeDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Attributes.Count > 0);
                Assert.AreEqual(
                    expected: entity.BrokerTransactionCodeAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                Assert.AreEqual(entity.TransactionCodeId, dto.TransactionCodeId);
                Assert.AreEqual(entity.TransactionCode, dto.TransactionCode);
                Assert.AreEqual(entity.DisplayName, dto.DisplayName);
                Assert.AreEqual(dto.CashEffect, entity.CashEffect);
                Assert.AreEqual(dto.ContributionWithdrawalEffect, entity.ContributionWithdrawalEffect);
                Assert.AreEqual(dto.QuantityEffect, entity.QuantityEffect);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new BrokerTransactionCodeDto()
                {
                    TransactionCodeId = 1,
                    TransactionCode = "grocery",
                    DisplayName = "Grocery and Food",
                    Attributes = new List<BrokerTransactionCodeAttributeDto>()
                    {
                        new()
                        {
                            TransactionCodeId = 1,
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
                            PercentWeight = 1M
                        },
                        new()
                        {
                            TransactionCodeId = 1,
                            AttributeMemberId = 2,
                            AttributeMember = new()
                            {
                                AttributeMemberId = 1,
                                DisplayName = "Member 2",
                                DisplayOrder = 2,
                                Attribute = new()
                                {
                                    AttributeId = 1,
                                    DisplayName = "Attribute 2"
                                }
                            },
                            EffectiveDate = DateTime.UtcNow.Date,
                            PercentWeight = 1M
                        }
                    }
                };

                // Act
                var entity = Mapper.Map<BrokerTransactionCode>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(BrokerTransactionCode));

                // Fact: BankTransactionCodeAttributeMemberEntries property is non-empty collection with
                // count matching source.
                Assert.IsTrue(entity.BrokerTransactionCodeAttributeMemberEntries.Count > 0);
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.BrokerTransactionCodeAttributeMemberEntries.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.TransactionCodeId, entity.TransactionCodeId);
                Assert.AreEqual(dto.TransactionCode, entity.TransactionCode);
                Assert.AreEqual(dto.DisplayName, entity.DisplayName);
                Assert.AreEqual(dto.CashEffect, entity.CashEffect);
                Assert.AreEqual(dto.ContributionWithdrawalEffect, entity.ContributionWithdrawalEffect);
                Assert.AreEqual(dto.QuantityEffect, entity.QuantityEffect);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class BrokerTransactionMapping : MappingTest
        {
            public BrokerTransactionMapping()
                : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new BrokerTransaction()
                {
                    AccountId = 2,
                    TransactionId = 100,
                    TransactionCodeId = 1,
                    SecurityId = 10,
                    TradeDate = DateTime.UtcNow.Date,
                    SettleDate = DateTime.UtcNow.Date.AddDays(2),
                    AcquisitionDate = DateTime.UtcNow.Date.AddDays(-180),
                    Amount = 10000M,
                    Fee = 10M,
                    TaxLotId = 10
                };

                // Act
                var dto = Mapper.Map<BrokerTransactionDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(BrokerTransactionDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountId, dto.AccountId);
                Assert.AreEqual(entity.TransactionId, dto.TransactionId);
                Assert.AreEqual(entity.TransactionCodeId, dto.TransactionCodeId);
                Assert.AreEqual(entity.SecurityId, dto.SecurityId);
                Assert.AreEqual(entity.TradeDate, dto.TradeDate);
                Assert.AreEqual(entity.SettleDate, dto.SettleDate);
                Assert.AreEqual(entity.AcquisitionDate, dto.AcquisitionDate);
                Assert.AreEqual(entity.DepSecurityId, dto.DepSecurityId);
                Assert.AreEqual(entity.Amount, dto.Amount);
                Assert.AreEqual(entity.Fee, dto.Fee);
                Assert.AreEqual(entity.Withholding, dto.Withholding);
                Assert.AreEqual(entity.TaxLotId, dto.TaxLotId);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new BrokerTransactionDto()
                {
                    AccountId = 2,
                    TransactionId = 100,
                    TransactionCodeId = 1,
                    SecurityId = 10,
                    TradeDate = DateTime.UtcNow.Date,
                    SettleDate = DateTime.UtcNow.Date.AddDays(2),
                    AcquisitionDate = DateTime.UtcNow.Date.AddDays(-180),
                    Amount = 10000M,
                    Fee = 10M,
                    DepSecurityId = 5,
                    TaxLotId = 10
                };

                // Act
                var entity = Mapper.Map<BrokerTransaction>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(BrokerTransaction));

                // Fact: All property values match.
                Assert.AreEqual(dto.AccountId, entity.AccountId);
                Assert.AreEqual(dto.TransactionId, entity.TransactionId);
                Assert.AreEqual(dto.TransactionCodeId, entity.TransactionCodeId);
                Assert.AreEqual(dto.SecurityId, entity.SecurityId);
                Assert.AreEqual(dto.TradeDate, entity.TradeDate);
                Assert.AreEqual(dto.SettleDate, entity.SettleDate);
                Assert.AreEqual(dto.AcquisitionDate, entity.AcquisitionDate);
                Assert.AreEqual(dto.DepSecurityId, entity.DepSecurityId);
                Assert.AreEqual(dto.Amount, entity.Amount);
                Assert.AreEqual(dto.Fee, entity.Fee);
                Assert.AreEqual(dto.Withholding, entity.Withholding);
                Assert.AreEqual(dto.TaxLotId, entity.TaxLotId);
            }
        }
    }
}
