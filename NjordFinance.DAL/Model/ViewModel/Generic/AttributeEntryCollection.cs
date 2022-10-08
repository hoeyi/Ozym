using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    public abstract partial class AttributeEntryCollection<
        TParentEntity, TChildEntity, TGroupViewModel, TGroupKey>
        : IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupViewModel : IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        /// <inheritdoc/>
        public IReadOnlyCollection<TGroupViewModel> EntryCollection =>
            GroupEntries(Entries)
            .Select(g => ConvertGroupingToViewModel(g))
            .ToList();

        /// <inheritdoc/>
        public IEnumerable<IGrouping<ModelAttribute, TGroupViewModel>> EntryCollectionGroups
            => EntryCollection
                .GroupBy(e => e.ParentAttribute.AttributeId)
                .Select(grp =>
                {
                    var grouping = new AttributeGrouping<ModelAttribute, TGroupViewModel>(
                        key: grp.First().ParentAttribute, collection: grp);

                    return grouping;
                });

        /// <inheritdoc/>
        public TParentEntity ToEntity() => ParentEntity;
    }

    public abstract partial class AttributeEntryCollection
        <TParentEntity, TChildEntity, TGroupViewModel, TGroupKey>
    {
        private readonly Func<IGrouping<TGroupKey, TChildEntity>, TParentEntity, TGroupViewModel> _groupConverterDelegate;
        private readonly Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<TGroupKey, TChildEntity>>> _groupingDelegate;
        private readonly Func<TParentEntity, TGroupKey, TGroupViewModel> _groupConstructorDelegate;
        private readonly Func<TParentEntity, IEnumerable<TChildEntity>> _parentEntryMemberSelector;

        /// <summary>
        /// Initializes a new instance of 
        /// <see cref="AttributeEntryCollection{TParentEntity, TChildEntity, TViewModel, TGroupKey}"/> 
        /// describing the given <typeparamref name="TParentEntity"/> instance.
        /// </summary>
        /// <param name="parentEntity">The <typeparamref name="TParentEntity"/> described.</param>
        /// <exception cref="ArgumentNullException">A required argument was a null reference.</exception>
        protected AttributeEntryCollection(
            TParentEntity parentEntity,
            Func<TParentEntity, TGroupKey, TGroupViewModel> groupConstructor,
            Func<IGrouping<TGroupKey, TChildEntity>, TParentEntity, TGroupViewModel> groupConverter,
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<TGroupKey, TChildEntity>>> groupingFunc,
            Func<TParentEntity, IEnumerable<TChildEntity>> entryMemberSelector
            )
        {
            if (parentEntity is null)
                throw new ArgumentNullException(paramName: nameof(parentEntity));

            if (groupConstructor is null)
                throw new ArgumentNullException(paramName: nameof(groupConstructor));

            if (groupConverter is null)
                throw new ArgumentNullException(paramName: nameof(groupConverter));

            if (groupingFunc is null)
                throw new ArgumentNullException(paramName: nameof(groupingFunc));

            if (entryMemberSelector is null)
                throw new ArgumentNullException(paramName: nameof(entryMemberSelector));

            _groupConstructorDelegate = groupConstructor;
            _groupConverterDelegate = groupConverter;
            _groupingDelegate = groupingFunc;

            _parentEntryMemberSelector = entryMemberSelector;

            ParentEntity = parentEntity;
        }

        protected IEnumerable<TChildEntity> Entries => _parentEntryMemberSelector(ParentEntity);

        protected TParentEntity ParentEntity { get; private init; }

        /// <summary>
        /// Converts the given <see cref="IGrouping{TKey, TElemenet}"/> to an instance of 
        /// <typeparamref name="TGroupViewModel"/>.
        /// </summary>
        /// <param name="grouping">The <see cref="IGrouping{TKey, TElement}"/> to convert.</param>
        /// <returns></returns>
        protected TGroupViewModel ConvertGroupingToViewModel(
            IGrouping<TGroupKey, TChildEntity> grouping) =>
                _groupConverterDelegate.Invoke(grouping, ParentEntity);
        protected TGroupViewModel CreateGroupViewModel(
            TParentEntity parent, TGroupKey groupKey) => _groupConstructorDelegate.Invoke(parent, groupKey);

        /// <summary>
        /// Groups the given <typeparamref name="TChildEntity"/> entries using a <see cref="Tuple"/> 
        /// key created from the <see cref="int"/> parent attribute key and <see cref="DateTime"/> 
        /// effective date of the entries.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        protected IEnumerable<IGrouping<TGroupKey, TChildEntity>> GroupEntries(
            IEnumerable<TChildEntity> entries) => _groupingDelegate.Invoke(entries);

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
        
        private static string GetObjectGraph<T>(Expression<Func<T, object>> expression)
        {
            var parameterName = expression.Parameters[0].Name;

            var objectPath = expression.ToString()
                .Replace($"{parameterName} => {parameterName}", typeof(T).Name);

            return objectPath;
        }
    }
}
