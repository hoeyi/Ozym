using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
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
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
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
