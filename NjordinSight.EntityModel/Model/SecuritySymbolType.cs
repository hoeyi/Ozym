using NjordinSight.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordinSight.EntityModel
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
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SymbolTypeName { get; set; }

        [InverseProperty(nameof(SecuritySymbol.SymbolType))]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
