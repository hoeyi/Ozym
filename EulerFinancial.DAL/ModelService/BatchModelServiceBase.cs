using EulerFinancial.Context;
using EulerFinancial.Resources;
using Ichosoft.DataModel;
using Ichosoft.Extensions.Common.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The base class for servicing batch CRUD requests for <typeparamref name="T"/> 
    /// models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <typeparam name="TParentKey">The model's parent key type.</typeparam>
    public abstract class BatchModelServiceBase<T, TParentKey> : IBatchModelService<T, TParentKey>
        where T : class, new()
        where TParentKey : struct
    {
        /// <summary>
        /// The <see cref="EulerFinancialContext"/> instance for this service.
        /// </summary>
        protected readonly EulerFinancialContext context;

        /// <summary>
        /// The <see cref="IModelMetadataService"/> instance for this service.
        /// </summary>
        protected readonly IModelMetadataService modelMetadata;

        /// <summary>
        /// The <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// The unique key that represents the parent of objects worked using this service.
        /// </summary>
        private TParentKey? parentKey;

        /// <summary>
        /// Creates a new <typeparamref name="T"/> batch model service.
        /// </summary>
        /// <param name="context">The <see cref="EulerFinancialContext"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <param name="parentKey">The <typeparamref name="T"/> parent key type.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        protected BatchModelServiceBase(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            if (modelMetadata is null)
                throw new ArgumentNullException(paramName: nameof(modelMetadata));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            this.context = context;
            this.modelMetadata = modelMetadata;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the parent key for models worked using this service.
        /// </summary>
        /// <remarks>Calls to this property will throw an exception if the parent key was not 
        /// provided to the <see cref="BatchModelServiceBase{T, TParentKey}"/> constructor. 
        /// The key will only by set if the current value is null. This ensures inconsistent 
        /// parent keys are not passed to the same service.</remarks>
        protected TParentKey ParentKey
        {
            get
            {
                if (parentKey is null)
                {
                    Exception e = new InvalidOperationException(string.Format(
                        ExceptionString.ModelService_ParentKeyNotSet, this));

                    logger.LogError(
                        message: ExceptionString.ModelService_ParentKeyNotSet
                            .ConvertToLogTemplate("Service"),
                        args: this);

                    throw e;
                }
                else
                    return (TParentKey)parentKey;
            }
            set
            {
                if (parentKey is null)
                    parentKey = value; return;
            }
        }

        /// <inheritdoc/>
        public abstract bool Add(T model, TParentKey parentKey);

        /// <inheritdoc/>
        public abstract bool Delete(T model, TParentKey parentKey);

        /// <inheritdoc/>
        public abstract Task<int> SaveChanges();

        /// <inheritdoc/>
        public abstract Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, TParentKey parentKey, int maxCount = 0);
    }
}
