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
    /// Class for unit test methods targeting <see cref="MarketHolidayProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class MarketHolidayProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<MarketHolidayProfile>();
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

    public partial class MarketHolidayProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class MarketHolidayMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MarketHolidayMapping"/> class.
            /// </summary>
            public MarketHolidayMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new MarketHoliday()
                {
                    MarketHolidayId = 1,
                    MarketHolidayName = "Holiday"
                };

                // Act
                var dto = Mapper.Map<MarketHolidayDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(MarketHolidayDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.MarketHolidayId, dto.MarketHolidayId);
                Assert.AreEqual(entity.MarketHolidayName, dto.MarketHolidayName);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new MarketHolidayDto()
                {
                    MarketHolidayId = 1,
                    MarketHolidayName = "Holiday"
                };

                // Act
                var entity = Mapper.Map<MarketHoliday>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(MarketHoliday));

                // Fact: All property values match.
                Assert.AreEqual(dto.MarketHolidayId, entity.MarketHolidayId);
                Assert.AreEqual(dto.MarketHolidayName, entity.MarketHolidayName);
            }
        }

        [TestClass]
        [TestCategory("Unit")]
        public class MarketHolidayObservanceMapping : MappingTest
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MarketHolidayObservanceMapping"/> class.
            /// </summary>
            public MarketHolidayObservanceMapping() : base(new Mapper(TestConfiguration))
            {
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Dto_MapFrom_Entity_MappedProperties_AreEqual()
            {
                // Arrange
                var entity = new MarketHolidayObservance()
                {
                    MarketHolidayId = 1,
                    ObservanceDate = DateTime.UtcNow
                };

                // Act
                var dto = Mapper.Map<MarketHolidayObservanceDto>(entity);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(dto, typeof(MarketHolidayObservanceDto));

                // Fact: All property values match.
                Assert.AreEqual(entity.MarketHolidayId, dto.MarketHolidayId);
                Assert.AreEqual(entity.ObservanceDate, dto.ObservanceDate);
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new MarketHolidayObservanceDto()
                {
                    MarketHolidayId = 1,
                    ObservanceDate = DateTime.UtcNow
                };

                // Act
                var entity = Mapper.Map<MarketHolidayObservance>(dto);

                // Assert
                // Fact: Instance is created 
                Assert.IsInstanceOfType(entity, typeof(MarketHolidayObservance));

                // Fact: All property values match.
                Assert.AreEqual(dto.MarketHolidayId, entity.MarketHolidayId);
                Assert.AreEqual(dto.ObservanceDate, entity.ObservanceDate);
            }
        }
    }
}
