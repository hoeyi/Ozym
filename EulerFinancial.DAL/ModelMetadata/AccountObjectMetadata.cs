using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.Resources;
using EulerFinancial.ModelMetadata.Resources;

namespace EulerFinancial.Model
{
    public partial class AccountObjectMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_AccountObjectCode_Name), 
            ResourceType = typeof(ModelDisplay))]
        public string AccountObjectCode { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name), 
            ResourceType = typeof(ModelDisplay))]
        public DateTime StartDate { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name), 
            ResourceType = typeof(ModelDisplay))]
        public DateTime? CloseDate { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDisplayName_Name), 
            ResourceType = typeof(ModelDisplay))]
        public string ObjectDisplayName { get; set; }
    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
