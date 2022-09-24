using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.Model.ViewModel.Generic
{
    /// <summary>
    /// Represents a view model responsible for handling CRUD operations for a parent entity and 
    /// a batch of child entities each representing an entry linking a instance of 
    /// <see cref="ModelAttributeMember"/> to another entity. Examples include:
    /// <list type="bullet">
    /// <item><see cref="AccountAttributeMemberEntry"/></item>
    /// <item><see cref="CountryAttributeMemberEntry"/></item>
    /// <item><see cref="InvestmentStrategyTarget"/></item>
    /// <item><see cref="SecurityAttributeMemberEntry"/></item>
    /// </list>
    /// </summary>
    /// <typeparam name="TParentEntity"></typeparam>
    /// <typeparam name="TChildEntity"></typeparam>
    /// <typeparam name="TGroupModel"></typeparam>
    public partial interface IAttributeEntryWeightedCollection<
        TParentEntity, TChildEntity, TGroupModel>
        : IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Gets the <em>current</em> <typeparamref name="TGroupModel"/> entries in this model grouped
        /// by their parent <see cref="ModelAttribute"/>.
        /// </summary>
        IEnumerable<TGroupModel> CurrentEntryCollectionGroups { get; }

        /// <summary>
        /// Adds a new <typeparamref name="TGroupModel"/> entry to this collection and returns 
        /// the added instance.
        /// </summary>
        /// <param name="forAttribute">The parent <see cref="ModelAttribute"/> for the new 
        /// sub-collection.</param>
        /// <returns>A <typeparamref name="TGroupModel"/> instance.</returns>
        TGroupModel AddNew(ModelAttribute forAttribute);

        /// <summary>
        /// Removes an existing <typeparamref name="TGroupModel"/> from the children of this view 
        /// model.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>True if the removal was successful, else false.</returns>
        bool RemoveExising(TGroupModel viewModel);
    }

    /// <summary>
    /// Represents the base implementation of view models representing collections of attribute 
    /// entries as a single unit.
    /// </summary>
    public interface IAttributeEntryViewModel
    {
    }
}