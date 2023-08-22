using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="SecurityExchangeProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityExchangeProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<SecurityExchangeProfile>();
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

    public partial class SecurityExchangeProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class SecurityExchangeMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityExchangeMapping"/> class.
            /// </summary>
            public SecurityExchangeMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new SecurityExchange()
                {
                    ExchangeId = 1,
                    ExchangeCode = "NYSE",
                    ExchangeDescription = "New York Stock Exchange"
                };

                // Act
                var dto = Mapper.Map<SecurityExchangeDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecurityExchangeDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.ExchangeId, dto.ExchangeId);
                Assert.AreEqual(entity.ExchangeCode, dto.ExchangeCode);
                Assert.AreEqual(entity.ExchangeDescription, dto.ExchangeDescription);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new SecurityExchangeDto()
                {
                    ExchangeId = 1,
                    ExchangeCode = "NYSE",
                    ExchangeDescription = "New York Stock Exchange"
                };

                // Act
                var entity = Mapper.Map<SecurityExchange>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecurityExchange));

                // Fact: All property values match.
                Assert.AreEqual(dto.ExchangeId, entity.ExchangeId);
                Assert.AreEqual(dto.ExchangeCode, entity.ExchangeCode);
                Assert.AreEqual(dto.ExchangeDescription, entity.ExchangeDescription);
            }
        }
    }
}
