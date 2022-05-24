using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.ModelService;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public abstract void AddPendingSave_IsDirty_Is_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task GetDefault_Yields_Model_Instance();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void ModelExists_KeyIsPresent_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void ModelExists_ModelIsPresent_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task ReadAsync_Returns_Single_Model();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void RemovePendingAdd_IsDirty_Is_False();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void RemovePendingSave_IsDirty_Is_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task SelectAllAsync_Returns_Model_List();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task SelectWhereAsync_Returns_Model_ExpectedCollection();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void UpdatePendingSave_IsDirty_Is_True();
    }

    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> batch model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelBatchServiceTest<T>
    {
        /// <summary>
        /// Gets the collection of <typeparamref name="T"/> models to add to the 
        /// database for test purposes.
        /// </summary>
        protected abstract IReadOnlyDictionary<string, T> TestModels { get; }

        /// <summary>
        /// Executes set up action including seeding test samples to a shared context.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Executes clean-up action including clearing test cases from a shared context.
        /// </summary>
        public abstract void CleanUp();

        /// <summary>
        /// Gets the <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected ILogger Logger => TestUtility.Logger;

        /// <summary>
        /// Creates a new instance implementing <see cref="IModelBatchService{T}"/> for 
        /// testing.
        /// </summary>
        /// <returns>An instance implementing <see cref="IModelBatchService{T}"/>.</returns>
        protected abstract IModelBatchService<T> GetModelService();

        /// <summary>
        /// Creates the <see cref="IModelBatchService{T}"/> to be tested.
        /// </summary>
        /// <returns>An instance implementing <see cref="IModelBatchService{T}"/>.</returns>
        protected IModelBatchService<T> BuildModelService<TService>()
        {
            return (IModelBatchService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);
        }

        /// <summary>
        /// Utility method for creating new <see cref="FinanceDbContext"/> instances.
        /// </summary>
        /// <returns>A new <see cref="FinanceDbContext"/> instance.</returns>
        protected FinanceDbContext CreateDbContext()
        {
            return TestUtility.DbContextFactory.CreateDbContext();
        }

        /// <summary>
        /// Seeds the given <typeparamref name="T"/> models.
        /// </summary>
        /// <param name="models"></param>
        protected void SeedTestData(params T[] models)
        {
            using var context = CreateDbContext();

            context.AddRange(models);

            context.SaveChanges();
        }
    }
}
