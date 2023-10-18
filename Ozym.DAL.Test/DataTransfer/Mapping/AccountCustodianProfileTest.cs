using AutoMapper;
using Ozym.DataTransfer.Profiles;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ozym.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="AccountCustodianProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class AccountCustodianProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<AccountCustodianProfile>();
            });

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

    public partial class AccountCustodianProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class AccountCustodianMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AccountCustodianMapping"/> class.
            /// </summary>
            public AccountCustodianMapping() : base(new Mapper(TestConfiguration))
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
