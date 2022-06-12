using System;
using System.Linq;
using System.Linq.Expressions;
using NjordFinance.ModelService;
using Microsoft.Extensions.Logging;
using Ichosoft.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NjordFinance.Exceptions;
using System.Collections.Generic;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelServiceTest<T> : IModelServiceTest<T>
        where T : class, new()
    {
        /// <inheritdoc/>
        [TestMethod]
        public abstract Task DeleteAsync_ValidModel_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task UpdateAsync_ValidModel_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            T model = await service.CreateAsync(CreateModelSuccessSample);

            using var context = CreateDbContext();

            var savedModel = GetModel(GetKey(model), IncludePaths);

            Assert.IsTrue(GetKey(model) > 0);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                savedModel, model));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task GetDefaultAsync_Returns_Single_Model()
        {
            var service = GetModelService();

            T model = await service.GetDefaultAsync();

            Assert.IsInstanceOfType(model, typeof(T));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task DeleteAsync_InvalidModel_ThrowsModelUpdateException()
        {
            var service = GetModelService();

            await Assert.ThrowsExceptionAsync<ModelUpdateException>(async () =>
            {
                await service.DeleteAsync(DeleteModelFailSample);
            });
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_KeyIsPresent_Returns_True()
        {
            T model = GetLast();

            var service = GetModelService();

            var result = service.ModelExists(id: GetKey(model));

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_ModelIsPresent_Returns_True()
        {
            T model = GetLast();

            // Use the servied to verify model existance.
            var service = GetModelService();

            var result = service.ModelExists(model);

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task ReadAsync_Returns_Single_Model()
        {
            var id = GetKey(GetLast());

            var service = GetModelService();

            var account = await service.ReadAsync(id);

            Assert.IsInstanceOfType(account, typeof(T));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectAllAsync_Returns_Model_List()
        {
            var service = GetModelService();

            var result = await service.SelectAllAsync();

            Assert.IsInstanceOfType(result, typeof(List<T>));
            Assert.IsTrue(result.Count > 0);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectWhereAsync_Returns_Model_Single()
        {
            T expected = GetLast(IncludePaths);

            var service = GetModelService();

            var observed = (await service.SelectWhereAysnc(
                predicate: GetKeySearchExpression(GetKey(expected)),
                maxCount: 1))
                .First();

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(expected, observed));
        }
    }

    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelServiceTest<T> : ModelServiceTestBase<T>
    {
        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model creation.
        /// </summary>
        protected abstract T CreateModelSuccessSample { get; }

        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model deletion.
        /// </summary>
        protected abstract T DeleteModelSuccessSample { get; }

        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing failed model deletion.
        /// </summary>
        protected abstract T DeleteModelFailSample { get; }
        
        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model 
        /// modification.
        /// </summary>
        protected abstract T UpdateModelSuccessSample { get; }

        /// <summary>
        /// Gets the collection of navigation paths to include in the test.
        /// </summary>
        protected virtual Expression<Func<T, object>>[] IncludePaths { get; } = 
            Array.Empty<Expression<Func<T, object>>>();

        /// <summary>
        /// Gets the <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected ILogger Logger => TestUtility.Logger;

        /// <summary>
        /// Creates the <see cref="IModelService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelService<T> BuildModelService<TService>()
        {
            return (IModelService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);
        }

        /// <summary>
        /// Creates a new instance implementing <see cref="IModelService{T}"/> for 
        /// testing.
        /// </summary>
        /// <returns>An instance implementing <see cref="IModelService{T}"/>.</returns>
        protected abstract IModelService<T> GetModelService();
    }
}
