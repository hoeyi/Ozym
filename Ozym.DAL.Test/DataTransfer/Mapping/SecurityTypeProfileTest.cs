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
    /// Class for unit test methods targeting <see cref="SecurityTypeProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityTypeProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<SecurityTypeProfile>();
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

    public partial class SecurityTypeProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class SecurityTypeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityTypeMapping"/> class.
            /// </summary>
            public SecurityTypeMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecurityType()
                {
                    SecurityTypeId = 10,
                    SecurityTypeGroupId = 1,
                    SecurityTypeName = "Security Type",
                    CanHaveDerivative = true,
                    CanHavePosition = true,
                    HeldInWallet = true,
                    ValuationFactor = 1M,
                    AttributeMemberNavigation = new()
                    {
                        AttributeId = 2,
                        AttributeMemberId = 10,
                        DisplayName = "Security Type",
                        DisplayOrder = 1
                    }
                };

                // Act
                var dto = Mapper.Map<SecurityTypeDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(SecurityTypeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SecurityTypeId, dto.SecurityTypeId);
                Assert.AreEqual(entity.SecurityTypeGroupId, dto.SecurityTypeGroupId);
                Assert.AreEqual(entity.SecurityTypeName, dto.SecurityTypeName);
                Assert.AreEqual(entity.CanHaveDerivative, dto.CanHaveDerivative);
                Assert.AreEqual(entity.CanHavePosition, dto.CanHavePosition);
                Assert.AreEqual(entity.HeldInWallet, dto.HeldInWallet);
                Assert.AreEqual(entity.ValuationFactor, dto.ValuationFactor);

                Assert.AreEqual(entity.AttributeMemberNavigation.DisplayName, dto.SecurityTypeName);
                Assert.AreEqual(entity.AttributeMemberNavigation.DisplayOrder, dto.DisplayOrder);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecurityTypeDto()
                {
                    SecurityTypeId = 1,
                    SecurityTypeGroupId = 1,
                    SecurityTypeName = "Security Type",
                    CanHaveDerivative = true,
                    CanHavePosition = true,
                    HeldInWallet = true,
                    ValuationFactor = 1M,
                    DisplayOrder = 1
                };

                // Act
                var entity = Mapper.Map<SecurityType>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(SecurityType));

                // Fact: All property values match.
                Assert.AreEqual(dto.SecurityTypeId, entity.SecurityTypeId);
                Assert.AreEqual(dto.SecurityTypeGroupId, entity.SecurityTypeGroupId);
                Assert.AreEqual(dto.SecurityTypeName, entity.SecurityTypeName);
                Assert.AreEqual(dto.CanHaveDerivative, entity.CanHaveDerivative);
                Assert.AreEqual(dto.CanHavePosition, entity.CanHavePosition);
                Assert.AreEqual(dto.HeldInWallet, entity.HeldInWallet);
                Assert.AreEqual(dto.ValuationFactor, entity.ValuationFactor);

                Assert.AreEqual(dto.SecurityTypeName, entity.AttributeMemberNavigation.DisplayName);
                Assert.AreEqual(dto.DisplayOrder, entity.AttributeMemberNavigation.DisplayOrder);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class SecurityTypeGroupMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityTypeGroupMapping"/> class.
            /// </summary>
            public SecurityTypeGroupMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecurityTypeGroup()
                {
                    SecurityTypeGroupId = 1,
                    SecurityTypeGroupName = "Security Type Group",
                    Transactable = true,
                    DepositSource = true,
                    AttributeMemberNavigation = new()
                    {
                        AttributeId = 1,
                        AttributeMemberId = 1,
                        DisplayName = "Security Type Group",
                        DisplayOrder = 1
                    }
                };

                // Act
                var dto = Mapper.Map<SecurityTypeGroupDto>(entity);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(SecurityTypeGroupDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.SecurityTypeGroupId, dto.SecurityTypeGroupId);
                Assert.AreEqual(entity.SecurityTypeGroupName, dto.SecurityTypeGroupName);
                Assert.AreEqual(entity.Transactable, dto.Transactable);
                Assert.AreEqual(entity.DepositSource, dto.DepositSource);
                Assert.AreEqual(entity.AttributeMemberNavigation.DisplayName, dto.SecurityTypeGroupName);
                Assert.AreEqual(entity.AttributeMemberNavigation.DisplayOrder, dto.DisplayOrder);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecurityTypeGroupDto()
                {
                    SecurityTypeGroupId = 1,
                    SecurityTypeGroupName = "Security Type Group",
                    Transactable = true,
                    DepositSource = true,
                    DisplayOrder = 1
                };

                // Act
                var entity = Mapper.Map<SecurityTypeGroup>(dto);

                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(entity, typeof(SecurityTypeGroup));

                // Fact: All property values match.
                Assert.AreEqual(dto.SecurityTypeGroupId, entity.SecurityTypeGroupId);
                Assert.AreEqual(dto.SecurityTypeGroupName, entity.SecurityTypeGroupName);
                Assert.AreEqual(dto.Transactable, entity.Transactable);
                Assert.AreEqual(dto.DepositSource, entity.DepositSource);
                Assert.AreEqual(dto.SecurityTypeGroupName, entity.AttributeMemberNavigation.DisplayName);
                Assert.AreEqual(dto.DisplayOrder, entity.AttributeMemberNavigation.DisplayOrder);
            }
        }
    }
}
