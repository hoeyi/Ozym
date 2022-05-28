﻿using Ichosoft.DataModel;
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
        public abstract void ModelExists_KeyIsPresent_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract void ModelExists_ModelIsPresent_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task ReadAsync_Returns_Single_Model();

        /// <inheritdoc/>
        [TestMethod]
        public virtual void RemovePendingAdd_IsDirty_Is_False()
        {
            var service = GetModelService();

            var model = GetModelService().GetDefaultAsync().Result;

            service.AddPendingSave(model);

            service.DeletePendingSave(model);

            Assert.IsFalse(service.IsDirty);
        }

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
        protected IModelBatchService<T> BuildModelService<TService>() =>
            (IModelBatchService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);

        /// <summary>
        /// Utility method for creating new <see cref="FinanceDbContext"/> instances.
        /// </summary>
        /// <returns>A new <see cref="FinanceDbContext"/> instance.</returns>
        protected FinanceDbContext CreateDbContext()
            => TestUtility.DbContextFactory.CreateDbContext();
    }
}