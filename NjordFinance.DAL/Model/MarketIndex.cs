using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
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
        [Required]
        [StringLength(12)]
        public string IndexCode { get; set; }
        [Required]
        [StringLength(128)]
        public string IndexDescription { get; set; }

        [InverseProperty(nameof(MarketIndexPrice.MarketIndex))]
        public virtual ICollection<MarketIndexPrice> MarketIndexPrices { get; set; }
    }
}
