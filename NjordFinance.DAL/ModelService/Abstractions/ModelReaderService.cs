using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
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

        /// <inheritdoc/>
        public void AddNavigationPath(Expression<Func<T, object>> navigationPath)
        {
            PathCollection.AddPath(navigationPath);
        }

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

            using var context = SharedContext?.Context ?? _contextFactory.CreateDbContext();

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

            IQueryable<T> queryable = context.Set<T>();

            // Loop through the navigation paths to include in the query.
            foreach (var path in PathCollection.Items)
            {
                queryable = queryable.Include(path);
            }

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

        private bool Exists(FinanceDbContext context, Expression<Func<T, bool>> predicate)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            return context.Set<T>().Any(predicate);
        }
    }

    /// <inheritdoc/>
    internal partial class ModelReaderService<T>
    {
        /// <summary>
        /// Gets the <see cref="NavigationPathCollection"/> instance for this service.
        /// </summary>
        private NavigationPathCollection PathCollection { get; } = new(pathLimit: 3);

        /// <summary>
        /// Gets or sets the expression for filtering results to the parent id for 
        /// this service.
        /// </summary>
        public Expression<Func<T, bool>> ParentExpression { get; internal init; }

        /// <summary>
        /// Represents a collection of <see cref="Expression{Delegate}"/> navigation paths.
        /// </summary>
        private class NavigationPathCollection
        {
            public Expression<Func<T, object>> this[int i] => _navigationPaths[i];

            /// <summary>
            /// The hard limit for <see cref="_pathLimit"/>.
            /// </summary>
            private const short _hardPathLimit = 5;

            /// <summary>
            /// The collection of navigation paths
            /// </summary>
            private readonly Expression<Func<T, object>>[] _navigationPaths;

            /// <summary>
            /// Creates a new <see cref="NavigationPathCollection"/> instance with the given limit.
            /// </summary>
            /// <param name="pathLimit">The maximum number of paths that can be included.</param>
            public NavigationPathCollection(short pathLimit)
            {
                short size = (pathLimit < _hardPathLimit) ? pathLimit : _hardPathLimit;
                _navigationPaths = new Expression<Func<T, object>>[size];
            }

            /// <summary>
            /// Gets the items in the collection.
            /// </summary>
            public IReadOnlyCollection<Expression<Func<T, object>>> Items
            {
                get { return _navigationPaths.Where(i => i is not null).ToArray(); }
            }

            /// <summary>
            /// Adds the navigation path to the collection.
            /// </summary>
            /// <param name="navigationPath">The path to add.</param>
            /// <exception cref="NotSupportedException">Occurs when the addition of the path would 
            /// cause the query to exceed its path limit.</exception>
            public void AddPath(Expression<Func<T, object>> navigationPath)
            {
                if (navigationPath is null)
                    return;

                var pathLimit = _navigationPaths.Length;

                if (Items.Count >= pathLimit)
                    throw new NotSupportedException(
                        string.Format(ExceptionString.ModelService_QueryComplexityNotSupported, pathLimit));

                _navigationPaths[Items.Count] = navigationPath;
            }
        }
    }
}
