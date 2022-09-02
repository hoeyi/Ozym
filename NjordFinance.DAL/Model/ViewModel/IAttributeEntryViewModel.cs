using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.Model.ViewModel
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
    /// <typeparam name="TViewModel"></typeparam>
    public partial interface IAttributeEntryViewModel<TParentEntity, TChildEntity, TViewModel>
        : IAttributeEntryViewModel
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TViewModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        /// <summary>
        /// Gets the <typeparamref name="TViewModel"/> entries in this model grouped by their 
        ///  <see cref="ModelAttribute"/>.
        /// </summary>
        IEnumerable<IGrouping<ModelAttribute, TViewModel>> AttributeTargetCollection { get; }

        /// <summary>
        /// Gets the <em>current</em> <typeparamref name="TViewModel"/> entries in this model grouped
        /// by their parent <see cref="ModelAttribute"/>.
        /// </summary>
        IEnumerable<IGrouping<ModelAttribute, TViewModel>> CurrentTargetCollection { get; }

        /// <summary>
        /// Gets the collection of <see cref="TViewModel"/> that represent the 
        /// <typeparamref name="TChildEntity"/> entries in this model.
        /// </summary>
        IReadOnlyCollection<TViewModel> EntryCollection { get; }

        /// <summary>
        /// Adds a new <typeparamref name="TViewModel"/> entry to this collection and returns 
        /// the added instance.
        /// </summary>
        /// <param name="forAttribute">The parent <see cref="ModelAttribute"/> for the new 
        /// sub-collection.</param>
        /// <returns>A <typeparamref name="TViewModel"/> instance.</returns>
        TViewModel AddNew(ModelAttribute forAttribute);

        /// <summary>
        /// Removes an existing <typeparamref name="TViewModel"/> from the children of this view 
        /// model.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>True if the removal was successful, else false.</returns>
        bool RemoveExising(TViewModel viewModel);

        /// <summary>
        /// Converts this attribute weight view model to its <typeparamref name="TParentEntity"/> 
        /// entity representation.
        /// </summary>
        /// <returns>The view model converted to an instance of <typeparamref name="TParentEntity"/>
        /// </returns>
        TParentEntity ToEntity();
    }

    /// <summary>
    /// Represents the base implementation of view models representing collections of attribute 
    /// entries as a single unit.
    /// </summary>
    public interface IAttributeEntryViewModel
    {
    }
}