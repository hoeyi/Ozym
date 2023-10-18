using System.ComponentModel.DataAnnotations;
using Ozym.EntityModel.Metadata;
using Ichosys.DataModel.Annotations;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="SecuritySymbolType"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.SecuritySymbolType_Plural),
        PluralArticle = nameof(ModelNoun.SecuritySymbolType_PluralArticle),
        Singular = nameof(ModelNoun.SecuritySymbolType_Singular),
        SingularArticle = nameof(ModelNoun.SecuritySymbolType_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecuritySymbolTypeMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbolType_SymbolTypeName_Name),
            Description = nameof(ModelDisplay.SecuritySymbolType_SymbolTypeName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SymbolTypeName { get; set; }
    }

    [MetadataType(typeof(SecuritySymbolTypeMetadata))]
    public partial class SecuritySymbolType
    {
    }
}
