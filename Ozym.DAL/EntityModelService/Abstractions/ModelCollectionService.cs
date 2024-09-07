using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ozym.EntityModel.Context;
using Ichosys.DataModel.Annotations;
using Ozym.DataTransfer;
using Ozym.ChangeTracking;

namespace Ozym.EntityModelService.Abstractions
{
    internal abstract partial class ModelCollectionService<T, TParent> 
        : ModelCollectionService<T>, IModelCollectionService<T, TParent>
        where T : class, new()
    {
        protected ModelCollectionService(
            IDbContextFactory<FinanceDbContext> contextFactory, 
            IModelMetadataService metadataService, 
            ILogger logger) : base(contextFactory, metadataService, logger)
        {
        }

        /// <summary>
        /// Configures this service to utilize the given <typeparamref name="TParent"/>  
        /// as the parent object to the models in this collection.
        /// </summary>
        /// <param name="parent"></param>
        public abstract void SetParent(TParent parent);
    }

    internal abstract partial class ModelCollectionService<T> : 
        ModelServiceBase<T>, IModelCollectionService<T>
        where T : class, new()
    {
        public ModelCollectionService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService metadataService, 
            ILogger logger)
            : base(contextFactory, metadataService, logger)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="IModelReaderService{T}" /> for this service.
        /// </summary>
        protected IModelReaderService<T> Reader { get; set; }

        /// <inheritdoc/>
        public bool ModelExists(int? id) => Reader.ModelExists(id);

        /// <inheritdoc/>
        public bool ModelExists(T model) => Reader.ModelExists(model);

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SelectAsync(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20)
            => await Reader.SelectAsync(predicate, pageNumber, pageSize);

        /// <inheritdoc/>
        public async Task<T> ReadAsync(int? id) => await Reader.ReadAsync(id);

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> SelectAsync() => await Reader.SelectAsync();

        /// <inheritdoc/>
        public async Task<int> AddUpdateDeleteAsync(
            IEnumerable<T> inserts, IEnumerable<T> updates, IEnumerable<T> deletes)
        {
            ArgumentNullException.ThrowIfNull(inserts);

            ArgumentNullException.ThrowIfNull(updates);

            ArgumentNullException.ThrowIfNull(deletes);

            using var context = await ContextFactory.CreateDbContextAsync();

            if(deletes.Any())
                context.Set<T>().RemoveRange(deletes);

            if(updates.Any())
                context.Set<T>().UpdateRange(updates);

            if(inserts.Any())
                context.Set<T>().AddRange(inserts);
            
            var result = await context.SaveChangesAsync();

            return result;
        }
    }
}
