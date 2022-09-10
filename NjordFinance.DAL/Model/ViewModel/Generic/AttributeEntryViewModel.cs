using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.Model.ViewModel.Generic
{
    /// <summary>
    /// Base class for view models used to manage <typeparamref name="TChildEntity"/> attribute entries
    /// describing a <typeparamref name="TParentEntity"/>.
    /// </summary>
    /// <typeparam name="TParentEntity">The entity type the attribute entries describe.</typeparam>
    /// <typeparam name="TChildEntity">The entity entry type.</typeparam>
    /// <typeparam name="TViewModel">The <see cref="IAttributeEntryGrouping{TParentEntity, TEntryEntity}"/> 
    /// that manages sub-groupings of entries in thsi model.</typeparam>
    public abstract partial class AttributeEntryViewModel<TParentEntity, TChildEntity, TViewModel>
        : IAttributeEntryViewModel<TParentEntity, TChildEntity, TViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TViewModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        /// <inheritdoc/>
        public IEnumerable<IGrouping<ModelAttribute, TViewModel>> AttributeTargetCollection
            => EntryCollection
                .GroupBy(e => e.ParentAttribute.AttributeId)
                .Select(grp =>
                {
                    var grouping = new AttributeGrouping<TViewModel>(
                        key: grp.First().ParentAttribute, collection: grp);

                    return grouping;
                });

        /// <inheritdoc/>
        public IEnumerable<IGrouping<ModelAttribute, TViewModel>> CurrentTargetCollection =>
            AttributeTargetCollection.Select(grp =>
            {
                var groupCollection = grp.Where(grp =>
                    grp.EffectiveDate.Date <= DateTime.UtcNow.Date);

                if (groupCollection.Any())
                    return new AttributeGrouping<TViewModel>(
                        key: grp.Key,
                        collection: groupCollection
                            .OrderByDescending(grp => grp.EffectiveDate).Take(1));
                else
                    return null;
            })
            .Where(g => g is not null);

        /// <inheritdoc/>
        public IReadOnlyCollection<TViewModel> EntryCollection =>
            GroupEntries(_entryMemberSelector(ParentEntity))
            .Select(g => ConvertGroupingToViewModel(g))
            .ToList();

        /// <inheritdoc/>
        public TViewModel AddNew(ModelAttribute forAttribute)
        {
            var viewModel = _groupConstructor
                .Invoke(ParentEntity, forAttribute, GetDateTimeForNew(forAttribute));

            viewModel.AddNewEntry();

            return viewModel;
        }

        /// <inheritdoc/>
        public TParentEntity ToEntity() => ParentEntity;

        /// <inheritdoc/>
        public bool RemoveExising(TViewModel viewModel) => viewModel.RemoveAll();
    }

    public abstract partial class AttributeEntryViewModel<TParentEntity, TChildEntity, TViewModel>
    {
        private readonly Func<TParentEntity, ModelAttribute, DateTime, TViewModel> _groupConstructor;
        private readonly Func<IGrouping<(int, DateTime), TChildEntity>, TParentEntity, TViewModel> _groupingConverterDelegate;
        private readonly Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<(int, DateTime), TChildEntity>>> _groupingDelegate;
        private readonly Func<TParentEntity, IEnumerable<TChildEntity>> _entryMemberSelector;

        /// <summary>
        /// Initializes a new instance of 
        /// <see cref="AttributeEntryViewModel{TParentEntity, TChildEntity, TViewModel}"/> 
        /// describing the given <typeparamref name="TParentEntity"/> instance.
        /// </summary>
        /// <param name="parentEntity">The <typeparamref name="TParentEntity"/> described.</param>
        /// <exception cref="ArgumentNullException">A required argument was a null reference.</exception>
        protected AttributeEntryViewModel(
            TParentEntity parentEntity,
            Func<TParentEntity, ModelAttribute, DateTime, TViewModel> groupConstructor,
            Func<IGrouping<(int, DateTime), TChildEntity>, TParentEntity, TViewModel> groupingConverterFunc,
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<(int, DateTime), TChildEntity>>> groupingFunc,
            Func<TParentEntity, IEnumerable<TChildEntity>> entryMemberSelector
            )
        {
            if (parentEntity is null)
                throw new ArgumentNullException(paramName: nameof(parentEntity));

            if (groupConstructor is null)
                throw new ArgumentNullException(paramName: nameof(groupConstructor));

            if (groupingConverterFunc is null)
                throw new ArgumentNullException(paramName: nameof(groupingConverterFunc));

            if (groupingFunc is null)
                throw new ArgumentNullException(paramName: nameof(groupingFunc));

            if (entryMemberSelector is null)
                throw new ArgumentNullException(paramName: nameof(entryMemberSelector));

            _groupConstructor = groupConstructor;
            _groupingConverterDelegate = groupingConverterFunc;
            _groupingDelegate = groupingFunc;

            _entryMemberSelector = entryMemberSelector;

            ParentEntity = parentEntity;
        }
        protected TParentEntity ParentEntity { get; private init; }

        /// <summary>
        /// Gets the error message for an incomplete object graph at the path specified by the 
        /// given expression, where the origin is an instance of the <typeparamref name="TParentEntity"/> 
        /// class.
        /// </summary>
        /// <param name="expression">The path to the missing member.</param>
        /// <returns>The interpolated string providing the error text for <typeparamref name="TParentEntity"/>-sourced members.</returns>
        protected string GetIncompleteObjectGraphMessage(
            Expression<Func<TParentEntity, object>> expression)
            => string.Format(
                format: Strings.AttributeEntryViewModel_Exception_IncompleteObjectGraph,
                arg0: GetObjectGraph(expression));

        /// <summary>
        /// Gets the error message for an incomplete object graph at the path specified by the 
        /// given expression, where the origin is an instance of the <typeparamref name="TChildEntity"/> 
        /// class.
        /// </summary>
        /// <param name="expression">The path to the missing member.</param>
        /// <returns>The interpolated string providing the error text for <typeparamref name="TChildEntity"/>-sourced members.</returns>
        protected string GetIncompleteObjectGraphMessage(
            Expression<Func<TChildEntity, object>> expression)
            => string.Format(
                format: Strings.AttributeEntryViewModel_Exception_IncompleteObjectGraph,
                arg0: GetObjectGraph(expression));

        protected DateTime GetDateTimeForNew(ModelAttribute forAttribute)
        {
            var lastEntryDateUtc = EntryCollection
                            .Where(x => x.ParentAttribute.AttributeId == forAttribute.AttributeId)
                            .MaxOrDefault(x => x.EffectiveDate)
                            .ToUniversalTime();

            DateTime effectiveDate = lastEntryDateUtc.Date < DateTime.UtcNow.Date ?
                DateTime.UtcNow.Date : lastEntryDateUtc.Date.AddDays(1);

            return effectiveDate;
        }

        /// <summary>
        /// Converts the given <see cref="IGrouping{TKey, TElemenet}"/> to an instance of 
        /// <typeparamref name="TViewModel"/>.
        /// </summary>
        /// <param name="grouping">The <see cref="IGrouping{TKey, TElement}"/> to convert.</param>
        /// <returns></returns>
        private TViewModel ConvertGroupingToViewModel(
            IGrouping<(int, DateTime), TChildEntity> grouping) => 
                _groupingConverterDelegate.Invoke(grouping, ParentEntity);

        /// <summary>
        /// Groups the given <typeparamref name="TChildEntity"/> entries using a <see cref="Tuple"/> 
        /// key created from the <see cref="int"/> parent attribute key and <see cref="DateTime"/> 
        /// effective date of the entries.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        private IEnumerable<IGrouping<(int, DateTime), TChildEntity>> GroupEntries(
            IEnumerable<TChildEntity> entries) => _groupingDelegate.Invoke(entries);
        
        private static string GetObjectGraph<T>(Expression<Func<T, object>> expression)
        {
            var parameterName = expression.Parameters[0].Name;

            var objectPath = expression.ToString()
                .Replace($"{parameterName} => {parameterName}", typeof(T).Name);

            return objectPath;
        }
    }
}
