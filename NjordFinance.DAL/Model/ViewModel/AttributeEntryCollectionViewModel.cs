using NjordFinance.ModelMetadata.Resources;
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
        private readonly Dictionary<int, decimal> _memberEntries = new();

        protected AttributeEntryCollectionViewModel(
            ModelAttribute attribute, DateTime effectiveDate)
            : base(attribute, effectiveDate)
        {
        }

        /// <summary>
        /// Gets the sum of all attribute members entries in this model.
        /// </summary>
        [ExactValue(100D)]
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryCollectionViewModel_SumOfWeights),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => MemberEntries.Sum(kv => kv.Value);

        /// <summary>
        /// Gets the collection of entries representing <typeparamref name="T"/> entities, 
        /// where the key represents the <see cref="ModelAttributeMember.AttributeMemberId"/> 
        /// and the value represents the weight for the entry.
        /// </summary>
        protected IReadOnlyDictionary<int, decimal> MemberEntries => _memberEntries;

        /// <summary>
        /// Converts this model into <typeparamref name="T"/> entities.
        /// </summary>
        /// <returns>An <see cref="Array"/> of <typeparamref name="T"/>.</returns>
        public abstract TEntry[] ToEntities();

        /// <summary>
        /// Adds an entry with the given <paramref name="attributeMemberId"/> and 
        /// <paramref name="weight"/>.
        /// </summary>
        /// <param name="attributeMemberId"></param>
        /// <param name="weight"></param>
        public virtual void AddEntry(int attributeMemberId, decimal weight) =>
            _memberEntries.Add(attributeMemberId, weight);
    }
}