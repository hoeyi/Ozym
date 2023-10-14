using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Ozym.EntityModel.Metadata;

namespace Ozym.EntityModel
{
    [Table("SecuritySymbolMap", Schema = "FinanceApp")]
    [Index(nameof(AccountCustodianId), Name = "IX_SecuritySymbolMap_AccountCustodianID")]
    [Index(nameof(SecuritySymbolId), nameof(AccountCustodianId), Name = "UNI_SecuritySymbolMap_RowDef", IsUnique = true)]
    public partial class SecuritySymbolMap
    {
        [Key]
        [Column("SymbolMapID")]
        public int SymbolMapId { get; set; }
        [Column("AccountCustodianID")]
        public int AccountCustodianId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
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
