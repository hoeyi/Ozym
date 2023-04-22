using Ichosys.DataModel;
using Microsoft.Extensions.Logging;
using NjordFinance.ModelService;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> batch model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelBatchServiceTest<T> : IModelBatchServiceTest<T>
        where T : class, new()
    {
        /// <inheritdoc/>
        [TestMethod]
        public virtual void AddPendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = GetModelService().GetDefaultAsync().Result;

            service.AddPendingSave(model);

            Assert.IsTrue(service.IsDirty);
        }

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
        public virtual void DeletePendingAdd_IsDirty_Is_False()
        {
            var service = GetModelService();

            var model = GetModelService().GetDefaultAsync().Result;

            service.AddPendingSave(model);

            service.DeletePendingSave(model);

            Assert.IsFalse(service.IsDirty);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void DeletePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = GetLast(ParentExpression);

            service.DeletePendingSave(model);

            Assert.IsTrue(service.IsDirty);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectAllAsync_Returns_Model_List()
        {
            var service = GetModelService();

            var models = await service.SelectAllAsync();

            Assert.IsTrue(models.Count > 0);
            Assert.IsInstanceOfType(models, typeof(List<T>));

            var count = models.Count();
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

            var models = await service.SelectWhereAysnc(predicate: expression, maxCount: 1);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        /// <inheritdoc/>
        [TestMethod]
        public abstract void UpdatePendingSave_IsDirty_Is_True();
    }

    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> batch model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelBatchServiceTest<T> : ModelServiceTestBase<T>
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
        /// Creates the <see cref="IModelBatchService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelBatchService<T> BuildModelService<TService>() =>
            (IModelBatchService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);

        /// <summary>
        /// Creates the <see cref="IModelBatchService{T,TParent}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelBatchService<T, TParent> BuildModelService<TService, TParent>() =>
            (IModelBatchService<T, TParent>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);

        /// <summary>
        /// Creates a new instance implementing <see cref="IModelBatchService{T}"/> for 
        /// testing.
        /// </summary>
        /// <returns>An instance implementing <see cref="IModelBatchService{T}"/>.</returns>
        protected abstract IModelBatchService<T> GetModelService();
    }
}
