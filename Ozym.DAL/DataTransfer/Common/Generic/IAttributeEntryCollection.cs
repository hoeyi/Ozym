using System.Collections.Generic;
using System.Linq;

namespace Ozym.DataTransfer.Common.Generic
{
    public interface IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupModel>
        : IAttributeEntryViewModel
        where TGroupModel : IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Gets the <typeparamref name="TGroupModel"/> entries in this model grouped by their 
        ///  <see cref="ModelAttributeDtoBase"/>.
        /// </summary>
        IEnumerable<IGrouping<ModelAttributeDtoBase, TGroupModel>> EntryCollectionGroups { get; }

        /// <summary>
        /// Gets the collection of <see cref="TGroupModel"/> that represent the 
        /// <typeparamref name="TChildEntity"/> entries in this model.
        /// </summary>
        IReadOnlyCollection<TGroupModel> EntryCollection { get; }

        /// <summary>
        /// Converts this attribute weight view model to its <typeparamref name="TParentEntity"/> 
        /// entity representation.
        /// </summary>
        /// <returns>The view model converted to an instance of <typeparamref name="TParentEntity"/>
        /// </returns>
        TParentEntity ToEntity();
    }
}
