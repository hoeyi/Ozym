using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

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
        [Required]
        [StringLength(32)]
        public string SymbolTypeName { get; set; }

        [InverseProperty(nameof(SecuritySymbol.SymbolType))]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
