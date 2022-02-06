using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("AccountWallet", Schema = "EulerApp")]
    [Index(nameof(AddressCode), Name = "UNI_AccountWallet_AddressCode", IsUnique = true)]
    [Index(nameof(AddressTag), Name = "UNI_AccountWallet_AddressTag", IsUnique = true)]
    [Index(nameof(DenominationSecurityId), nameof(AccountId), Name = "UNI_AccountWallet_RowDef", IsUnique = true)]
    public partial class AccountWallet
    {
        [Key]
        [Column("AccountWalletID")]
        public int AccountWalletId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(256)]
        public string AddressCode { get; set; }
        [Required]
        [StringLength(256)]
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
