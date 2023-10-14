using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using Ozym.EntityModel.Metadata;

namespace Ozym.EntityModel
{
    [Table("MarketIndexPrice", Schema = "FinanceApp")]
    [Index(nameof(MarketIndexId), Name = "IX_MarketIndexPrice_MarketIndexID")]
    [Noun(
        Plural = nameof(ModelNoun.MarketIndexPrice_Plural),
        PluralArticle = nameof(ModelNoun.MarketIndexPrice_PluralArticle),
        Singular = nameof(ModelNoun.MarketIndexPrice_Singular), 
        SingularArticle = nameof(ModelNoun.MarketIndexPrice_SingularArticle),
        ResourceType = typeof(ModelNoun))]
    public partial class MarketIndexPrice
    {
        [Key]
        [Column("IndexPriceID")]
        public int IndexPriceId { get; set; }
        [Column("MarketIndexID")]
        [Display(
            Name = nameof(ModelDisplay.MarketIndexPrice_MarketIndexID_Name),
            Description = nameof(ModelDisplay.MarketIndexPrice_MarketIndexID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int MarketIndexId { get; set; }
        [Column(TypeName = "date")]
        [Display(
            Name = nameof(ModelDisplay.MarketIndexPrice_PriceDate_Name),
            Description = nameof(ModelDisplay.MarketIndexPrice_PriceDate_Description),
            ResourceType = typeof(ModelDisplay))]
        [Searchable]
        public DateTime PriceDate { get; set; }
        [StringLength(1,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Display(
            Name = nameof(ModelDisplay.MarketIndexPrice_PriceCode_Name),
            Description = nameof(ModelDisplay.MarketIndexPrice_PriceCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Searchable]
        public string PriceCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        [Display(
            Name = nameof(ModelDisplay.MarketIndexPrice_Price_Name),
            Description = nameof(ModelDisplay.MarketIndexPrice_Price_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal Price { get; set; }

        [ForeignKey(nameof(MarketIndexId))]
        [InverseProperty("MarketIndexPrices")]
        public virtual MarketIndex MarketIndex { get; set; }
    }
}
