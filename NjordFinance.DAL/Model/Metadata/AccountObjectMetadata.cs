using NjordFinance.Model.Metadata;
using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountObject"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountObject_Plural),
        PluralArticle = nameof(ModelNoun.AccountObject_PluralArticle),
        Singular = nameof(ModelNoun.AccountObject_Singular),
        SingularArticle = nameof(ModelNoun.AccountObject_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class AccountObjectMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_AccountObjectCode_Name),
            Description = nameof(ModelDisplay.AccountObject_AccountObjectCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string AccountObjectCode { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDisplayName_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDipslayName_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public string ObjectDisplayName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDescription_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDescription_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public string ObjectDescription { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name),
            Description = nameof(ModelDisplay.AccountObject_StartDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime StartDate { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name),
            Description = nameof(ModelDisplay.AccountObject_CloseDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime? CloseDate { get; set; }

    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
