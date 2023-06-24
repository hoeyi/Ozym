﻿using System;
using System.Collections.Generic;
using System.Linq;
using NjordinSight.EntityModel;

namespace NjordinSight.DataTransfer.Common.Generic
{
    public abstract partial class AttributeEntryUnweightedCollection<
        TParentEntity, TChildEntity, TGroupViewModel> :
        AttributeEntryCollection<TParentEntity, TChildEntity, TGroupViewModel, ModelAttributeDto>,
        IAttributeEntryUnweightedCollection<TParentEntity, TChildEntity, TGroupViewModel>
        where TGroupViewModel : IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        private readonly Func<TChildEntity, DateTime> _entryDateSelector;

        protected AttributeEntryUnweightedCollection(
            TParentEntity parentEntity,
            Func<TParentEntity, ModelAttributeDto, TGroupViewModel> groupConstructor,
            Func<IGrouping<ModelAttributeDto, TChildEntity>, TParentEntity, TGroupViewModel> groupConverter,
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<ModelAttributeDto, TChildEntity>>> groupingFunc,
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
        public TGroupViewModel AddEntryForGrouping(ModelAttributeDto forAttribute)
        {
            var viewModel = CreateGroupViewModel(ParentEntity, forAttribute);

            viewModel.AddNewEntry();

            return viewModel;
        }
    }
}
