using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

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
        [Required]
        [StringLength(72)]
        public string CustodianSymbol { get; set; }
        [Column("SecuritySymbolID")]
        public int SecuritySymbolId { get; set; }

        [ForeignKey(nameof(AccountCustodianId))]
        [InverseProperty("SecuritySymbolMaps")]
        public virtual AccountCustodian AccountCustodian { get; set; }
        [ForeignKey(nameof(SecuritySymbolId))]
        [InverseProperty("SecuritySymbolMaps")]
        public virtual SecuritySymbol SecuritySymbol { get; set; }
    }
}
