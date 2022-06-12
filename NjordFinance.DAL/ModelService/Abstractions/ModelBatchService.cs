using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Base class for <typeparamref name="T"/> model batch service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class ModelBatchService<T> 
        : ModelServiceBase<T>, IModelBatchService<T>, ISharedContext
        where T : class, new()
    {
        public FinanceDbContext Context { get; private set; }

        /// <summary>
        /// Abstract constructor for <see cref="ModelBatchService{T}"/>.
        /// </summary>
        /// <param name="contextFactory"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        protected ModelBatchService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService metadataService,
            ILogger logger)
                : base(contextFactory, metadataService, logger)
        {
            Context = _contextFactory.CreateDbContext();
        }

        /// <summary>
        /// Gets or sets the service that handles read requests for this service.
        /// </summary>
        protected IModelReaderService<T> Reader { get; set; }

        /// <summary>
        /// Gets or sets the service that handles write requests for this service.
        /// </summary>
        protected IModelWriterBatchService<T> Writer { get; set; }

        /// <inheritdoc/>
        public bool IsDirty => Context?.ChangeTracker?.HasChanges() ?? false;

        /// <inheritdoc/>
        public abstract bool ForParent(int parentId, out Exception e);

        /// <inheritdoc/>
        public void AddNavigationPath(Expression<Func<T, object>> navigationPath) =>
            Reader.AddNavigationPath(navigationPath);

        /// <inheritdoc/>
        public bool AddPendingSave(T model) => Writer.AddPendingSave(model);

        /// <inheritdoc/>
        public bool DeletePendingSave(T model) => Writer.DeletePendingSave(model);

        /// <inheritdoc/>
        public async Task<T> GetDefaultAsync() => await Writer.GetDefaultAsync();

        /// <inheritdoc/>
        public bool ModelExists(int? id) => Reader.ModelExists(id);

        /// <inheritdoc/>
        public bool ModelExists(T model) => Reader.ModelExists(model);

        /// <inheritdoc/>
        public async Task<T> ReadAsync(int? id) => await Reader.ReadAsync(id);

        /// <inheritdoc/>
        public async Task<int> SaveChanges()
        {
            return await Writer.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task<List<T>> SelectAllAsync()
        {
            return await Reader.SelectAllAsync();
        }

        /// <inheritdoc/>
        public async Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            return await Reader.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
