using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public abstract class AttributeEntryViewModel<TEntry, TParent> :
        AttributeEntryBaseViewModel<TEntry, TParent>
        where TEntry :  class, new()
        where TParent : class, new()
    {   
        private int _attributeId;
        private int _attributeMemberId;

        /// <summary>
        /// Initializes the base class with the given parent object and effective date.
        /// </summary>
        /// <param name="parentObject">The <typeparamref name="TParent"/> model to which 
        /// the attribute entry applies.</param>
        /// <param name="effectiveDate">The effective date of entries in this model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parentObject"/> was null.
        /// </exception>
        protected AttributeEntryViewModel(TParent parentObject, DateTime effectiveDate)
            : base(parentObject, effectiveDate)
        {
        }

        /// <summary>
        /// Gets or sets the identifer for the <see cref="ModelAttribute"/> that represents 
        /// the look-up list for this entry.
        /// </summary>
        public int AttributeId
        {
            get { return _attributeId; }
            set
            {
                if (_attributeId != value)
                {
                    _attributeId = value;

                    // Reset _attributeMemberId if _attributeId is changed.
                    _attributeMemberId = default;
                }
            }
        }

        /// <summary>
        /// Gets or sets the identifier for the <see cref="ModelAttributeMember"/> for this entry.
        /// </summary>
        public int AttributeMemberId
        {
            get { return _attributeMemberId; }
            set
            {
                if(_attributeMemberId != value)
                {
                    _attributeMemberId = value;
                }
            }
        }

        /// <summary>
        /// Converts this model into a instance of <typeparamref name="TEntry"/>.
        /// </summary>
        /// <returns>An instance of <typeparamref name="TEntry"/>.</returns>
        public abstract TEntry ToEntryEntity();
    }
}
