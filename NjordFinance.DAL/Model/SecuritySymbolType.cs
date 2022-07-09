using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("SecuritySymbolType", Schema = "FinanceApp")]
    public partial class SecuritySymbolType
    {
        public SecuritySymbolType()
        {
            SecuritySymbols = new HashSet<SecuritySymbol>();
        }

        [Key]
        [Column("SymbolTypeID")]
        public int SymbolTypeId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(32)]
        public string SymbolTypeName { get; set; }

        [InverseProperty(nameof(SecuritySymbol.SymbolType))]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
