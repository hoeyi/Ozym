using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<IGrouping<ModelAttribute, TViewModel>> AttributeTargetCollection
            => EntryCollection
                .GroupBy(e => e.ParentAttribute.AttributeId)
                .Select(grp =>
                {
                    var grouping = new AttributeGrouping<TViewModel>(
                        key: grp.First().ParentAttribute, collection: grp);

                    return grouping;
                });
        
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
        
        public IReadOnlyCollection<TViewModel> EntryCollection =>
            GroupEntries(EntryMemberSelector(_parentEntity))
            .Select(g => ConvertGroupingToViewModel(g))
            .ToList();

        public abstract TViewModel AddNew(ModelAttribute forAttribute);

        public abstract TParentEntity ToEntity();

        public bool RemoveExising(TViewModel viewModel) => viewModel.RemoveAll();
    }

    public abstract partial class AttributeEntryViewModel<TParentEntity, TChildEntity, TViewModel>
    {
        protected readonly TParentEntity _parentEntity;

        /// <summary>
        /// Initializes a new instance of 
        /// <see cref="AttributeEntryViewModel{TParentEntity, TChildEntity, TViewModel}"/> 
        /// describing the given <typeparamref name="TParentEntity"/> instance.
        /// </summary>
        /// <param name="parentEntity">The <typeparamref name="TParentEntity"/> described.</param>
        /// <exception cref="ArgumentNullException">A required argument was a null reference.</exception>
        protected AttributeEntryViewModel(TParentEntity parentEntity)
        {
            if (parentEntity is null)
                throw new ArgumentNullException(paramName: nameof(parentEntity));

            _parentEntity = parentEntity;
        }

        /// <summary>
        /// Gets the delegate responsible for selecting the member of 
        /// <typeparamref name="TParentEntity"/> that is an <see cref="IEnumerable{T}"/> of 
        /// <typeparamref name="TChildEntity"/>.
        /// </summary>
        protected abstract Func<TParentEntity, IEnumerable<TChildEntity>> EntryMemberSelector { get; }

        /// <summary>
        /// Converts the given <see cref="IGrouping{TKey, TElemenet}"/> to an instance of 
        /// <typeparamref name="TViewModel"/>.
        /// </summary>
        /// <param name="grouping">The <see cref="IGrouping{TKey, TElement}"/> to convert.</param>
        /// <returns></returns>
        protected abstract TViewModel ConvertGroupingToViewModel(
            IGrouping<(int, DateTime), TChildEntity> grouping);

        /// <summary>
        /// Groups the given <typeparamref name="TChildEntity"/> entries using a <see cref="Tuple"/> 
        /// key created from the <see cref="int"/> parent attribute key and <see cref="DateTime"/> 
        /// effective date of the entries.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        protected abstract IEnumerable<IGrouping<(int, DateTime), TChildEntity>> GroupEntries(
            IEnumerable<TChildEntity> entries);

        
    }
}
