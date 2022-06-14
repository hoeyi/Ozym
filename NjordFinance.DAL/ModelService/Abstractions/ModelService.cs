using Ichosys.DataModel;
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
    /// Base class for <typeparamref name="T"/> model service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class ModelService<T> : ModelServiceBase<T>, IModelService<T>
        where T : class, new()
    {
        /// <summary>
        /// Abstract constructor for <see cref="ModelService{T}"/>.
        /// </summary>
        /// <param name="contextFactory"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        protected ModelService(
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
        protected IModelWriterService<T> Writer { get; set; }

        /// <inheritdoc/>
        public void AddNavigationPath(Expression<Func<T, object>> navigationPath) =>
            Reader.AddNavigationPath(navigationPath);

        /// <inheritdoc/>
        public async Task<T> CreateAsync(T model) => await Writer.CreateAsync(model);

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(T model) => await Writer.DeleteAsync(model);

        /// <inheritdoc/>
        public async Task<T> GetDefaultAsync() => await Writer.GetDefaultAsync();

        /// <inheritdoc/>
        public bool ModelExists(int? id) => Reader.ModelExists(id);

        /// <inheritdoc/>
        public bool ModelExists(T model) => Reader.ModelExists(model);

        /// <inheritdoc/>
        public async Task<T> ReadAsync(int? id) => await Reader.ReadAsync(id);

        /// <inheritdoc/>
        public async Task<List<T>> SelectAllAsync() => await Reader.SelectAllAsync();

        /// <inheritdoc/>
        public async Task<List<T>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0) =>
            await Reader.SelectWhereAysnc(predicate, maxCount);

        /// <inheritdoc/>
        public async Task<bool> UpdateAsync(T model) => await Writer.UpdateAsync(model);
    }
}
