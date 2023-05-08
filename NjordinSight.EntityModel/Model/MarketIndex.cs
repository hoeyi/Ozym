using NjordinSight.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordinSight.EntityModel
{
    [Table("MarketIndex", Schema = "FinanceApp")]
    public partial class MarketIndex
    {
        public MarketIndex()
        {
            MarketIndexPrices = new HashSet<MarketIndexPrice>();
        }

        [Key]
        [Column("IndexID")]
        public int IndexId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string IndexCode { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string IndexDescription { get; set; }

        [InverseProperty(nameof(MarketIndexPrice.MarketIndex))]
        public virtual ICollection<MarketIndexPrice> MarketIndexPrices { get; set; }
    }
}
