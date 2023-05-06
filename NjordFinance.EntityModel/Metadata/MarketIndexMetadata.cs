using NjordFinance.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.EntityModel
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
