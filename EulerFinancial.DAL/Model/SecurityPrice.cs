using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("SecurityPrice", Schema = "EulerApp")]
    [Index(nameof(PriceDate), nameof(SecurityId), Name = "UNI_SecurityPrice_RowDef", IsUnique = true)]
    public partial class SecurityPrice
    {
        [Key]
        [Column("PriceID")]
        public int PriceId { get; set; }
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column(TypeName = "date")]
        public DateTime PriceDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal PriceClose { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceOpen { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceHigh { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceLow { get; set; }
        public long? Volume { get; set; }

        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("SecurityPrices")]
        public virtual Security Security { get; set; }
    }
}
