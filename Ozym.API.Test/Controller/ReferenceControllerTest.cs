using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozym.DataTransfer.Common;
using Ozym.Api.Controllers;
using System.Runtime.CompilerServices;
using Moq;
using Ichosys.DataModel.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Ozym.EntityModelService.Query;
using Microsoft.AspNetCore.Http;
using MathNet.Numerics.Statistics.Mcmc;

namespace Ozym.Api.Test.Controller
{
    /// <summary>
    /// Contains tests targetting the <see cref="ReferenceDataController"/> class.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class ReferenceControllerTest
    {
        /// <summary>
        /// Tests the <see cref="ReferenceDataController" /> constructor with non-null arguments 
        /// and expects an instance is created.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Valid_Parameters_Returns_Instance()
        {
            // Arrange
            var mocks = new Mocks();

            // Act
            var apiController = new ReferenceDataController(
                expressionBuilder: mocks.ExpressionBuilder.Object,
                queryService: mocks.QueryService.Object,
                mapper: mocks.Mapper.Object,
                logger: mocks.Logger.Object);

            // Assert
            Assert.IsInstanceOfType<ReferenceDataController>(apiController);
        }

        /// <summary>
        /// Tests the <see cref="ReferenceDataController" /> constructor with null reference for 
        /// the <see cref="IExpressionBuilder"/> argument and expects a 
        /// <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_ExpressionBuilder_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks();

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ReferenceDataController(
                    expressionBuilder: null!,
                    mapper: mocks.Mapper.Object,
                    queryService: mocks.QueryService.Object,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ReferenceDataController" /> constructor with null reference for 
        /// the <see cref="IMapper"/> argument and expects an <see cref="ArgumentNullException"/> 
        /// is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Mapper_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks();

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ReferenceDataController(
                    expressionBuilder: mocks.ExpressionBuilder.Object,
                    mapper: null!,
                    queryService: mocks.QueryService.Object,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ReferenceDataController" /> constructor with null reference for 
        /// the <see cref="IQueryService"/> argument and expects an <see cref="ArgumentNullException"/> 
        /// is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_QueryService_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks();

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ReferenceDataController(
                    expressionBuilder: mocks.ExpressionBuilder.Object,
                    mapper: mocks.Mapper.Object,
                    queryService: null!,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ReferenceDataController" /> constructor with null reference for 
        /// the <see cref="ILogger"/> argument and expects an <see cref="ArgumentNullException"/> 
        /// is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Logger_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks();

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ReferenceDataController(
                    expressionBuilder: mocks.ExpressionBuilder.Object,
                    mapper: mocks.Mapper.Object,
                    queryService: mocks.QueryService.Object,
                    logger: null!));
        }
    }

    public partial class ReferenceControllerTest
    {
        private static ReferenceDataController InitTestController(Mocks mocks)
        {
            var controller = new ReferenceDataController(
                expressionBuilder: mocks.ExpressionBuilder.Object,
                mapper: mocks.Mapper.Object,
                queryService: mocks.QueryService.Object,
                logger: mocks.Logger.Object);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            return controller;
        }

        private record Mocks
        {
            public Mock<IExpressionBuilder> ExpressionBuilder { get; set; } = new();

            public Mock<IMapper> Mapper { get; set; } = new();

            public Mock<ILogger> Logger { get; set; } = new();

            public Mock<IQueryService> QueryService { get; set; } = new();
        }
    }
}
