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
    /// Class for unit test methods targeting <see cref="MarketIndexProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class MarketIndexProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<MarketIndexProfile>();
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

    public partial class MarketIndexProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class MarketIndexMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MarketIndexMapping"/> class.
            /// </summary>
            public MarketIndexMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new MarketIndex()
                {
                    IndexId = 1,
                    IndexCode = "INDEX",
                    IndexDescription = "Description"
                };

                // Act
                var dto = Mapper.Map<MarketIndexDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(MarketIndexDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.IndexId, dto.IndexId);
                Assert.AreEqual(entity.IndexCode, dto.IndexCode);
                Assert.AreEqual(entity.IndexDescription, dto.IndexDescription);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new MarketIndexDto()
                {
                    IndexId = 1,
                    IndexCode = "INDEX",
                    IndexDescription = "Description"
                };

                // Act
                var entity = Mapper.Map<MarketIndex>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(MarketIndex));

                // Fact: All property values match.
                Assert.AreEqual(dto.IndexId, entity.IndexId);
                Assert.AreEqual(dto.IndexCode, entity.IndexCode);
                Assert.AreEqual(dto.IndexDescription, entity.IndexDescription);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class MarketIndexPriceMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MarketIndexPriceMapping"/> class.
            /// </summary>
            public MarketIndexPriceMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new MarketIndexPrice()
                {
                    MarketIndexId = 1,
                    Price = new Random().Next() / 100M,
                    PriceCode = "p",
                    PriceDate = DateTime.UtcNow.Date
                };

                // Act
                var dto = Mapper.Map<MarketIndexPriceDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(MarketIndexPriceDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.MarketIndexId, dto.MarketIndexId);
                Assert.AreEqual(entity.Price, dto.Price);
                Assert.AreEqual(entity.PriceCode, dto.PriceCode);
                Assert.AreEqual(entity.PriceDate, dto.PriceDate);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new MarketIndexPriceDto()
                {
                    MarketIndexId = 1,
                    Price = new Random().Next() / 100M,
                    PriceCode = "p",
                    PriceDate = DateTime.UtcNow.Date
                };

                // Act
                var entity = Mapper.Map<MarketIndexPrice>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(MarketIndexPrice));

                // Fact: All property values match.
                Assert.AreEqual(dto.MarketIndexId, entity.MarketIndexId);
                Assert.AreEqual(dto.Price, entity.Price);
                Assert.AreEqual(dto.PriceCode, entity.PriceCode);
                Assert.AreEqual(dto.PriceDate, entity.PriceDate);
            }
        }
    }
}
