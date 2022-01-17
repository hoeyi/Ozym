using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.ModelMetadata.Resources;

namespace EulerFinancial.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountObject"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountObject_Plural),
        PluralArticle = nameof(ModelNoun.AccountObject_PluralArticle),
        Singular = nameof(ModelNoun.AccountObject_Singular),
        SingularArticle = nameof(ModelNoun.AccountObject_SingularArticle)
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

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDisplayName_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDipslayName_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public string ObjectDisplayName { get; set; }
    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
