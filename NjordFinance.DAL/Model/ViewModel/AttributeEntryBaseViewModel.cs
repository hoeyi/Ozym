using NjordFinance.ModelMetadata.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Serves as the base class for attribute member entries that are children 
    /// of a given <see cref="ModelAttribute"/>, variant entity, and effective date.
    /// </summary>
    /// <typeparam name="TEntry">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParent">The entity type that is the parent of the attriubte entry this 
    /// view model represents.</typeparam>
    public abstract class AttributeEntryBaseViewModel<TEntry, TParent>
        where TEntry : class, new()
        where TParent : class, new()
    {
        protected AttributeEntryBaseViewModel(
            ModelAttribute attribute, DateTime effectiveDate)
        {
            if (attribute is null)
                throw new ArgumentNullException(paramName: nameof(attribute));

            ParentAttribute = attribute;
            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// Gets the effective date of the collection of values in <see cref="MemberEntries"/>.
        /// </summary>
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryViewModel_EffectiveDate),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate { get; init; }

        /// <summary>
        /// Gets the id of the <see cref="ModelAttribute"/> entity that is the parent of the 
        /// of the values in <see cref="MemberEntries"/>.
        /// </summary>
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryViewModel_ModelAttributeId),
            ResourceType = typeof(ModelDisplay))]
        public int ModelAttributeId { get; init; }

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> that is the parent for this view model.
        /// </summary>
        public ModelAttribute ParentAttribute { get; init; }

        /// <summary>
        /// Gets <typeparamref name="TParent"/> that is the parent for this view model.
        /// </summary>
        public TParent ParentObject { get; init; }
    }
}
