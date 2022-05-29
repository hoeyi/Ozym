﻿using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Exceptions;
using System;
using System.Threading.Tasks;
using NjordFinance.Context;
using NjordFinance.Logging;
using System.Linq.Expressions;
using NjordFinance.ModelMetadata;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Provides batch-write operations for <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal partial class ModelWriterBatchService<T>
        : ModelServiceBase<T>, IModelWriterBatchService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates a new <see cref="ModelWriterBatchService{T}"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{NjordFinanceContext}"/> 
        /// for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.
        /// </param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        public ModelWriterBatchService(
            IDbContextFactory<FinanceDbContext>
            contextFactory, IModelMetadataService modelMetadata,
            ILogger logger) :
                base(contextFactory, modelMetadata, logger)
        {
        }

        /// <summary>
        /// Base constructor for <see cref="ModelWriterBatchService{T}"/> instances where a
        /// shared context is used.
        /// </summary>
        /// <param name="sharedContext"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        public ModelWriterBatchService(
            ISharedContext sharedContext,
            IModelMetadataService metadataService,
            ILogger logger)
            : base(sharedContext, metadataService, logger)
        {
        }

        /// <inheritdoc/>
        public bool IsDirty => SharedContext.Context.ChangeTracker?.HasChanges() ?? false;

        /// <inheritdoc/>
        public bool AddPendingSave(T model)
        {
            if (!RequiredParentIdIsSet(model))
            {
                string modelDisplayName = _modelMetadata
                    .NounFor(typeof(T))?.GetSingular()?.ToLower();

                throw new InvalidOperationException(string.Format(
                    ExceptionString.ModelService_AddFailed_RequiredParentNotset,
                        modelDisplayName?.ToLower() ?? typeof(T).Name));

            }

            if (SharedContext?.Context is null)
                throw new InvalidOperationException(
                    ExceptionString.ModelBatchService_SharedContextNotSet);

            SharedContext.Context.Set<T>().Add(model);

            EntityState observedState = SharedContext.Context.Entry(model).State;

            bool result = observedState == EntityState.Added;

            object m = new
            {
                Type = typeof(T).Name,
                Id = GetKey(model) ?? default
            };

            if (result)
            {
                _logger.ModelServiceAddedPendingSave(m);
            }
            else
            {
                _logger.ModelServiceAddReturnedInvalidState(m, EntityState.Added, observedState);
            }
            return result;
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">The <see cref="ISharedContext"/> is 
        /// not set for this service.</exception>
        public bool DeletePendingSave(T model)
        {
            if (SharedContext?.Context is null)
                throw new InvalidOperationException(
                    ExceptionString.ModelBatchService_SharedContextNotSet);

            SharedContext.Context.Set<T>().Remove(model);

            EntityState observedState = SharedContext.Context.Entry(model).State;

            bool result = observedState == EntityState.Deleted;

            object m = new
            {
                Type = typeof(T).Name,
                Id = GetKey(model) ?? default
            };

            if (result)
            {
                _logger.ModelServiceDeletedPendingSave(m);
            }
            else
            {
                _logger.ModelServiceDeleteReturnedInvalidState(
                    m, EntityState.Deleted, observedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<T> GetDefaultAsync()
        {
            if (GetDefaultModelDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(GetDefaultModelDelegate)));

            return await Task.Run(() => GetDefaultModelDelegate.Invoke());
        }

        /// <inheritdoc/>
        public async Task<int> SaveChanges()
        {
            return await SharedContext.Context.SaveChangesAsync();
        }
    }

    /// <inheritdoc/>
    internal partial class ModelWriterBatchService<T>
    {
        /// <summary>
        /// Checks that a required parent identifier has been set for a given 
        /// <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> to check.</param>
        /// <returns>True, if the parent is set or not required, else false.</returns>
        private bool RequiredParentIdIsSet(T model)
        {
            if (ParentExpression is null)
                return true;

            var parentCheck = ParentExpression.Compile();
            return parentCheck.Invoke(model);
        }

        /// <summary>
        /// Gets or sets the expression for filtering results to the parent id for 
        /// this service.
        /// </summary>
        public Expression<Func<T, bool>> ParentExpression { get; internal init; }

        /// <summary>
        /// Delegate responsible for creating a default <typeparamref name="T"/> instance.
        /// </summary>
        public Func<T> GetDefaultModelDelegate { get; internal init; }
    }
}
