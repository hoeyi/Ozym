using NjordFinance.EntityModel;
using NjordFinance.EntityModel.Metadata;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.DataTransfer
{
    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="Model.AccountObject"/>.
    /// </summary>
    public abstract class AccountObjectDto
    {
        private readonly AccountAttributesDto _attributeViewModel;
        private readonly AccountObject _accountObject;
        protected AccountObjectDto(AccountObject accountObject)
        {
            if (accountObject is null)
                throw new ArgumentNullException(paramName: nameof(accountObject));

            _accountObject = accountObject;
            _attributeViewModel = new(_accountObject);
        }

        /// <summary>
        /// Gets the code representing the object type of this instance.
        /// </summary>
        public abstract string ObjecTypeCode { get; }

        /// <summary>
        /// Gets the <see cref="AccountAttributesDto"/> representing the attributes applied 
        /// to this account object instance.
        /// </summary>
        public AccountAttributesDto AttributeViewModel => _attributeViewModel;

        protected int AccountObjectId
        {
            get { return _accountObject.AccountObjectId; }
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
            get { return _accountObject.AccountObjectCode; }
            set
            {
                if (_accountObject.AccountObjectCode != value)
                    _accountObject.AccountObjectCode = value;
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
            get { return _accountObject.ObjectDisplayName; }
            set
            {
                if (_accountObject.ObjectDisplayName != value)
                    _accountObject.ObjectDisplayName = value;
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
            get { return _accountObject.ObjectDescription; }
            set
            {
                if (_accountObject.ObjectDescription != value)
                    _accountObject.ObjectDescription = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name),
            Description = nameof(ModelDisplay.AccountObject_StartDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime StartDate
        {
            get { return _accountObject.StartDate; }
            set
            {
                if (_accountObject.StartDate != value)
                    _accountObject.StartDate = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name),
            Description = nameof(ModelDisplay.AccountObject_CloseDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime? CloseDate
        {
            get { return _accountObject.CloseDate; }
            set
            {
                if (_accountObject.CloseDate != value)
                    _accountObject.CloseDate = value;
            }
        }
    }
}
