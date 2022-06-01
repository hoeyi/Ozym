using Microsoft.EntityFrameworkCore;
using NjordFinance.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Base class for model service test classes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelServiceTestBase<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="TKey"/> key value for the given 
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        protected TKey GetKey<TKey>(T model)
        {
            if (model is null)
                return default;

            Type modelType = typeof(T);
            Type keyType = typeof(TKey);

            var firstKey = modelType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() is not null
                && p.PropertyType == keyType);

            var keyValue = firstKey?.GetValue(model);

            if (keyValue is null) return default;

            return (TKey)firstKey.GetValue(model);
        }

        /// <summary>
        /// Gets the <see cref="int"/> key value for the given <typeparamref name="T"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The <see cref="int"/> key value.</returns>
        protected int GetKey(T model) => GetKey<int>(model);

        /// <summary>
        /// Gets an <see cref="Expression"/> used to find the model with the key equal to 
        /// the <typeparamref name="TKey"/> value.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        protected Expression<Func<T, bool>> GetKeySearchExpression<TKey>(TKey key)
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
        /// Utility method for creating new <see cref="FinanceDbContext"/> instances.
        /// </summary>
        /// <returns>A new <see cref="FinanceDbContext"/> instance.</returns>
        protected FinanceDbContext CreateDbContext() =>
            TestUtility.DbContextFactory.CreateDbContext();

        /// <summary>
        /// Gets the last item in the data store collection.
        /// </summary>
        /// <returns>The <typeparamref name="T"/> instance.</returns>
        protected T GetLast(params Expression<Func<T, object>>[] paths)
        {
            return GetLast(predicate: x => true, paths);
        }

        protected T GetLast(
            Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] paths)
        {
            if (paths.Length > 3)
                throw new InvalidOperationException($"'{paths}' parameter cannot exceed 3.");

            using var context = CreateDbContext();

            IQueryable<T> dbSet = context.Set<T>();

            foreach (var path in paths)
            {
                dbSet = dbSet.Include(path);
            }

            Expression<Func<T, bool>> defaultExpression = x => true;

            return dbSet.Where(predicate ?? defaultExpression).OrderBy(a => a).Last();
        }

        /// <summary>
        /// Creates a new <see cref="IModelService{T}"/> instance.
        /// </summary>
        /// <summary>
        /// Gets the model with the given <paramref name="id"/>, including the given 
        /// navigation paths.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        protected T GetModel(int id, params Expression<Func<T, object>>[] paths)
        {
            if (paths.Length > 3)
                throw new InvalidOperationException($"'{paths}' parameter cannot exceed 3.");

            using var context = CreateDbContext();

            IQueryable<T> dbSet = context.Set<T>();

            foreach (var path in paths)
            {
                dbSet = dbSet.Include(path);
            }

            return dbSet.FirstOrDefault(GetKeySearchExpression(id));
        }
    }
}
