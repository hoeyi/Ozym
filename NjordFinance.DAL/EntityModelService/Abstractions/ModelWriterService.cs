using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.EntityModel.Context;
using NjordFinance.Logging;
using System;
using System.Threading.Tasks;

namespace NjordFinance.EntityModelService.Abstractions
{
    /// <summary>
    /// Variant <see cref="ModelServiceBase{T}"/> class that services write requests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed partial class ModelWriterService<T> : ModelServiceBase<T>, IModelWriterService<T>
        where T : class, new()
    {
        /// <summary>
        /// Creates a new <see cref="ModelWriterService{T}"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{NjordFinanceContext}"/> 
        /// for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.
        /// </param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        public ModelWriterService(
            IDbContextFactory<FinanceDbContext> contextFactory, 
            IModelMetadataService modelMetadata, 
            ILogger logger) : 
                base(contextFactory, modelMetadata, logger)
        {
        }

        /// <summary>
        /// Base constructor for <see cref="ModelWriterService{T}"/> instances where a
        /// shared context is used.
        /// </summary>
        /// <param name="sharedContext"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        public ModelWriterService(
            FinanceDbContext sharedContext,
            IModelMetadataService metadataService,
            ILogger logger)
            : base(sharedContext, metadataService, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<T> CreateAsync(T model)
        {
            if (CreateDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(CreateDelegate)));

            DbActionResult<T> createAction;
            
            if(HasSharedContext)
                createAction = await DoWriteOperationAsync(SharedContext, CreateDelegate, model);
            else
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                createAction = await DoWriteOperationAsync(
                    context, CreateDelegate, model);
            }

            if (createAction.Successful)
            {
                var logModel = new
                {
                    Type = typeof(T).Name,
                    Id = GetKey(model) ?? default
                };

                _logger.ModelServiceCreatedModel(logModel);
                return createAction.Result;
            }
            else
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public async Task<T> GetDefaultAsync()
        {
            if (GetDefaultDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(GetDefaultDelegate)));

            return await Task.Run(() => GetDefaultDelegate.Invoke());
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(T model)
        {
            if (DeleteDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(DeleteDelegate)));

            var logModel = new
            {
                Type = typeof(T).Name,
                Id = GetKey(model) ?? default
            };

            DbActionResult<bool> deleteAction;

            if (HasSharedContext)
                deleteAction = await DoWriteOperationAsync(SharedContext, DeleteDelegate, model);
            else
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                deleteAction = await DoWriteOperationAsync(
                    context, DeleteDelegate, model);
            }

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
        public async Task<bool> UpdateAsync(T model)
        {
            if (UpdateDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(UpdateDelegate)));

            var logModel = new
            {
                Type = typeof(T).Name,
                Id = GetKey(model) ?? default
            };

            DbActionResult<bool> udpateAction;

            if (HasSharedContext)
                udpateAction = await DoWriteOperationAsync(
                    SharedContext, UpdateDelegate, model);
            else
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                udpateAction = await DoWriteOperationAsync(
                    context, UpdateDelegate, model);
            }

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
    }

    /// <inheritdoc/>
    internal partial class ModelWriterService<T>
    {
        /// <summary>
        /// Delegate repsonsible for writing a new <typeparamref name="T"/> model to the 
        /// data store.
        /// </summary>
        public Func<FinanceDbContext, T, Task<DbActionResult<T>>> 
            CreateDelegate { get; internal init; } = async (context, model) =>
            {
                var result = await context
                    .MarkForCreation(model)
                    .SaveChangesAsync() > 0;

                return new DbActionResult<T>(model, result);
            };

        /// <summary>
        /// Delegate responsible for deleting an existing <typeparamref name="T"/> model from 
        /// the data store.
        /// </summary>
        public Func<FinanceDbContext, T, Task<DbActionResult<bool>>>
            DeleteDelegate { get; internal init; } = async (context, model) =>
            {
                var result = await context
                    .MarkForDeletion(model)
                    .SaveChangesAsync() > 0;

                return new DbActionResult<bool>(result, result);
            };

        /// <summary>
        /// Delegate responsible for creating a default <typeparamref name="T"/> instance.
        /// </summary>
        public Func<T> GetDefaultDelegate { get; internal init; } = () => new();

        /// <summary>
        /// Delegate responsible for updating existing an existing <typeparamref name="T"/> 
        /// model in the data store.
        /// </summary>
        public Func<FinanceDbContext, T, Task<DbActionResult<bool>>>
            UpdateDelegate { get; internal init; } = async (context, model) =>
            {
                var result = await context
                 .MarkForUpdate(model)
                 .SaveChangesAsync() > 0;

                return new DbActionResult<bool>(result, result);
            };

        /// <summary>
        /// Invokes the given delegate to write data to the data store.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="writeDelegate">The delegate that will perform the write operations to the 
        /// <see cref="FinanceDbContext"/>.</param>
        /// <param name="model">The <typeparamref name="T"/> model which is being written.</param>
        /// <returns>A <typeparamref name="TResult"/> representing the outcome of the write operation.</returns>
        /// <exception cref="ModelUpdateException"></exception>
        private async Task<DbActionResult<TResult>> DoWriteOperationAsync<TResult>(
            FinanceDbContext context,
            Func<FinanceDbContext, T, Task<DbActionResult<TResult>>> writeDelegate,
            T model)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            try
            {
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
