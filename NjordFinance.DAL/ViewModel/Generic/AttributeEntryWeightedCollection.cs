using System;
using System.Collections.Generic;
using System.Linq;
using NjordFinance.Model;

namespace NjordFinance.ViewModel.Generic
{
    /// <summary>
    /// Base class for view models used to manage <typeparamref name="TChildEntity"/> attribute entries
    /// describing a <typeparamref name="TParentEntity"/>.
    /// </summary>
    /// <typeparam name="TParentEntity">The entity type the attribute entries describe.</typeparam>
    /// <typeparam name="TChildEntity">The entity entry type.</typeparam>
    /// <typeparam name="TGroupViewModel">The <see cref="IAttributeEntryWeightedGrouping{TParentEntity, TEntryEntity}"/> 
    /// that manages sub-groupings of entries in thsi model.</typeparam>
    public abstract partial class AttributeEntryWeightedCollection<
        TParentEntity, TChildEntity, TGroupViewModel>
        : AttributeEntryCollection<TParentEntity, TChildEntity, TGroupViewModel, (ModelAttribute, DateTime)>,
        IAttributeEntryWeightedCollection<TParentEntity, TChildEntity, TGroupViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupViewModel : IAttributeEntryWeightedGrouping<TParentEntity, TChildEntity>
    {
        /// <inheritdoc/>
        public IEnumerable<TGroupViewModel> CurrentEntryCollectionGroups => EntryCollection
                .Where(e => e.EffectiveDate <= DateTime.UtcNow.Date)
                .GroupBy(e => e.ParentAttribute.AttributeId)
                .SelectMany(grp => grp.OrderByDescending(a => a.EffectiveDate).Take(1));
        
        /// <inheritdoc/>
        public TGroupViewModel AddNew(ModelAttribute forAttribute)
        {
            var forDate = GetDateTimeForNew(forAttribute);

            var viewModel = CreateGroupViewModel(ParentEntity, (forAttribute, forDate));

            viewModel.AddNewEntry();

            return viewModel;
        }

        /// <inheritdoc/>
        public bool RemoveExising(TGroupViewModel viewModel) => viewModel.RemoveAll();
    }

    public abstract partial class AttributeEntryWeightedCollection<
        TParentEntity, TChildEntity, TGroupViewModel>
    {
        /// <summary>
        /// Initializes a new instance of 
        /// <see cref="AttributeEntryWeightedCollection{TParentEntity, TChildEntity, TViewModel}"/> 
        /// describing the given <typeparamref name="TParentEntity"/> instance.
        /// </summary>
        /// <param name="parentEntity">The <typeparamref name="TParentEntity"/> described.</param>
        /// <exception cref="ArgumentNullException">A required argument was a null reference.</exception>
        protected AttributeEntryWeightedCollection(
            TParentEntity parentEntity,
            Func<TParentEntity, (ModelAttribute, DateTime), TGroupViewModel> groupConstructor,
            Func<IGrouping<(ModelAttribute, DateTime), TChildEntity>, TParentEntity, TGroupViewModel> groupingConverterFunc,
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<(ModelAttribute, DateTime), TChildEntity>>> groupingFunc,
            Func<TParentEntity, IEnumerable<TChildEntity>> entryMemberSelector
            )
            : base(
                  parentEntity, 
                  groupConstructor, 
                  groupingConverterFunc, 
                  groupingFunc, 
                  entryMemberSelector)
        {
        }


        protected virtual DateTime GetDateTimeForNew(ModelAttribute forAttribute)
        {
            var lastEntryDateUtc = EntryCollection
                            .Where(x => x.ParentAttribute.AttributeId == forAttribute.AttributeId)
                            .MaxOrDefault(x => x.EffectiveDate)
                            .ToUniversalTime();

            DateTime effectiveDate = lastEntryDateUtc.Date < DateTime.UtcNow.Date ?
                DateTime.UtcNow.Date : lastEntryDateUtc.Date.AddDays(1);

            return effectiveDate;
        }
    }
}
