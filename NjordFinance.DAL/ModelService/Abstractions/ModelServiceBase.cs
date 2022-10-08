﻿using NjordFinance.Context;
using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Base class from which model service classes are derived.
    /// </summary>
    internal abstract class ModelServiceBase<T> : IModelBaseService<T>
        where T: class, new()
    {
        /// <summary>
        /// The shared context for this instance.
        /// </summary>
        protected readonly ISharedContext _sharedContext;

        /// <summary>
        /// The data context factory for this service.
        /// </summary>
        protected readonly IDbContextFactory<FinanceDbContext> _contextFactory;

        /// <summary>
        /// The <see cref="IModelMetadataService"/> instance for this service.
        /// </summary>
        protected readonly IModelMetadataService _modelMetadata;

        /// <summary>
        /// The <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Base constructor for <see cref="ModelServiceBase{T}"/>-dervied classes.
        /// </summary>
        /// <param name="contextFactory">The factory instance for constructing data contexts.</param>
        /// <param name="metadataService">An <see cref="IModelMetadataService"/> for the service to use.</param>
        /// <param name="logger">An <see cref="ILogger"/> for the service to use.</param>
        protected ModelServiceBase(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService metadataService,
            ILogger logger)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            if (metadataService is null)
                throw new ArgumentNullException(paramName: nameof(metadataService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _contextFactory = contextFactory;
            _modelMetadata = metadataService;
            _logger = logger;
        }

        /// <summary>
        /// Base constructor for <see cref="ModelBatchService{T}"/>-derived classes where a
        /// shared context is used.
        /// </summary>
        /// <param name="sharedContext"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        protected ModelServiceBase(
            ISharedContext sharedContext,
            IModelMetadataService metadataService,
            ILogger logger)
        {
            _sharedContext = sharedContext;
            _modelMetadata = metadataService;
            _logger = logger;
        }

        ~ModelServiceBase()
        {
            SharedContext?.Context?.Dispose();
        }

        public bool HasSharedContext
        {
            get { return SharedContext is not null; }
        }

        /// <inheritdoc/>
        public int? GetKey(T model)
        {
            int key = GetKey<int>(model);

            if (key == default) return null;
            else return key;
        }

        /// <summary>
        /// Gets or sets the shared context for this service instance.
        /// </summary>
        protected ISharedContext SharedContext
        {
            get { return _sharedContext; }
        }

        /// <summary>
        /// Gets the <typeparamref name="TKey"/> key value for the given 
        /// <typeparamref name="T"/>.
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

            var keyValue = firstKey?.GetValue(model);

            if (keyValue is null) return default;

            return (TKey)firstKey.GetValue(model);
        }

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

        protected static bool Exists(FinanceDbContext context, Expression<Func<T, bool>> predicate)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            return context.Set<T>().Any(predicate);
        }
    }
}
