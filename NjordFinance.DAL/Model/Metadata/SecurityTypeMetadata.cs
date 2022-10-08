using System.ComponentModel.DataAnnotations;
using NjordFinance.Model.Metadata;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="SecurityType"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.SecurityType_Plural),
        PluralArticle = nameof(ModelNoun.SecurityType_PluralArticle),
        Singular = nameof(ModelNoun.SecurityType_Singular),
        SingularArticle = nameof(ModelNoun.SecurityType_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecurityTypeMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.SecurityType_SecurityTypeGroupID_Name),
            Description = nameof(ModelDisplay.SecurityType_SecurityTypeGroupID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SecurityTypeGroupId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityType_SecurityTypeName_Name),
            Description = nameof(ModelDisplay.SecurityType_SecurityTypeName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SecurityTypeName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityType_ValuationFactor_Name),
            Description = nameof(ModelDisplay.SecurityType_ValuationFactor_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal ValuationFactor { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityType_CanHaveDerivative_Name),
            Description = nameof(ModelDisplay.SecurityType_CanHaveDerivative_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool CanHaveDerivative { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityType_CanHavePosition_Name),
            Description = nameof(ModelDisplay.SecurityType_CanHavePosition_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool CanHavePosition { get; set; }
    }

    [MetadataType(typeof(SecurityTypeMetadata))]
    public partial class SecurityType
    {
    }
}
