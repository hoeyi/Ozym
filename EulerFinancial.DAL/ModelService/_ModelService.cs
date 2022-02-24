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
    public abstract class ModelService<T> : ModelServiceBase, IModelService<T>
        where T : class, new()
    {


        /// <summary>
        /// Creates a new <typeparamref name="T"/> service.
        /// </summary>
        /// <param name="context">The <see cref="EulerFinancialContext"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <param name="parentKey">The <typeparamref name="T"/> parent key type.</param>
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
                _logger.LogWarning(duc, duc.Message);
                throw new ModelUpdateException(duc.Message);
            }
            catch (DbUpdateException du)
            {
                _logger.LogWarning(du, message: du.Message);
                throw new ModelUpdateException(du.InnerException.Message, du);
            }
        }

    }
}
