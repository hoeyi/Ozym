using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    public interface IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupModel>
        : IAttributeEntryViewModel
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Gets the <typeparamref name="TGroupModel"/> entries in this model grouped by their 
        ///  <see cref="ModelAttribute"/>.
        /// </summary>
        IEnumerable<IGrouping<ModelAttribute, TGroupModel>> EntryCollectionGroups { get; }

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
