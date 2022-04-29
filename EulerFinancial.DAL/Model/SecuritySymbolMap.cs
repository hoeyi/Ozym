using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("SecuritySymbolMap", Schema = "EulerApp")]
    [Index(nameof(SecuritySymbolId), nameof(AccountCustodianId), Name = "UNI_SecuritySymbolMap_RowDef", IsUnique = true)]
    public partial class SecuritySymbolMap
    {
        [Key]
        [Column("SymbolMapID")]
        public int SymbolMapId { get; set; }
        [Column("AccountCustodianID")]
        public int AccountCustodianId { get; set; }
        [StringLength(72)]
        [Unicode(false)]
        public string CustodianSymbol { get; set; } = null!;
        [Column("SecuritySymbolID")]
        public int SecuritySymbolId { get; set; }

        [ForeignKey(nameof(AccountCustodianId))]
        [InverseProperty("SecuritySymbolMaps")]
        public virtual AccountCustodian AccountCustodian { get; set; } = null!;
        [ForeignKey(nameof(SecuritySymbolId))]
        [InverseProperty("SecuritySymbolMaps")]
        public virtual SecuritySymbol SecuritySymbol { get; set; } = null!;
    }
}
