using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NjordinSight.Api.Controllers;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common.Query;
using NjordinSight.EntityModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Api.Test.Unit
{
    /// <summary>
    /// Base class containing helper methods for testing <see cref="ApiController{TObject, TEntity}"/>.
    /// </summary>
    [TestCategory("Unit")]
    public partial class ApiControllerTest<T, TEntity> : IApiControllerTests<T>
        where TEntity : class, new()
    {
        /// <inheritdoc/>
        [TestMethod]
        public async Task Delete_With_Valid_Id_Return_NoContent()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(It.IsAny<TEntity>());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>())).ReturnsAsync(true);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(1) as NoContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status204NoContent, result.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Delete_With_Invalid_Id_Return_NotFound()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(false);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(1) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Delete_Failed_For_Model_Update_Error_Return_InternalError()
        {
            // Arrange
            var mocks = new Mocks();

            mocks.ModelService.Setup(x => x.ModelExists(It.IsAny<int>()))
                .Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<TEntity>());
            mocks.ModelService.Setup(x => x.DeleteAsync(
                It.IsAny<TEntity>())).Throws<ModelUpdateException>();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(It.IsAny<int>()); ;
            var errorResult = result as ObjectResult;

            // Assert
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, errorResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Delete_Failed_For_Server_Error_Return_InternalError()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(It.IsAny<int>()))
                .Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<TEntity>());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>()))
                .ReturnsAsync(false);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(It.IsAny<int>());
            var errorResult = result as ObjectResult;

            // Assert
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, errorResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Get_With_Invalid_Id_Return_NotFound()
        {
            // Arrange
            var mocks = new Mocks();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.GetAsync(It.IsAny<int>());

            var notFound = result.Result as NotFoundResult;

            // Assert
            Assert.IsNotNull(notFound);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFound.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Get_With_Valid_Id_Return_ActionResult()
        {
            // Arrange
            var mocks = new Mocks();
            var entity = Activator.CreateInstance<TEntity>();
            var model = Activator.CreateInstance<T>();

            mocks.ModelService.Setup(x => x.ReadAsync(It.IsAny<int>())).ReturnsAsync(entity);
            mocks.Mapper.Setup(x => x.Map<T>(entity)).Returns(model);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType<T>(result.Value);
        }

        /// <inheritdoc/>
        [TestMethod]
        [Obsolete("Retained for backwards compatability. Use PostSearchAsync instead.")]
        public async Task Get_With_Valid_QueryParams_In_Body_Return_ActionResult()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.SelectAsync(x => true, 1, 20).Result);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.GetAsync(queryParameter: new(), 1, 20);

            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsInstanceOfType<IEnumerable<T>>(okResult.Value);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task InitDefault_Return_ActionResult()
        {
            // Arrange
            var mocks = new Mocks();
            var model = Activator.CreateInstance<T>();
            var entity = Activator.CreateInstance<TEntity>();

            mocks.ModelService.Setup(x => x.GetDefaultAsync()).ReturnsAsync(entity);
            mocks.Mapper.Setup(x => x.Map<T>(entity)).Returns(model);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.InitDefaultAsync();

            // Assert
            Assert.IsInstanceOfType<T>(result.Value);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task PostSearch_With_Invalid_Parameter_Returns_BadRequest()
        {
            // Arrange
            var mocks = new Mocks();
            var parameter = new ParameterDto<T>();

            var apiController = InitTestController(mocks);
            
            // Act
            var result = await apiController.PostSearchAsync(
                queryParameter: parameter, pageNumber: It.IsAny<int>(), pageSize: It.IsAny<int>());

            var badRequest = result.Result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(StatusCodes.Status400BadRequest, badRequest.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task PostSearch_With_Valid_Parameter_Returns_OkObject_WithPaginationHeader()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService
                .Setup(x => x.SelectAsync(a => true, It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((It.IsAny<IEnumerable<TEntity>>(), It.IsAny<PaginationData>()));
            mocks.Mapper.Setup(x => x.Map<IEnumerable<T>>(It.IsAny<TEntity>()));

            var parameter = new ParameterDto<T>() { MemberName = "SomeMemberName" };

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PostSearchAsync(parameter, pageNumber: 1, pageSize: 20);

            var okResponse = result.Result as OkObjectResult;

            // Assert
            // Status is OK
            Assert.IsNotNull(okResponse);
            Assert.AreEqual(StatusCodes.Status200OK, okResponse.StatusCode);
            
            // Has object result
            Assert.IsInstanceOfType<IEnumerable<T>>(okResponse.Value);

            // Includes pagination header
            Assert.IsTrue(apiController.Response.Headers.ContainsKey("X-Pagination"));
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Post_Failed_For_Model_Update_Error_Returns_InternalError()
        {
            // Arrange
            var mocks = new Mocks();

            mocks.ModelService.Setup(x => x.CreateAsync(It.IsAny<TEntity>()))
                .Throws<ModelUpdateException>();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PostAsync(It.IsAny<T>());
            var errorResult = result.Result as ObjectResult;

            // Assert
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, errorResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Post_With_Invalid_Model_Return_BadRequest()
        {
            // Arrange
            var mocks = new Mocks();

            var apiController = InitTestController(mocks);
            apiController.ModelState.AddModelError("ModelStateForTest", "IsInvalid");

            // Act
            var result = await apiController.PostAsync(It.IsAny<T>());

            var badRequest = result.Result as BadRequestResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(StatusCodes.Status400BadRequest, badRequest.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Post_With_Valid_Model_Return_ActionResult()
        {
            // Arrange
            var mocks = new Mocks();
            int testId = 1;

            mocks.ModelService.Setup(x => x.GetKey<int>(It.IsAny<TEntity>())).Returns(testId);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PostAsync(It.IsAny<T>());

            var createdResult = result.Result as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
            Assert.IsTrue(createdResult.RouteValues?.ContainsKey("id") ?? false);
            Assert.AreEqual(testId, createdResult.RouteValues["id"]);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Put_Encounters_Concurrency_Error_ModelNoLongerExists_Returns_NotFound()
        {
            // Arrange
            var mocks = new Mocks();
            var model = Activator.CreateInstance<T>();
            var entity = Activator.CreateInstance<TEntity>();
            var id = 1;

            mocks.Mapper.Setup(x => x.Map<TEntity>(model)).Returns(entity);
            mocks.ModelService.Setup(x => x.GetKey<int>(entity)).Returns(id);
            mocks.ModelService.Setup(x => x.UpdateAsync(entity)).Throws<DbUpdateConcurrencyException>();
            mocks.ModelService.Setup(x => x.ModelExists(id)).Returns(false);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PutAsync(id, model);

            var notFound = result.Result as NotFoundResult;

            // Assert
            Assert.IsNotNull(notFound);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFound.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Put_Encounters_Concurrency_Error_ModelExists_Returns_Conflict()
        {
            // Arrange
            var mocks = new Mocks();
            var model = Activator.CreateInstance<T>();
            var entity = Activator.CreateInstance<TEntity>();
            var id = 1;

            mocks.Mapper.Setup(x => x.Map<TEntity>(model)).Returns(entity);
            mocks.ModelService.Setup(x => x.GetKey<int>(entity)).Returns(id);
            mocks.ModelService.Setup(x => x.UpdateAsync(entity)).Throws<DbUpdateConcurrencyException>();
            mocks.ModelService.Setup(x => x.ModelExists(id)).Returns(true);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PutAsync(id, model);

            var conflictResult = result.Result as ConflictResult;

            // Assert
            Assert.IsNotNull(conflictResult);
            Assert.AreEqual(StatusCodes.Status409Conflict, conflictResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Put_Failed_For_Model_Update_Error_Returns_InternalError()
        {
            // Arrange
            var mocks = new Mocks();
            var entity = Activator.CreateInstance<TEntity>();
            var model = Activator.CreateInstance<T>();

            var putId = It.IsAny<int>();
            var modelId = putId;

            mocks.Mapper.Setup(x => x.Map<TEntity>(model)).Returns(entity);
            mocks.ModelService.Setup(x => x.GetKey<int>(entity)).Returns(modelId);
            mocks.ModelService.Setup(x => x.UpdateAsync(entity)).Throws<ModelUpdateException>();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PutAsync(putId, model);
            var errorResult = result.Result as ObjectResult;

            // Assert
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, errorResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Put_With_Mismatched_Id_Return_BadRequest()
        {
            // Arrange
            var mocks = new Mocks();
            var entity = Activator.CreateInstance<TEntity>();
            var model = Activator.CreateInstance<T>();

            var putId = 1;
            var modelId = 0;

            mocks.Mapper.Setup(x => x.Map<TEntity>(model)).Returns(entity);
            mocks.ModelService.Setup(x => x.GetKey<int>(entity)).Returns(modelId);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PutAsync(putId, model);
            var badResult = result.Result as BadRequestResult;

            // Assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Put_With_Valid_Id_And_Model_Return_ActionResult()
        {
            // Arrange
            var mocks = new Mocks();
            var entity = Activator.CreateInstance<TEntity>();
            var model = Activator.CreateInstance<T>();

            var putId = It.IsAny<int>();
            var modelId = putId;

            mocks.Mapper.Setup(x => x.Map<TEntity>(model)).Returns(entity);
            mocks.ModelService.Setup(x => x.GetKey<int>(entity)).Returns(modelId);
            mocks.ModelService.Setup(x => x.UpdateAsync(entity)).ReturnsAsync(true);
            mocks.Mapper.Setup(x => x.Map<T>(entity)).Returns(model);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.PutAsync(putId, model);
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOfType<T>(okResult.Value);
        }
    }

    public partial class ApiControllerTest<T, TEntity>
    {
        /// <summary>
        /// Tests the <see cref="ApiController{TObject, TEntity}
        /// .ApiController(IExpressionBuilder, IMapper, IModelService{TEntity}, ILogger)"/>
        /// constructor with non-null arguments and expectes an instance.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Valid_Parameters_Returns_Instance()
        {
            // Arrange
            var mocks = new Mocks();

            // Act
            var apiController = 
            new ApiController<T, TEntity>(
                expressionBuilder: mocks.Expression.Object,
                mapper: mocks.Mapper.Object,
                modelService: mocks.ModelService.Object,
                logger: mocks.Logger.Object);

            // Assert
            Assert.IsInstanceOfType<ApiController<T, TEntity>>(apiController);
        }

        /// <summary>
        /// Tests the <see cref="ApiController{TObject, TEntity}
        /// .ApiController(IExpressionBuilder, IMapper, IModelService{TEntity}, ILogger)"/>
        /// constructor with null reference for the <see cref="IExpressionBuilder"/> and expects 
        /// a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_ExpressionBuilder_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks()
            {
                Mapper = new(),
                ModelService = new(),
                Logger = new()
            };

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ApiController<T, TEntity>(
                    expressionBuilder: null!,
                    mapper: mocks.Mapper.Object,
                    modelService: mocks.ModelService.Object,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ApiController{TObject, TEntity}
        /// .ApiController(IExpressionBuilder, IMapper, IModelService{TEntity}, ILogger)"/>
        /// constructor with null reference for the <see cref="IMapper"/> and expects 
        /// a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Mapper_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks()
            {
                Expression = new(),
                ModelService = new(),
                Logger = new()
            };

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ApiController<T, TEntity>(
                    expressionBuilder: mocks.Expression.Object,
                    mapper: null!,
                    modelService: mocks.ModelService.Object,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ApiController{TObject, TEntity}
        /// .ApiController(IExpressionBuilder, IMapper, IModelService{TEntity}, ILogger)"/>
        /// constructor with null reference for the <see cref="IModelService{T}"/> and expects 
        /// a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_ModelService_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks()
            {
                Expression = new(),
                Mapper = new(),
                Logger = new()
            };

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ApiController<T, TEntity>(
                    expressionBuilder: mocks.Expression.Object,
                    mapper: mocks.Mapper.Object,
                    modelService: null!,
                    logger: mocks.Logger.Object));
        }

        /// <summary>
        /// Tests the <see cref="ApiController{TObject, TEntity}
        /// .ApiController(IExpressionBuilder, IMapper, IModelService{TEntity}, ILogger)"/>
        /// constructor with null reference for the <see cref="ILogger"/> and expects 
        /// a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_When_Logger_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var mocks = new Mocks()
            {
                Expression = new(),
                Mapper = new(),
                ModelService = new()
            };

            // Act / Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new ApiController<T, TEntity>(
                    expressionBuilder: mocks.Expression.Object,
                    mapper: mocks.Mapper.Object,
                    modelService: mocks.ModelService.Object,
                    logger: null!));
        }
    }

    public partial class ApiControllerTest<T, TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IApiController{T}"/> using the given 
        /// <see cref="Mocks"/> record.
        /// </summary>
        /// <param name="mocks">Record containing the <see cref="Mock"/> objects.</param>
        /// <returns></returns>
        protected virtual ApiController<T, TEntity> InitTestController(Mocks mocks)
        {
            var controller = new ApiController<T, TEntity>(
                expressionBuilder: mocks.Expression.Object,
                mapper: mocks.Mapper.Object,
                modelService: mocks.ModelService.Object,
                logger: mocks.Logger.Object);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            return controller;
        }

        protected record Mocks
        {
            public Mock<IMapper> Mapper { get; init; } = new();

            public Mock<IExpressionBuilder> Expression { get; init; } = new();

            public Mock<ILogger> Logger { get; init; } = new();

            public Mock<IModelService<TEntity>> ModelService { get; init; } = new();
        }

        //protected record NullableMocks
        //{
        //    public Mock<IMapper> Mapper { get; init; } = default!;

        //    public Mock<IExpressionBuilder> Expression { get; init; } = default!;

        //    public Mock<ILogger> Logger { get; init; } = default!;

        //    public Mock<IModelService<TEntity>> ModelService { get; init; } = default!;
        //}
    }
}
