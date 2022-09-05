﻿using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Exceptions;
using NjordFinance.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Variant <see cref="ModelServiceBase{T}"/> class that services read and search requests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed partial class ModelReaderService<T> : ModelServiceBase<T>, IModelReaderService<T>
        where T: class, new()
    {
        /// <summary>
        /// Creates a new <see cref="ModelReaderService{T}"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{NjordFinanceContext}"/> 
        /// for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this 
        /// service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        public ModelReaderService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(contextFactory, modelMetadata, logger)
        {
        }


        /// <summary>
        /// Base constructor for <see cref="ModelReaderService{T}"/> instances where a
        /// shared context is used.
        /// </summary>
        /// <param name="sharedContext"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        public ModelReaderService(
            ISharedContext sharedContext,
            IModelMetadataService metadataService,
            ILogger logger)
            : base(sharedContext, metadataService, logger)
        {
        }

        /// <summary>
        /// Gets the <see cref="Delegate"/> that configures an <see cref="IQueryable{T}"/> 
        /// for use as <see cref="IIncludableQueryable{TEntity, TProperty}" />.
        /// </summary>
        /// <remarks>If not initialized, the given <see cref="IQueryable{T}"/> is returned.</remarks>
        public Func<IQueryable<T>, IQueryable<T>> IncludeDelegate { get; init; } =
            (queryable) => queryable;

        /// <summary>
        /// Gets or sets the expression for filtering results to the parent id for 
        /// this service.
        /// </summary>
        public Expression<Func<T, bool>> ParentExpression { get; internal init; }

        /// <inheritdoc/>
        public bool ModelExists(int? id)
        {
            if (id is null)
                return false;

            var keySearch = GetKeySearchExpression(id ?? default);
            if (ParentExpression is not null)
                keySearch = ParentExpression.AndAlso(keySearch);

            if (HasSharedContext)
                return Exists(SharedContext.Context, keySearch);

            using var context = _contextFactory.CreateDbContext();

            return Exists(context, keySearch);
        }

        /// <inheritdoc/>
        public bool ModelExists(T model)
        {
            return ModelExists(GetKey(model));
        }

        /// <inheritdoc/>
        public async Task<T> ReadAsync(int? id)
        {
            if (id is null)
                return default;

            var keySearch = GetKeySearchExpression(id ?? default);

            if (ParentExpression is not null)
                keySearch = ParentExpression.AndAlso(keySearch);

            try
            {
                var result = (await SelectWhereAysnc(
                                        predicate: keySearch,
                                        maxCount: 1))
                            .FirstOrDefault();

                if (result is not null)
                    _logger.ModelServiceReadModel(
                        model: new
                        {
                            Type = typeof(T).Name,
                            Id = (int)id
                        });

                return result;
            }
            catch (Exception exception)
            {
                _logger.ModelServiceReadSingleFailed(
                    model: new
                    {
                        Type = typeof(T).Name,
                        Id = id
                    },
                    exception);

                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<List<T>> SelectAllAsync()
        {
            Expression<Func<T, bool>> predicate = x => true;

            if (ParentExpression is not null)
                predicate = ParentExpression.AndAlso(predicate);

            return await SelectWhereAysnc(
                predicate: predicate,
                maxCount: -1);
        }

        /// <inheritdoc/>
        public async Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            if (ParentExpression is not null)
                predicate = ParentExpression.AndAlso(predicate);

            if (HasSharedContext)
                return await ReadAsync(SharedContext.Context, predicate, maxCount);

            using var context = await _contextFactory.CreateDbContextAsync();

            return await ReadAsync(context, predicate, maxCount);
        }

        private async Task<List<T>> ReadAsync(
            FinanceDbContext context, Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            var searchGuid = Guid.NewGuid();

            _logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(T),
                predicate: predicate.Body,
                recordLimit: maxCount);

            IQueryable<T> queryable = IncludeDelegate(context.Set<T>());

            var result = await queryable
                            .Where(predicate)
                            .Take(maxCount)
                            .ToListAsync();

            _logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(T),
                resultCount: result?.Count ?? default);

            return result;
        }

        
    }
}
