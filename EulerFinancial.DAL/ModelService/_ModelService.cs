using EulerFinancial.Context;
using EulerFinancial.Exceptions;
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
using EulerFinancial.Logging;

namespace EulerFinancial.ModelService
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
        /// <param name="contextFactory">The <see cref="IDbContextFactory{EulerFinancialContext}"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        protected ModelService(
            IDbContextFactory<EulerFinancialContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public abstract Task<T> CreateAsync(T model);

        /// <inheritdoc/>
        public abstract Task<bool> DeleteAsync(T model);

        /// <inheritdoc/>
        public abstract Task<T> GetDefaultAsync();

        /// <inheritdoc/>
        public abstract Task<bool> UpdateAsync(T model);

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

    public abstract partial class ModelService<T>
    {
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

            return (TKey)firstKey.GetValue(model);
        }

        /// <summary>
        /// Invokes the given data store modification method.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="writeDelegate">The method adding, updating, or deleting a method.</param>
        /// <returns>A task representing an asynchronous write operation. The <typeparamref name="TResult"/>
        ///  is taken from the passed delegate.</returns>
        /// <exception cref="ModelUpdateException">An error occured when writing to the data store. 
        /// This typcially represents an unhandled concurrency or schema constraint exception.</exception>
        protected async Task<TResult> DoWriteOperationAsync<TResult>(
            Func<Task<TResult>> writeDelegate)
        {
            try
            {
                return await writeDelegate.Invoke();
            }
            catch (DbUpdateConcurrencyException duc)
            {
                _logger.LogWarning(duc, duc.Message);
                throw new ModelUpdateException(duc.Message);
            }
            catch (DbUpdateException du)
            {
                _logger.LogWarning(du, message: du.Message);
                throw new ModelUpdateException(du.InnerException.Message, du);
            }
        }
        
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
    }
}
