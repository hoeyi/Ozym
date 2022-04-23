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

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The base class for servicing single CRUD requests for <typeparamref name="T"/> 
    /// models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract class ModelService<T> : ModelServiceBase, IModelService<T>
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
        public abstract Task<T> ReadAsync(int? id);

        /// <inheritdoc/>
        public abstract Task<List<T>> SelectAllAsync();

        /// <inheritdoc/>
        public abstract Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);

        /// <inheritdoc/>
        public abstract Task<bool> UpdateAsync(T model);

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

        private static Expression<Func<T, bool>> GetKeySearchExpression<TKey>(TKey key)
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
        /// Extracts the value of a 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        private static TKey GetKey<TKey>(T model)
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
    }
}
