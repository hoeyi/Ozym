using Ichosys.DataModel.Annotations;
using NjordinSight.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="SecurityPrice"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.SecurityPrice_Plural),
        PluralArticle = nameof(ModelNoun.SecurityPrice_PluralArticle),
        Singular = nameof(ModelNoun.SecurityPrice_Singular),
        SingularArticle = nameof(ModelNoun.SecurityPrice_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecurityPriceMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_SecurityID_Name),
            Description = nameof(ModelDisplay.SecurityPrice_SecurityID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SecurityId { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_PriceDate_Name),
            Description = nameof(ModelDisplay.SecurityPrice_PriceDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime PriceDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_PriceClose_Name),
            Description = nameof(ModelDisplay.SecurityPrice_PriceClose_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal PriceClose { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_PriceOpen_Name),
            Description = nameof(ModelDisplay.SecurityPrice_PriceOpen_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? PriceOpen { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_PriceHigh_Name),
            Description = nameof(ModelDisplay.SecurityPrice_PriceHigh_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? PriceHigh { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_PriceLow_Name),
            Description = nameof(ModelDisplay.SecurityPrice_PriceOpen_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? PriceLow { get; set; }

        [Display(
            Name = nameof(ModelDisplay.SecurityPrice_Volume_Name),
            Description = nameof(ModelDisplay.SecurityPrice_Volume_Description),
            ResourceType = typeof(ModelDisplay))]
        public long? Volume { get; set; }
    }

    [MetadataType(typeof(SecurityPriceMetadata))]
    public partial class SecurityPrice
    {
    }
}
