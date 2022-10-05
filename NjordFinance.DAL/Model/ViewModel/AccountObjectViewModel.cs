using NjordFinance.Model.Metadata;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="Model.AccountObject"/>.
    /// </summary>
    public abstract class AccountObjectViewModel
    {
        protected AccountObjectViewModel(AccountObject accountObject)
        {
            if (accountObject is null)
                throw new ArgumentNullException(paramName: nameof(accountObject));

            AccountObject = accountObject;
        }

        /// <summary>
        /// Gets the code representing the object type of this instance.
        /// </summary>
        public abstract string ObjecTypeCode { get; }

        protected int AccountObjectId
        {
            get { return AccountObject.AccountObjectId; }
        }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_AccountObjectCode_Name),
            Description = nameof(ModelDisplay.AccountObject_AccountObjectCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string AccountObjectCode
        {
            get { return AccountObject.AccountObjectCode; }
            set
            {
                if (AccountObject.AccountObjectCode != value)
                    AccountObject.AccountObjectCode = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDisplayName_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDipslayName_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName
        {
            get { return AccountObject.ObjectDisplayName; }
            set
            {
                if (AccountObject.ObjectDisplayName != value)
                    AccountObject.ObjectDisplayName = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDescription_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDescription_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Description
        {
            get { return AccountObject.ObjectDescription; }
            set
            {
                if (AccountObject.ObjectDescription != value)
                    AccountObject.ObjectDescription = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name),
            Description = nameof(ModelDisplay.AccountObject_StartDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime StartDate
        {
            get { return AccountObject.StartDate; }
            set
            {
                if (AccountObject.StartDate != value)
                    AccountObject.StartDate = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name),
            Description = nameof(ModelDisplay.AccountObject_CloseDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime? CloseDate
        {
            get { return AccountObject.CloseDate; }
            set
            {
                if (AccountObject.CloseDate != value)
                    AccountObject.CloseDate = value;
            }
        }

        protected AccountObject AccountObject { get; }
    }
}
