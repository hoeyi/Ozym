using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountWallet", Schema = "FinanceApp")]
    [Index(nameof(AccountId), Name = "IX_AccountWallet_AccountID")]
    [Index(nameof(DenominationSecurityId), nameof(AccountId), Name = "UNI_AccountWallet_RowDef", IsUnique = true)]
    public partial class AccountWallet
    {
        [Key]
        [Column("AccountWalletID")]
        public int AccountWalletId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(256,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string AddressCode { get; set; }
        [StringLength(256,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string AddressTag { get; set; }
        [Column("DenominationSecurityID")]
        public int DenominationSecurityId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountWallets")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(DenominationSecurityId))]
        [InverseProperty(nameof(Security.AccountWallets))]
        public virtual Security DenominationSecurity { get; set; }
    }
}
