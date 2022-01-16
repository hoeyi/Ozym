using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.Resources;

namespace EulerFinancial.Model
{
    public partial class AccountObjectMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.AccountObject_AccountObjectCode), 
            ResourceType = typeof(ModelDisplayName))]
        public string AccountObjectCode { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.AccountObject_StartDate), 
            ResourceType = typeof(ModelDisplayName))]
        public DateTime StartDate { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.AccountObject_CloseDate), 
            ResourceType = typeof(ModelDisplayName))]
        public DateTime? CloseDate { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.AccountObject_ObjectDisplayName), 
            ResourceType = typeof(ModelDisplayName))]
        public string ObjectDisplayName { get; set; }
    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
