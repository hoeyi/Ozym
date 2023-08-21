using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.DataTransfer;
using NjordinSight.EntityModel.Context;
using NjordinSight.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.Abstractions
{
    /// <summary>
    /// Variant <see cref="ModelServiceBase{T}"/> class that services read and search requests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal partial class ModelReaderService<T> : ModelServiceBase<T>, IModelReaderService<T>
        where T: class, new()
    {
        /// <summary>
        /// Creates a new <see cref="ModelReaderService{T}"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{T}"/> 
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

            using var context = ContextFactory.CreateDbContext();

            return Exists(context, keySearch);
        }

        /// <inheritdoc/>
        public bool ModelExists(T model)
        {
            return ModelExists(GetKey<int>(model));
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
                var result = (await SelectAsync(predicate: keySearch, pageSize: 1)).Item1
                            .FirstOrDefault();

                if (result is not null)
                    Logger.ModelServiceReadModel(
                        model: new
                        {
                            Type = typeof(T).Name,
                            Id = (int)id
                        });

                return result;
            }
            catch (Exception exception)
            {
                Logger.ModelServiceReadSingleFailed(
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
        public async Task<IEnumerable<T>> SelectAsync()
        {
            Expression<Func<T, bool>> predicate = x => true;

            if (ParentExpression is not null)
                predicate = ParentExpression.AndAlso(predicate);

            using var context = await ContextFactory.CreateDbContextAsync();

            return (await ReadAsync(context, predicate, pageSize: int.MaxValue)).Item1;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SelectAsync(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20)
        {
            int limitPageSize = BusinessMath.Clamp(pageSize, 0, 100);

            if (ParentExpression is not null)
                predicate = ParentExpression.AndAlso(predicate);

            using var context = await ContextFactory.CreateDbContextAsync();

            return await ReadAsync(context, predicate, pageNumber, pageSize: limitPageSize);
        }

        private async Task<(IEnumerable<T>, PaginationData)> ReadAsync(
            FinanceDbContext context, 
            Expression<Func<T, bool>> predicate,
            int pageNumber = 1, 
            int pageSize = 20)
        {
            var searchGuid = Guid.NewGuid();

            Logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(T),
                predicate: predicate.Body,
                recordLimit: pageSize);

            IQueryable<T> queryable = IncludeDelegate(context.Set<T>()).Where(predicate);

            PaginationData pageData = new()
            {
                ItemCount = await queryable.CountAsync(),
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            // TODO: This needs an ORDER BY clause in order to generate consistent results.
            var result = await queryable
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            Logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(T),
                resultCount: result?.Count ?? default);

            return (result, pageData);
        }
    }

    
}
