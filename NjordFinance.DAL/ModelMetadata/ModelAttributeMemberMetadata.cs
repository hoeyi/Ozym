using System.ComponentModel.DataAnnotations;
using NjordFinance.ModelMetadata.Resources;
using Ichosoft.DataModel.Annotations;

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
    }

    [MetadataType(typeof(ModelAttributeMemberMetadata))]
    public partial class ModelAttributeMember
    {
        internal ModelAttributeMember(
            int attributeMemberId, int attributeId, string displayName, short displayOrder)
        {
            AttributeMemberId = attributeMemberId;
            AttributeId = attributeId;
            DisplayName = displayName;
            DisplayOrder = displayOrder;
        }
    }
}
