using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvestmentModelProfileTest : IProfileTest, IProfileWithDependencyTest
    {
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
                x.AddProfile<InvestmentModelProfile>();
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
                x.AddProfile<InvestmentModelProfile>();
            });

            // Act

            // Assert
            Assert.ThrowsException<AutoMapperConfigurationException>(() =>
                config.AssertConfigurationIsValid());
        }

        public void Dto_MapFrom_Entity_MappedProperties_AreEqual()
        {
            throw new System.NotImplementedException();
        }

        public void Entity_MapFrom_Dto_MappedProperties_AreEqual()
        {
            throw new System.NotImplementedException();
        }
    }
}
