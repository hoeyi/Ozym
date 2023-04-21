using System.Collections.Generic;
using NjordFinance.Model;

namespace NjordFinance.ViewModel.Generic
{
    public interface IAttributeEntryUnweightedCollection<
        TParentEntity, TChildEntity, TGroupModel>
        : IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupModel : IAttributeEntryUnweightedGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Adds a new entry for the given <see cref="ModelAttribute"/>, and returns the 
        /// <typeparamref name="TGroupModel"/> resulting from its addition.
        /// </summary>
        /// <param name="forAttribute"></param>
        /// <returns>An instance of <typeparamref name="TGroupModel"/> to which the added 
        /// <typeparamref name="TChildEntity"/> belongs.</returns>
        TGroupModel AddEntryForGrouping(ModelAttribute forAttribute);

        /// <summary>
        /// Gets the current <typeparamref name="TChildEntity"/> entites based on the 
        /// current UTC date.
        /// </summary>
        IEnumerable<TChildEntity> CurrentEntries { get; }
    }
}
