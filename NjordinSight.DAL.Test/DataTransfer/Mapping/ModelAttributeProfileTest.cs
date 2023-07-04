using AutoMapper;
using NjordinSight.DataTransfer.Profiles;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    [TestClass]
    [TestCategory("Unit")]
    public class ModelAttributeProfileTest : IProfileTest
    {
        [TestMethod]
        public void Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ModelAttributeProfile>();
            });

            // Act

            // Assert
            config.AssertConfigurationIsValid();
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
