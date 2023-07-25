using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NjordinSight.EntityModelService;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Delete_Failed_For_Client_Error_Return_Conflict()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(It.IsAny<TEntity>());
            mocks.ModelService.Setup(x => x.DeleteAsync(
                It.IsAny<TEntity>())).Throws<ModelUpdateException>();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(1) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status409Conflict, result.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Delete_Failed_For_Server_Error_Return_InternalError()
        {
            // Arrange
            var mocks = new Mocks();
            mocks.ModelService.Setup(x => x.ModelExists(1)).Returns(true);
            mocks.ModelService.Setup(x => x.ReadAsync(1)).ReturnsAsync(It.IsAny<TEntity>());
            mocks.ModelService.Setup(x => x.DeleteAsync(It.IsAny<TEntity>())).ReturnsAsync(false);

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.DeleteAsync(1) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        /// <inheritdoc/>
        [TestMethod]
        public async Task Get_With_Invalid_Id_Return_NotFound()
        {
            // Arrange
            var mocks = new Mocks();

            var apiController = InitTestController(mocks);

            // Act
            var result = await apiController.GetAsync(1);

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
        public Task PostSearch_With_Invalid_QueryParams_Return_BadRequest()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task PostSearch_With_Valid_QueryParams_Return_ActionResult()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task Post_With_Invalid_Model_Return_BadRequest()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task Post_With_Valid_Model_Return_ActionResult()
        {
            throw new NotImplementedException();
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
        public Task Put_With_Invalid_Id_Return_NotFound()
        {
            throw new NotImplementedException();
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
        public Task Put_With_Valid_Id_And_Model_Return_ActionResult()
        {
            throw new NotImplementedException();
        }

    }
}
