using AutoMapper;
using Ozym.DataTransfer.Common;
using Ozym.DataTransfer.Common.Query;
using Ozym.DataTransfer.Profiles;
using Ozym.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Ichosys.DataModel.Expressions;
using Moq;
using System.Net.Http.Headers;

namespace Ozym.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Class for unit test methods targeting <see cref="ParameterProfile"/>.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class ParameterProfileTest : IProfileTest
    {
        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance to be tested.
        /// </summary>
        private static IConfigurationProvider TestConfiguration { get; } =
            new MapperConfiguration(x =>
            {
                x.AddProfile<ParameterProfile>();
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

    public partial class ParameterProfileTest
    {
        [TestClass]
        [TestCategory("Unit")]
        public class ParameterMapping
        {
            private IMapper Mapper { get; } = new Mapper(TestConfiguration);

            /// <inheritdoc/>
            [TestMethod]
            public void Dto_MapFrom_IQueryParameter_MappedProperties_AreEqual()
            {
                // Arrange
                var mock = new Mock<IQueryParameter<AccountDto>>();
                mock.SetupGet(x => x.MemberName).Returns(nameof(AccountDto.Id));
                mock.SetupGet(x => x.Operator).Returns(ComparisonOperator.EqualTo);
                mock.SetupGet(x => x.Value).Returns("1");

                // Act
                var dto = Mapper.Map<ParameterDto<AccountDto>>(mock.Object);

                // Assert
                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(dto, typeof(ParameterDto<AccountDto>));

                // Fact: All property values match.
                Assert.AreEqual(mock.Object.MemberName, dto.MemberName);
                Assert.AreEqual(mock.Object.Operator, dto.Operator);
                Assert.AreEqual(mock.Object.Value, dto.Value);
            }

            /// <inheritdoc/>
            [TestMethod]
            public void IQueryParameter_MapFrom_Dto_MappedProperties_AreEqual()
            {
                // Arrange
                var dto = new ParameterDto<AccountDto>()
                {
                    MemberName = nameof(AccountDto.Id),
                    Operator = ComparisonOperator.EqualTo,
                    Value = "1"
                };

                // Act
                var iQueryParam = Mapper.Map<ParameterDto<AccountDto>>(dto);

                // Assert
                // Assert
                // Fact: Instance is created.
                Assert.IsInstanceOfType(iQueryParam, typeof(ParameterDto<AccountDto>));

                // Fact: All property values match.
                Assert.AreEqual(dto.MemberName, iQueryParam.MemberName);
                Assert.AreEqual(dto.Operator, iQueryParam.Operator);
                Assert.AreEqual(dto.Value, iQueryParam.Value);
            }
        }
    }
}
