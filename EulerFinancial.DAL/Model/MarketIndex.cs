using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("MarketIndex", Schema = "EulerApp")]
    [Index(nameof(IndexCode), Name = "UNI_MarketIndex_IndexCode", IsUnique = true)]
    public partial class MarketIndex
    {
        public MarketIndex()
        {
            MarketIndexPrices = new HashSet<MarketIndexPrice>();
        }

        [Key]
        [Column("IndexID")]
        public int IndexId { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string IndexCode { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string IndexDescription { get; set; } = null!;

        [InverseProperty(nameof(MarketIndexPrice.MarketIndex))]
        public virtual ICollection<MarketIndexPrice> MarketIndexPrices { get; set; }
    }
}
