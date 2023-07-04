using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class AccountCustodianProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<AccountCustodianProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Dto_MapFrom_Entity_MappedProperties_AreEqual()
        {
            // Arrange
            var entity = new AccountCustodian()
            {
                AccountCustodianId = 1,
                CustodianCode = "TEST",
                DisplayName = "Test Custodian",
            };
            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<AccountCustodianProfile>();
            }));

            // Act
            var dto = mapper.Map<AccountCustodianDto>(entity);

            // Assert
            // Fact: Instance is created 
            Assert.IsInstanceOfType(dto, typeof(AccountCustodianDto));

            // Fact: All property values match.
            var assertions = new List<Action>()
            {
                () => Assert.AreEqual(entity.AccountCustodianId, dto.AccountCustodianId),
                () => Assert.AreEqual(entity.CustodianCode, dto.CustodianCode),
                () => Assert.AreEqual(entity.DisplayName, string.Empty)
            };

            assertions.ForEach(x => x.Invoke());
        }

        void IProfileTest.Entity_MapFrom_Dto_MappedProperties_AreEqual()
        {
            throw new NotImplementedException();
        }
    }
}
