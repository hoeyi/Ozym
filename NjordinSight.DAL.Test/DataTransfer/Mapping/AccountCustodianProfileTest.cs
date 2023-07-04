using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public partial class AccountCustodianProfileTest : IProfileTest
    {
        /// <summary>
        /// Defines the <see cref="IConfigurationProvider"/> used to test the target profile 
        /// and constituent mappings.
        /// </summary>
        private static IConfigurationProvider MapperConfiguration =>
            new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<AccountProfile>();
            });

        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = MapperConfiguration;

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }

    }

    public partial class AccountCustodianProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class AccountCustodianMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountCustodianMapping"/> class.
            /// </summary>
            public AccountCustodianMapping() : base(new Mapper(MapperConfiguration))
            {
            }

            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new AccountCustodian()
                {
                    AccountCustodianId = 1,
                    CustodianCode = "TEST",
                    DisplayName = "Test Custodian",
                };

                // Act
                var dto = Mapper.Map<AccountCustodianDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(AccountCustodianDto));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.AccountCustodianId, dto.AccountCustodianId),
                    () => Assert.AreEqual(entity.CustodianCode, dto.CustodianCode),
                    () => Assert.AreEqual(entity.DisplayName, dto.DisplayName)
                };

                assertions.ForEach(x => x.Invoke());
            }

            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new AccountCustodianDto()
                {
                    AccountCustodianId = 1,
                    CustodianCode = "TEST",
                    DisplayName = "Test Custodian"
                };
                
                // Act
                var entity = Mapper.Map<AccountCustodian>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(AccountCustodian));

                // Fact: All property values match.
                var assertions = new List<Action>()
                {
                    () => Assert.AreEqual(entity.AccountCustodianId, dto.AccountCustodianId),
                    () => Assert.AreEqual(entity.CustodianCode, dto.CustodianCode),
                    () => Assert.AreEqual(entity.DisplayName, dto.DisplayName)
                };

                assertions.ForEach(x => x.Invoke());
            }
        }
    }
}
