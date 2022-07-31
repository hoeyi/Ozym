using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Serves as the base class for collections of attribute member entries that are children 
    /// of a given <see cref="ModelAttribute"/>.
    /// </summary>
    /// <typeparam name="TEntry">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParent">The entity type that is the parent of the attriubte entry this 
    /// view model represents.</typeparam>
    public abstract class AttributeEntryCollectionViewModel<TEntry, TParent> :
        AttributeEntryBaseViewModel<TEntry, TParent>
        where TEntry : class, new()
        where TParent : class, new()
    {
        protected AttributeEntryCollectionViewModel(
            TParent parentObject, ModelAttribute parentAttribute, DateTime effectiveDate)
            : base(parentObject, effectiveDate)
        {
            if (parentAttribute is null)
                throw new ArgumentNullException(paramName: nameof(parentAttribute));

            ParentAttribute = parentAttribute;
        }

        /// <summary>
        /// Gets the delegate for selecting the weight attribute for the <typeparamref name="TEntry"/> 
        /// type.
        /// </summary>
        protected abstract Func<TEntry, decimal> WeightSelector { get; }

        /// <summary>
        /// Gets the sum of all attribute members entries in this model.
        /// </summary>
        [ExactValue(1D)]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => MemberEntries.Sum(WeightSelector);

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> that is the parent for this view model.
        /// </summary>
        public ModelAttribute ParentAttribute { get; init; }

        /// <summary>
        /// Gets the collection of entries representing <typeparamref name="T"/> entities, 
        /// where the key represents the <see cref="ModelAttributeMember.AttributeMemberId"/> 
        /// and the value represents the weight for the entry.
        /// </summary>
        public List<TEntry> MemberEntries { get; } = new();

        /// <summary>
        /// Converts this model into <typeparamref name="TEntry"/> entities.
        /// </summary>
        /// <returns>An <see cref="Array"/> of <typeparamref name="TEntry"/>.</returns>
        public abstract TEntry[] ToEntities();
    }
}