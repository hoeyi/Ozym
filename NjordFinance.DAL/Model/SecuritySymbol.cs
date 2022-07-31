using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model.Metadata;

namespace NjordFinance.Model
{
    [Table("SecuritySymbol", Schema = "FinanceApp")]
    [Index(nameof(SymbolTypeId), Name = "IX_SecuritySymbol_SymbolTypeID")]
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
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SymbolCode { get; set; }
        [StringLength(9,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Cusip { get; set; }
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string CustomSymbol { get; set; }
        [StringLength(24,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string OptionTicker { get; set; }
        [StringLength(8,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Ticker { get; set; }

        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("SecuritySymbols")]
        public virtual Security Security { get; set; }
        [ForeignKey(nameof(SymbolTypeId))]
        [InverseProperty(nameof(SecuritySymbolType.SecuritySymbols))]
        public virtual SecuritySymbolType SymbolType { get; set; }
        [InverseProperty(nameof(SecuritySymbolMap.SecuritySymbol))]
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
