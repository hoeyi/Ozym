using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

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
        [Required]
        [StringLength(10)]
        public string IndexCode { get; set; }
        [Required]
        [StringLength(128)]
        public string IndexDescription { get; set; }

        [InverseProperty(nameof(MarketIndexPrice.MarketIndex))]
        public virtual ICollection<MarketIndexPrice> MarketIndexPrices { get; set; }
    }
}
