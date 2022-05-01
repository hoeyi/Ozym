using NjordFinance.Context;
using Ichosoft.DataModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.Exceptions;
using NjordFinance.Logging;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The base class for servicing batch CRUD requests for <typeparamref name="T"/> 
    /// models.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <typeparam name="TParentKey">The model's parent key type.</typeparam>
    public abstract class BatchModelServiceBase<T, TParentKey> 
        : ModelServiceBase, IBatchModelService<T>
        where T : class, new()
        where TParentKey : struct
    {
        /// <summary>
        /// The unique key that represents the parent of objects worked using this service.
        /// </summary>
        private TParentKey? parentKey;

        /// <summary>
        /// Creates a new <typeparamref name="T"/> batch model service.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{T}"/> for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.</param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        protected BatchModelServiceBase(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(contextFactory, modelMetadata, logger)
        {
            Context = _contextFactory.CreateDbContext();
        }

        /// <inheritdoc/>
        protected TParentKey ParentKey
        {
            get
            {
                if (parentKey is null)
                {
                    Exception e = new InvalidOperationException(
                        message: ExceptionString.ModelService_ParentKeyNotSet);

                    _logger.ModelServiceNotInitialized(service: GetType().Name, e);

                    throw e;
                }
                else
                    return (TParentKey)parentKey;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FinanceDbContext"/> for this instance.
        /// </summary>
        protected FinanceDbContext Context { get; set; }

        /// <inheritdoc/>
        public bool Initialize(object parentKey)
        {
            if (parentKey is not TParentKey)
                throw new InvalidOperationException();

            this.parentKey = (TParentKey)parentKey;

            return this.parentKey is not null;
        }

        /// <inheritdoc/>
        public abstract Task<T> GetDefault();

        /// <inheritdoc/>
        public abstract bool ModelExists(T model);

        /// <inheritdoc/>
        public abstract bool AddPendingSave(T model);

        /// <inheritdoc/>
        public abstract bool DeletePendingSave(T model);

        /// <inheritdoc/>
        public abstract Task<int> SaveChanges();

        /// <inheritdoc/>
        public abstract Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0);

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
