using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="MarketIndex"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.MarketIndex_Plural),
        PluralArticle = nameof(ModelNoun.MarketIndex_PluralArticle),
        Singular = nameof(ModelNoun.MarketIndex_Singular),
        SingularArticle = nameof(ModelNoun.MarketIndex_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class MarketIndexMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.MarketIndex_IndexCode_Name),
            Description = nameof(ModelDisplay.MarketIndex_IndexCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string IndexCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.MarketIndex_IndexDescription_Name),
            Description = nameof(ModelDisplay.MarketIndex_IndexDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string IndexDescription { get; set; }
    }

    [MetadataType(typeof(MarketIndexMetadata))]
    public partial class MarketIndex
    {
    }
}
