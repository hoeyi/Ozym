using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("MarketIndexPrice", Schema = "EulerApp")]
    [Index(nameof(PriceDate), nameof(MarketIndexId), nameof(PriceCode), Name = "UNI_MarketIndexPrice_RowDef", IsUnique = true)]
    public partial class MarketIndexPrice
    {
        [Key]
        [Column("IndexPriceID")]
        public int IndexPriceId { get; set; }
        [Column("MarketIndexID")]
        public int MarketIndexId { get; set; }
        [Column(TypeName = "date")]
        public DateTime PriceDate { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string PriceCode { get; set; } = null!;
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(MarketIndexId))]
        [InverseProperty("MarketIndexPrices")]
        public virtual MarketIndex MarketIndex { get; set; } = null!;
    }
}
