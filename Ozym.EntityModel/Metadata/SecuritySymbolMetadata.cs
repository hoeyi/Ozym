using Ichosys.DataModel.Annotations;
using Ozym.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="SecuritySymbol"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.SecuritySymbol_Plural),
        PluralArticle = nameof(ModelNoun.SecuritySymbol_PluralArticle),
        Singular = nameof(ModelNoun.SecuritySymbol_Singular),
        SingularArticle = nameof(ModelNoun.SecuritySymbol_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecuritySymbolMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_EffectiveDate_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_EffectiveDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate { get; set; }
        
        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_SymbolTypeID_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_SymbolTypeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SymbolTypeId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_SymbolCode_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_SymbolCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SymbolCode { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_Cusip_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_Cusip_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Cusip { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_CustomSymbol_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_CustomSymbol_Description),
            ResourceType = typeof(ModelDisplay))]
        public string CustomSymbol { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_OptionTicker_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_OptionTicker_Description),
            ResourceType = typeof(ModelDisplay))]
        public string OptionTicker { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecuritySymbol_Ticker_Name),
            Description = nameof(ModelDisplay.SecuritySymbol_Ticker_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Ticker { get; set; }
    }

    [MetadataType(typeof(SecuritySymbolMetadata))]
    public partial class SecuritySymbol
    {
    }
}
