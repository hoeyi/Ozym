using AutoMapper;
using Ozym.DataTransfer.Common;
using Ozym.DataTransfer.Profiles;
using Ozym.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public partial class BankTransactionProfileTest : IProfileTest
    {
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<BankTransactionProfile>();
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

    public partial class BankTransactionProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class BankTransactionCodeMapping : MappingTest
        {
            public BankTransactionCodeMapping()
                : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new BankTransactionCode()
                {
                    TransactionCodeId = 1,
                    TransactionCode = "grocery",
                    DisplayName = "Grocery and Food",
                    BankTransactionCodeAttributeMemberEntries = 
                        new List<BankTransactionCodeAttributeMemberEntry>()
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
                var dto = Mapper.Map<BankTransactionCodeDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(BankTransactionCodeDto));

                // Fact: Attributes property is non-empty collection with count matching source.
                Assert.IsTrue(dto.Attributes.Count > 0);
                Assert.AreEqual(
                    expected: entity.BankTransactionCodeAttributeMemberEntries.Count,
                    actual: dto.Attributes.Count);

                // Fact: All attributes have AttributeMember complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember is not null));

                // Fact: All AttributeMember complex properties have Attribute complex property defined.
                Assert.IsTrue(dto.Attributes.All(x => x.AttributeMember.Attribute is not null));

                // Fact: All property values match.
                Assert.AreEqual(entity.TransactionCodeId, dto.TransactionCodeId);
                Assert.AreEqual(entity.TransactionCode, dto.TransactionCode);
                Assert.AreEqual(entity.DisplayName, dto.DisplayName);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new BankTransactionCodeDto()
                {
                    TransactionCodeId = 1,
                    TransactionCode = "grocery",
                    DisplayName = "Grocery and Food",
                    Attributes = new List<BankTransactionCodeAttributeDto>()
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
                var entity = Mapper.Map<BankTransactionCode>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(BankTransactionCode));

                // Fact: BankTransactionCodeAttributeMemberEntries property is non-empty collection with
                // count matching source.
                Assert.IsTrue(entity.BankTransactionCodeAttributeMemberEntries.Count > 0);
                Assert.AreEqual(
                    expected: dto.Attributes.Count,
                    actual: entity.BankTransactionCodeAttributeMemberEntries.Count);

                // Fact: All property values match.
                Assert.AreEqual(dto.TransactionCodeId, entity.TransactionCodeId);
                Assert.AreEqual(dto.TransactionCode, entity.TransactionCode);
                Assert.AreEqual(dto.DisplayName, entity.DisplayName);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class BankTransactionMapping : MappingTest
        {
            public BankTransactionMapping()
                : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new BankTransaction()
                {
                    AccountId = 2,
                    TransactionId = 100,
                    TransactionCodeId = 1,
                    TransactionDate = DateTime.UtcNow.Date,
                    Comment = "Some comment or notes",
                    Amount = 45.67M
                };

                // Act
                var dto = Mapper.Map<BankTransactionDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(BankTransactionDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.AccountId, dto.AccountId);
                Assert.AreEqual(entity.TransactionId, dto.TransactionId);
                Assert.AreEqual(entity.TransactionCodeId, dto.TransactionCodeId);
                Assert.AreEqual(entity.TransactionDate, dto.TransactionDate);
                Assert.AreEqual(entity.Comment, dto.Comment);
                Assert.AreEqual(entity.Amount, dto.Amount);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new BankTransactionDto()
                {
                    AccountId = 2,
                    TransactionId = 100,
                    TransactionCodeId = 1,
                    TransactionDate = DateTime.UtcNow.Date,
                    Comment = "Some comment or notes",
                    Amount = 45.67M
                };

                // Act
                var entity = Mapper.Map<BankTransaction>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(BankTransaction));

                // Fact: All property values match.
                Assert.AreEqual(dto.AccountId, entity.AccountId);
                Assert.AreEqual(dto.TransactionId, entity.TransactionId);
                Assert.AreEqual(dto.TransactionCodeId, entity.TransactionCodeId);
                Assert.AreEqual(dto.TransactionDate, entity.TransactionDate);
                Assert.AreEqual(dto.Comment, entity.Comment);
                Assert.AreEqual(dto.Amount, entity.Amount);
            }
        }
    }
}
