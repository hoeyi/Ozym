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
    internal abstract class ModelBatchService<T> : ModelServiceBase<T>, IModelBatchService<T>
        where T : class, new()
    {
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
        public bool IsDirty => Writer.IsDirty;

        /// <inheritdoc/>
        public abstract bool ForParent(int parentId);

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
        public void Refresh() => Writer.Refresh();

        /// <inheritdoc/>
        public async Task<int> SaveChanges() => await Writer.SaveChanges();

        /// <inheritdoc/>
        public async Task<List<T>> SelectAllAsync()
        {
            Refresh();
            return await Reader.SelectAllAsync();
        }

        /// <inheritdoc/>
        public async Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            Refresh();
            return await Reader.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
