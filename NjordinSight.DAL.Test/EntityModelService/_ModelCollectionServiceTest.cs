using Ichosys.DataModel;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.Test.EntityModelService
{
    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> batch model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelCollectionServiceTest<T> : IModelCollectionServiceTest<T>
        where T : class, new()
    {
        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task GetDefault_Yields_Model_Instance()
        {
            var model = await GetModelService().GetDefaultAsync();

            Assert.IsInstanceOfType(model, typeof(T));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_KeyIsPresent_Returns_True()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            int id = GetKey(model);

            Assert.IsTrue(service.ModelExists(id));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_ModelIsPresent_Returns_True()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            Assert.IsTrue(service.ModelExists(model));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task ReadAsync_Returns_Single_Model()
        {
            var service = GetModelService();

            var model = GetLast(ParentExpression);

            var readModel = await service.ReadAsync(id: GetKey(model));

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(readModel, model));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectAllAsync_Returns_Model_List()
        {
            var service = GetModelService();

            var models = (await service.SelectAsync()).ToList();

            Assert.IsTrue(models.Count > 0);
            Assert.IsInstanceOfType(models, typeof(List<T>));

            var count = models.Count;
            var expcount = models.AsQueryable().Where(ParentExpression).Count();

            Assert.AreEqual(expcount, count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectWhereAsync_Returns_Model_ExpectedCollection()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            Expression<Func<T, bool>> expression;
            if(TestExpressions.TryGetValue(
                nameof(SelectWhereAsync_Returns_Model_ExpectedCollection),
                out Func<T, Expression<Func<T, bool>>> exp))
            {
                expression = exp.Invoke(model);
            }
            else
            {
                expression = GetKeySearchExpression(GetKey(model));
            }

            var models = (await service.SelectAsync(predicate: expression, pageSize: 1)).Item1;;

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }
    }

    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> batch model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelCollectionServiceTest<T> : ModelServiceTestBase<T>
    {
        /// <summary>
        /// Gets the <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected ILogger Logger => TestUtility.Logger;

        /// <summary>
        /// Gets the parent expression for the service being tested.
        /// </summary>
        protected abstract Expression<Func<T, bool>> ParentExpression { get; }

        protected IDictionary<string, Func<T,Expression<Func<T, bool>>>> TestExpressions { get; } =
            new Dictionary<string, Func<T, Expression<Func<T, bool>>>>();

        /// <summary>
        /// Creates the <see cref="IModelCollectionService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelCollectionService<T> BuildModelService<TService>() =>
            (IModelCollectionService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);

        /// <summary>
        /// Creates the <see cref="IModelCollectionService{T,TParent}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelCollectionService<T, TParent> BuildModelService<TService, TParent>() =>
            (IModelCollectionService<T, TParent>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);

        /// <summary>
        /// Creates a new instance implementing <see cref="IModelCollectionService{T}"/> for 
        /// testing.
        /// </summary>
        /// <returns>An instance implementing <see cref="IModelCollectionService{T}"/>.</returns>
        protected abstract IModelCollectionService<T> GetModelService();
    }
}
