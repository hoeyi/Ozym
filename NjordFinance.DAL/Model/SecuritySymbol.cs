using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("SecuritySymbol", Schema = "FinanceApp")]
    [Index(nameof(SecurityId), nameof(EffectiveDate), Name = "UNI_SecuritySymbol_Column", IsUnique = true)]
    public partial class SecuritySymbol
    {
        public SecuritySymbol()
        {
            SecuritySymbolMaps = new HashSet<SecuritySymbolMap>();
        }

        [Key]
        [Column("SymbolID")]
        public int SymbolId { get; set; }
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column("SymbolTypeID")]
        public int SymbolTypeId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? SymbolCode { get; set; }
        [StringLength(9)]
        [Unicode(false)]
        public string? Cusip { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? CustomSymbol { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? OptionTicker { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string? Ticker { get; set; }

        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("SecuritySymbols")]
        public virtual Security Security { get; set; } = null!;
        [ForeignKey(nameof(SymbolTypeId))]
        [InverseProperty(nameof(SecuritySymbolType.SecuritySymbols))]
        public virtual SecuritySymbolType SymbolType { get; set; } = null!;
        [InverseProperty(nameof(SecuritySymbolMap.SecuritySymbol))]
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
