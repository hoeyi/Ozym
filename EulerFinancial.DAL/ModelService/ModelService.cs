using EulerFinancial.Context;
using EulerFinancial.Exceptions;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The base class for servicing single CRUD requests for <typeparamref name="T"/> 
    /// models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract class ModelService<T> : IModelService<T>
        where T : class, new()
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
        /// Creates a new <typeparamref name="T"/> model service.
        /// </summary>
        /// <param name="context">The <see cref="EulerFinancialContext"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <param name="parentKey">The <typeparamref name="T"/> parent key type.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        protected ModelService(
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

        /// <inheritdoc/>
        public abstract Task<T> CreateAsync(T model);

        /// <inheritdoc/>
        public abstract Task<bool> DeleteAsync(T model);

        /// <inheritdoc/>
        public abstract Task<T> GetDefaultAsync();

        /// <inheritdoc/>
        public abstract bool ModelExists(int? id);

        /// <inheritdoc/>
        public abstract bool ModelExists(T model);

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
                logger.LogWarning(duc, duc.Message);
                throw new ModelUpdateException(duc.Message);
            }
            catch (DbUpdateException du)
            {
                logger.LogWarning(du, message: du.Message);
                throw new ModelUpdateException(du.InnerException.Message, du);
            }
        }

    }
}
