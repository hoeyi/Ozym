using System;
using System.Collections.Generic;
using System.Linq;
using NjordFinance.Model;

namespace NjordFinance.ViewModel.Generic
{
    public abstract partial class AttributeEntryUnweightedCollection<
        TParentEntity, TChildEntity, TGroupViewModel> :
        AttributeEntryCollection<TParentEntity, TChildEntity, TGroupViewModel, ModelAttribute>,
        IAttributeEntryUnweightedCollection<TParentEntity, TChildEntity, TGroupViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupViewModel : IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        private readonly Func<TChildEntity, DateTime> _entryDateSelector;

        protected AttributeEntryUnweightedCollection(
            TParentEntity parentEntity,
            Func<TParentEntity, ModelAttribute, TGroupViewModel> groupConstructor,
            Func<IGrouping<ModelAttribute, TChildEntity>, TParentEntity, TGroupViewModel> groupConverter,
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<ModelAttribute, TChildEntity>>> groupingFunc,
            Func<TParentEntity, IEnumerable<TChildEntity>> entryMemberSelector,
            Func<TChildEntity, DateTime> entryDateSelector)
            : base(parentEntity, groupConstructor, groupConverter, groupingFunc, entryMemberSelector)
        {
            if (entryDateSelector is null)
                throw new ArgumentNullException(paramName: nameof(entryDateSelector));

            _entryDateSelector = entryDateSelector;
        }

        /// <inheritdoc/>
        public IEnumerable<TChildEntity> CurrentEntries => EntryCollection
            .SelectMany(grp =>
            {
                var currentyEntry = grp.Entries
                    .Where(e => _entryDateSelector(e).Date <= DateTime.UtcNow.Date)
                    .OrderByDescending(e => _entryDateSelector(e))
                    ?.Take(1);

                return currentyEntry;
            });

        /// <inheritdoc/>
        public TGroupViewModel AddEntryForGrouping(ModelAttribute forAttribute)
        {
            var viewModel = CreateGroupViewModel(ParentEntity, forAttribute);

            viewModel.AddNewEntry();

            return viewModel;
        }
    }
}
