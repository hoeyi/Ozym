using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NjordinSight.Api.Controllers;
using Ichosys.DataModel.Expressions;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModelService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NjordinSight.Api.Test.Unit
{
    /// <summary>
    /// Base class containing helper methods for testing <see cref="ApiController{TObject, TEntity}"/>.
    /// </summary>
    [TestCategory("Unit")]
    public partial class ApiControllerTest<T, TEntity>
        where TEntity : class, new()
    {
        [TestMethod]
        public async Task GetAsync_DefaultParameters_ReturnsOkObjectResponse()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.SelectAsync(x => true, 1, 20).Result);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.GetAsync(queryParameter: new());

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<T>>));
        }

        [TestMethod]
        public async Task DeleteAsync_ValidId_ReturnsNoContentResponse()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(NewEntity());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>())).ReturnsAsync(true);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteAsync_InvalidId_ReturnsNotFoundResponse()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(0)).Returns(false);

            var apiContoller = InitTestController(mocks);

            // Act 
            var result = await apiContoller.DeleteAsync(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteAsync_DeleteFailure_NoException_ReturnsInternalServerErrorResponse()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(NewEntity());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>())).ReturnsAsync(false);

            var apiContoller = InitTestController(mocks);

            // Act
            var result = await apiContoller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual(expected: 500, actual: ((ObjectResult)result).StatusCode);
        }

        [TestMethod]
        public async Task DeleteAsync_DeleteFailure_WithException_ReturnsInternalServerErrorResponse()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(NewEntity());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>())).ThrowsAsync(new ModelUpdateException());

            var apiContoller = InitTestController(mocks);

            // Act
            var result = await apiContoller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual(expected: 409, actual: ((ObjectResult)result).StatusCode);
        }
    }

    public partial class ApiControllerTest<T, TEntity>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AccountsControllerTest"/> using the given 
        /// <see cref="Mocks"/> record.
        /// </summary>
        /// <param name="mocks">Record containing the <see cref="Mock"/> objects.</param>
        /// <returns></returns>
        protected virtual IApiController<T> InitTestController(Mocks mocks)
        {
            var controller = new ApiController<T, TEntity>(
                expressionBuilder: mocks.Expression.Object,
                mapper: mocks.Mapper.Object,
                modelService: mocks.ModelService.Object,
                logger: mocks.Logger.Object);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            return controller;
        }

        private static TEntity NewEntity()
        {
            var instance = (TEntity)Activator.CreateInstance(typeof(TEntity))!;

            if (instance is null)
                throw new InvalidOperationException();

            else
                return instance;
        }

        protected record Mocks
        {
            public Mock<IMapper> Mapper { get; } = new Mock<IMapper>();

            public Mock<IExpressionBuilder> Expression { get; } = new Mock<IExpressionBuilder>();

            public Mock<ILogger> Logger { get; } = new Mock<ILogger>();

            public Mock<IModelService<TEntity>> ModelService { get; } =
                new Mock<IModelService<TEntity>>();
        }
    }
}
