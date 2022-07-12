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
    /// of the given variant entity <typeparamref name="TParent"/>, and effective date.
    /// </summary>
    /// <typeparam name="TEntry">The entity type this view model represents.</typeparam>
    /// <typeparam name="TParent">The entity type that is the parent of the attriubte entry this 
    /// view model represents.</typeparam>
    public abstract class AttributeEntryBaseViewModel<TEntry, TParent>
        where TEntry : class, new()
        where TParent : class, new()
    {
        /// <summary>
        /// Initializes the base class with the given parent object and effective date.
        /// </summary>
        /// <param name="parentObject">The <typeparamref name="TParent"/> model to which 
        /// the attribute entry applies.</param>
        /// <param name="effectiveDate">The effective date of entries in this model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parentObject"/> was null.
        /// </exception>
        protected AttributeEntryBaseViewModel(TParent parentObject, DateTime effectiveDate)
        {
            if (parentObject is null)
                throw new ArgumentNullException(paramName: nameof(parentObject));

            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// Gets the effective date of the collection of values in <see cref="MemberEntries"/>.
        /// </summary>
        [Display(
            Name = nameof(ModelDisplay.AttributeEntryViewModel_EffectiveDate),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets <typeparamref name="TParent"/> that is the parent for this view model.
        /// </summary>
        public TParent ParentObject { get; init; }
    }
}
