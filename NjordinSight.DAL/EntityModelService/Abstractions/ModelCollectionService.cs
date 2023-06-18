using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModelService.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.EntityModel.Context;
using Ichosys.DataModel.Annotations;
using NjordinSight.DataTransfer.Deprecated;

namespace NjordinSight.EntityModelService.Abstractions
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
            ModelNoun = ModelMetadata.GetAttribute<T, NounAttribute>();
            _commandHistory = new CommandHistory<T>();
        }

        private NounAttribute ModelNoun { get; init; }

        /// <summary>
        /// Gets or sets the <see cref="IModelReaderService{T}" /> for this service.
        /// </summary>
        protected IModelReaderService<T> Reader { get; set; }

        /// <inheritdoc/>
        public bool HasChanges => CommandHistory.Count > 0;

        /// <inheritdoc/>
        public bool AddPendingSave(T model)
        {
            if (!RequiredParentIdIsSet(model))
            {
                string modelDisplayName = ModelMetadata
                    .GetAttribute<T, NounAttribute>()
                    ?.GetSingular();

                throw new InvalidOperationException(string.Format(
                    ExceptionString.ModelService_AddFailed_RequiredParentNotset,
                        modelDisplayName?.ToLower() ?? typeof(T).Name));
            }

            if (!WorkingEntries.Contains(model))
            {
                var addCommand = new AddCommand<T>(
                    collection: WorkingEntries,
                    item: model,
                    description: string.Format(
                        Strings.ModelCollectionService_CommandDescription_AddModel,
                        ModelNoun?.GetSingular() ?? string.Empty));

                CommandHistory.AddThenExecute(addCommand);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeletePendingSave(T model)
        {
            if (WorkingEntries.Contains(model))
            {
                var removeCommand = new RemoveCommand<T>(
                    collection: WorkingEntries,
                    item: model,
                    description: string.Format(
                        Strings.ModelCollectionService_CommandDescription_RemoveModel,
                        ModelNoun?.GetSingular() ?? string.Empty));

                CommandHistory.AddThenExecute(removeCommand);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<T> GetDefaultAsync()
        {
            if (GetDefaultModelDelegate is null)
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionString.ModelService_DelegateIsNull, nameof(GetDefaultModelDelegate)));

            return await Task.Run(() => GetDefaultModelDelegate.Invoke());
        }

        /// <inheritdoc/>
        public bool ModelExists(int? id) => Reader.ModelExists(id);

        /// <inheritdoc/>
        public bool ModelExists(T model) => Reader.ModelExists(model);

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            var changes = ChangeTracker.GetChanges();
            var updated = WorkingEntries.ToHashSet().Except(changes.Added);

            using var context = await ContextFactory.CreateDbContextAsync();

            context.Set<T>().AddRange(changes.Added);
            context.Set<T>().RemoveRange(changes.Removed);
            context.Set<T>().UpdateRange(updated);

            return await context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> SelectAsync(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20)
        {
            var results = await Reader.SelectAsync(predicate, pageNumber, pageSize);

            WorkingEntries = results.Item1.ToList();

            CommandHistory.Clear();
            return (WorkingEntries, results.Item2);
        }

        /// <inheritdoc/>
        public async Task<T> ReadAsync(int? id)
        {
            return await Reader.ReadAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> SelectAsync()
        {
            var results = await Reader.SelectAsync();
            WorkingEntries = results.ToList();

            CommandHistory.Clear();
            return WorkingEntries;
        }
    }

    internal abstract partial class ModelCollectionService<T>
    {
        private readonly CommandHistory<T> _commandHistory;

        /// <summary>
        /// Gets the <see cref="IChangeTracker{T}"/> responsible for tracking the commands 
        /// tracked by <see cref="ChangeTracker"/>.
        /// </summary>
        protected ICommandHistory<T> CommandHistory => _commandHistory;

        /// <summary>
        /// Gets the <see cref="IChangeTracker{T}"/> responsible for tracking additions and 
        /// removals from <see cref="WorkingEntries"/>.
        /// </summary>
        protected IChangeTracker<T> ChangeTracker => _commandHistory;

        /// <summary>
        /// Gets or sets the collection of currently worked items.
        /// </summary>
        protected IList<T> WorkingEntries { get; set; } = new List<T>();

        /// <summary>
        /// Checks that a required parent identifier has been set for a given 
        /// <typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="model">The <typeparamref name="T"/> to check.</param>
        /// <returns>True, if the parent is set or not required, else false.</returns>
        private bool RequiredParentIdIsSet(T model)
        {
            if (ParentExpression is null)
                return true;

            var parentCheck = ParentExpression.Compile();
            return parentCheck.Invoke(model);
        }

        /// <summary>
        /// Gets or sets the expression for filtering results to the parent id for 
        /// this service.
        /// </summary>
        protected Expression<Func<T, bool>> ParentExpression { get; set; }

        /// <summary>
        /// Delegate responsible for creating a default <typeparamref name="T"/> instance.
        /// </summary>
        protected Func<T> GetDefaultModelDelegate { get; set; }
    }
}
