using System.ComponentModel.DataAnnotations;
using NjordFinance.Model.Metadata;
using Ichosys.DataModel.Annotations;
using MessagePack;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ModelAttributeMember"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.ModelAttributeMember_Plural),
        PluralArticle = nameof(ModelNoun.ModelAttributeMember_PluralArticle),
        Singular = nameof(ModelNoun.ModelAttributeMember_Singular),
        SingularArticle = nameof(ModelNoun.ModelAttributeMember_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class ModelAttributeMemberMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.ModelAttributeMember_DisplayName_Name),
            Description = nameof(ModelDisplay.ModelAttributeMember_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.ModelAttributeMember_DisplayOrder_Name),
            Description = nameof(ModelDisplay.ModelAttributeMember_DisplayOrder_Description),
            ResourceType = typeof(ModelDisplay))]
        public int DisplayOrder { get; set; }
    }

    [MetadataType(typeof(ModelAttributeMemberMetadata))]
    public partial class ModelAttributeMember
    {
    }
}
