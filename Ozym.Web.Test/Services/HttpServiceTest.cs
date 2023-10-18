using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Ozym.Web.Services;
using Ozym.DataTransfer.Common;

namespace Ozym.Web.Test.Services
{
    [TestClass]
    public class HttpServiceTest<T>
    {
        [TestMethod]
        public void HttpService_Init_Valid_Parameters_Yields_Instance()
        {
            // Arrange 
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockConfig = new Mock<IConfiguration>();
            var mockConfigSection = new Mock<IConfigurationSection>();

            mockConfig
                .Setup(x => x.GetSection(ApiOptions.ApiService))
                .Returns(mockConfigSection.Object);

            // Act 
            var httpService = new HttpService<T>(mockFactory.Object, mockConfig.Object);

            // Assert
            Assert.IsInstanceOfType(httpService, typeof(HttpService<T>));
        }
    }
}
