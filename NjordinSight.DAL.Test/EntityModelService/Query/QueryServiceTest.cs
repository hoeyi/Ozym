using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Context;
using Ichosys.DataModel;
using AutoMapper;
using System.Diagnostics;
using NjordinSight.EntityModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.Test.EntityModelService.Query
{
    [TestClass]
    [TestCategory("Unit")]
    public class QueryServiceTest
    {
        [TestMethod]
        public void CreateEnumerableDisplayMap_Returns_Expected_Count()
        {
            // Arrange
            var mocks = new Mocks();
            var queryService = new QueryService(
                contextFactory: mocks.ContextFactory.Object,
                mapper: mocks.Mapper.Object);

            // Act
            var enumResults = queryService.BuiltIn
                .GetMarketIndexPriceCodeDisplayMap(null);

            // Assert
            Assert.AreEqual(2, enumResults.Count);
        }

        private record Mocks
        {
            public Mock<IDbContextFactory<FinanceDbContext>> ContextFactory { get; init; } = new();

            public Mock<IMapper> Mapper { get; init; } = new();
        }
    }
}