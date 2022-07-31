using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="AccountObject"/>.
    /// </summary>
    public abstract class AccountObjectViewModel
    {
        public int AccountObjectId { get; set; }

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
        public string AccountObjectCode { get; set; }

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
        public string DisplayName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDescription_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDescription_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Description { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name),
            Description = nameof(ModelDisplay.AccountObject_StartDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime StartDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name),
            Description = nameof(ModelDisplay.AccountObject_CloseDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime? CloseDate { get; set; }
    }
}
