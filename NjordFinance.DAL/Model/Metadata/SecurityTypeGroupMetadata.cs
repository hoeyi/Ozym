using System.ComponentModel.DataAnnotations;
using NjordFinance.Model.Metadata;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="SecurityTypeGroup"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.SecurityTypeGroup_Plural),
        PluralArticle = nameof(ModelNoun.SecurityTypeGroup_PluralArticle),
        Singular = nameof(ModelNoun.SecurityTypeGroup_Singular),
        SingularArticle = nameof(ModelNoun.SecurityTypeGroup_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecurityTypeGroupMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.SecurityTypeGroup_SecurityTypeGroupName_Name),
            Description = nameof(ModelDisplay.SecurityTypeGroup_SecurityTypeGroupName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SecurityTypeGroupName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityTypeGroup_Transactable_Name),
            Description = nameof(ModelDisplay.SecurityTypeGroup_Transactable_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool Transactable { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityTypeGroup_DepositSource_Name),
            Description = nameof(ModelDisplay.SecurityTypeGroup_DepositSource_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool DepositSource { get; set; }
    }

    [MetadataType(typeof(SecurityTypeGroupMetadata))]
    public partial class SecurityTypeGroup
    {
    }
}
