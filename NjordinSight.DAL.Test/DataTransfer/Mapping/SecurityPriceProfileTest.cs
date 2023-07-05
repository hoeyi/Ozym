using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Profiles;
using NjordinSight.EntityModel;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
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
                throw new System.NotImplementedException();
            }

            /// <inheritdoc/>
            [TestMethod]
            public override void Entity_MapFrom_Dto_MappedProperties_AreEqual()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
