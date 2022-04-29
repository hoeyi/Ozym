using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("SecuritySymbolType", Schema = "EulerApp")]
    [Index(nameof(SymbolTypeName), Name = "UNI_SecuritySymbolType_TypeName", IsUnique = true)]
    public partial class SecuritySymbolType
    {
        public SecuritySymbolType()
        {
            SecuritySymbols = new HashSet<SecuritySymbol>();
        }

        [Key]
        [Column("SymbolTypeID")]
        public int SymbolTypeId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string SymbolTypeName { get; set; } = null!;

        [InverseProperty(nameof(SecuritySymbol.SymbolType))]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
