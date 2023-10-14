using AutoMapper;
using MathNet.Numerics.Random;
using Ozym.DataTransfer.Common;
using Ozym.DataTransfer.Profiles;
using Ozym.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozym.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="SecurityPriceProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class SecurityPriceProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<SecurityPriceProfile>();
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

    public partial class SecurityPriceProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class SecurityPriceMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SecurityPriceMapping"/> class.
            /// </summary>
            public SecurityPriceMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var random = new Random();
                var entity = new SecurityPrice()
                {
                    PriceId = 1,
                    SecurityId = 1,
                    PriceDate = DateTime.UtcNow.Date,
                    PriceClose = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceOpen = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceHigh = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceLow = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    Volume = random.Next()
                };

                // Act
                var dto = Mapper.Map<SecurityPriceDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(SecurityPriceDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.PriceId, dto.PriceId);
                Assert.AreEqual(entity.SecurityId, dto.SecurityId);
                Assert.AreEqual(entity.PriceDate, dto.PriceDate);
                Assert.AreEqual(entity.PriceClose, dto.PriceClose);
                Assert.AreEqual(entity.PriceOpen, dto.PriceOpen);
                Assert.AreEqual(entity.PriceHigh, dto.PriceHigh);
                Assert.AreEqual(entity.PriceLow, dto.PriceLow);
                Assert.AreEqual(entity.Volume, dto.Volume);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var random = new Random();
                var dto = new SecurityPriceDto()
                {
                    PriceId = 1,
                    SecurityId = 1,
                    PriceDate = DateTime.UtcNow.Date,
                    PriceClose = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceOpen = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceHigh = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    PriceLow = Math.Round((decimal)random.NextDouble() * 1000M, 2),
                    Volume = random.Next()
                };

                // Act
                var entity = Mapper.Map<SecurityPrice>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(SecurityPrice));

                // Fact: All property values match.
                Assert.AreEqual(dto.PriceId, entity.PriceId);
                Assert.AreEqual(dto.SecurityId, entity.SecurityId);
                Assert.AreEqual(dto.PriceDate, entity.PriceDate);
                Assert.AreEqual(dto.PriceClose, entity.PriceClose);
                Assert.AreEqual(dto.PriceOpen, entity.PriceOpen);
                Assert.AreEqual(dto.PriceHigh, entity.PriceHigh);
                Assert.AreEqual(dto.PriceLow, entity.PriceLow);
                Assert.AreEqual(dto.Volume, entity.Volume);
            }
        }
    }
}
