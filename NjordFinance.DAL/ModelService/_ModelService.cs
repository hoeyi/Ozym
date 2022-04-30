using NjordFinance.Context;
using NjordFinance.Exceptions;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NjordFinance.Logging;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The base class for servicing single CRUD requests for <typeparamref name="T"/> 
    /// models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelService<T> : ModelServiceBase, IModelService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates a new <see cref="ModelService{T}"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{NjordFinanceContext}"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        protected ModelService(
            IDbContextFactory<EulerDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public virtual async Task<T> CreateAsync(T model)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var logModel = new
            {
                Type = typeof(T).Name,
                Id = GetKey<int>(model),
                Guid = GetKey<Guid>(model)
            };

            DbActionResult<T> createAction = await DoWriteOperationAsync(CreateDelegate, model);
            if (createAction.Successful)
            {
                _logger.ModelServiceCreatedModel(logModel);
                return createAction.Result;
            }
            else
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<bool> DeleteAsync(T model)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var logModel = new
            {
                Type = typeof(T).Name,
                Id = GetKey<int>(model),
                Guid = GetKey<Guid>(model)
            };

            DbActionResult<bool> deleteAction = await DoWriteOperationAsync(DeleteDelegate, model);
            if (deleteAction.Successful)
            {
                _logger.ModelServiceDeletedModel(logModel);
                return deleteAction.Result;
            }
            else
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public abstract Task<T> GetDefaultAsync();

        /// <inheritdoc/>
        public virtual async Task<bool> UpdateAsync(T model)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var logModel = new
            {
                Type = typeof(T).Name,
                Id = GetKey<int>(model),
                Guid = GetKey<Guid>(model)
            };

            DbActionResult<bool> udpateAction = await DoWriteOperationAsync(UpdateDelegate, model);
            if (udpateAction.Successful)
            {
                _logger.ModelServiceUpdatedModel(logModel);
                return udpateAction.Result;
            }
            else
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public virtual bool ModelExists(int? id)
        {
            if (id is null)
                return false;

            var keySearch = GetKeySearchExpression(id ?? default);

            using var context = _contextFactory.CreateDbContext();

            return context.Set<T>().Any(keySearch);
        }

        /// <inheritdoc/>
        public virtual bool ModelExists(T model)
        {
            int id = GetKey<int>(model);

            return ModelExists(id);
        }

        /// <inheritdoc/>
        public virtual async Task<T> ReadAsync(int? id)
        {
            if (id is null)
                return default;

            int idInt = id ?? default;
            var keySearch = GetKeySearchExpression(idInt);

            using var context = _contextFactory.CreateDbContext();

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
                            Id = idInt
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
        public virtual async Task<List<T>> SelectAllAsync()
        {
            return await SelectWhereAysnc(
                predicate: x => true,
                maxCount: -1);
        }

        /// <inheritdoc/>
        public virtual async Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            var searchGuid = Guid.NewGuid();

            _logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(T),
                predicate: predicate.Body,
                recordLimit: maxCount);

            using var context = _contextFactory.CreateDbContext();

            IQueryable<T> queryable = context.Set<T>();

            // Loop through the navigation paths to include in the query.
            foreach(var path in PathCollection.Items)
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
    }

    /// <inheritdoc/>
    public abstract partial class ModelService<T>
    {
        /// <summary>
        /// Represents the result of an action against a data store.
        /// </summary>
        /// <typeparam name="TResult">The action result type.</typeparam>
        protected struct DbActionResult<TResult>
        {
            public DbActionResult(TResult result, bool successful)
            {
                Result = result;
                Successful = successful;
            }

            /// <summary>
            /// Gets the result of the action.
            /// </summary>
            public TResult Result { get; init; }

            /// <summary>
            /// Gets whether the action was successful.
            /// </summary>
            public bool Successful { get; init; }

        }

        /// <summary>
        /// Gets the <see cref="NavigationPathCollection"/> instance for this service.
        /// </summary>
        protected NavigationPathCollection PathCollection { get; init; } = new(pathLimit: 3);

        /// <summary>
        /// Gets an <see cref="Expression"/> used to find the model with the key equal to 
        /// the <typeparamref name="TKey"/> value.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        protected static Expression<Func<T, bool>> GetKeySearchExpression<TKey>(TKey key)
        {
            // Get the first property info that matches the expected type and has 
            // the key attribute applied.

            Type modelType = typeof(T);
            Type keyType = typeof(TKey);

            var firstKey = modelType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() is not null
                && p.PropertyType == keyType);

            if (firstKey is default(PropertyInfo))
                throw new NotSupportedException(message: nameof(GetKeySearchExpression));

            // Construct the base elements of the left-hand side of the expression.
            ParameterExpression parameterExpression = Expression.Parameter(modelType, "x");
            Expression expressionLeft = Expression.Property(parameterExpression, propertyName: firstKey.Name);
            Expression expressionRight = Expression.Constant(key, keyType);

            Expression expression = Expression.Equal(expressionLeft, expressionRight);

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
        }

        /// <summary>
        /// Gets the <typeparamref name="TKey"/> key value for the given 
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        protected static TKey GetKey<TKey>(T model)
        {
            if (model is null)
                return default;

            Type modelType = typeof(T);
            Type keyType = typeof(TKey);

            var firstKey = modelType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() is not null
                && p.PropertyType == keyType);

            if (firstKey is null) return default;

            return (TKey)firstKey.GetValue(model);
        }

        ///// <summary>
        ///// Invokes the given data store modification method.
        ///// </summary>
        ///// <typeparam name="TResult"></typeparam>
        ///// <param name="writeDelegate">The method adding, updating, or deleting a method.</param>
        ///// <returns>A task representing an asynchronous write operation. The <typeparamref name="TResult"/>
        /////  is taken from the passed delegate.</returns>
        ///// <exception cref="ModelUpdateException">An error occured when writing to the data store. 
        ///// This typcially represents an unhandled concurrency or schema constraint exception.</exception>
        ///// 

        protected abstract Func<EulerDbContext, T, Task<DbActionResult<T>>> CreateDelegate { get; }
        
        protected abstract Func<EulerDbContext, T, Task<DbActionResult<bool>>> DeleteDelegate { get; }

        protected abstract Func<EulerDbContext, T, Task<DbActionResult<bool>>> UpdateDelegate { get; }

        /// <summary>
        /// Represents a collection of <see cref="Expression{Delegate}"/> navigation paths.
        /// </summary>
        protected class NavigationPathCollection
        {
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

        /// <summary>
        /// Invokes the given delegate to write data to the data store.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="writeDelegate">The delegate that will perform the write operations to the 
        /// <see cref="EulerDbContext"/>.</param>
        /// <param name="model">The <typeparamref name="T"/> model which is being written.</param>
        /// <returns>A <typeparamref name="TResult"/> representing the outcome of the write operation.</returns>
        /// <exception cref="ModelUpdateException"></exception>
        private async Task<DbActionResult<TResult>> DoWriteOperationAsync<TResult>(
            Func<EulerDbContext, T, Task<DbActionResult<TResult>>> writeDelegate,
            T model)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();

                return await writeDelegate.Invoke(context, model);
            }
            catch (DbUpdateConcurrencyException duc)
            {
                _logger.LogWarning(duc, duc.Message);
                throw new ModelUpdateException(duc.Message);
            }
            catch (DbUpdateException du)
            {
                _logger.ModelServiceSaveChangesFailed(du);
                throw new ModelUpdateException(du.InnerException.Message, du);
            }
        }
    }
}
