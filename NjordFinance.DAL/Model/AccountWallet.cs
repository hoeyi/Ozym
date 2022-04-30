using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountWallet", Schema = "EulerApp")]
    [Index(nameof(DenominationSecurityId), nameof(AccountId), Name = "UNI_AccountWallet_RowDef", IsUnique = true)]
    public partial class AccountWallet
    {
        [Key]
        [Column("AccountWalletID")]
        public int AccountWalletId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string AddressCode { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string AddressTag { get; set; } = null!;
        [Column("DenominationSecurityID")]
        public int DenominationSecurityId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountWallets")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(DenominationSecurityId))]
        [InverseProperty(nameof(Security.AccountWallets))]
        public virtual Security DenominationSecurity { get; set; } = null!;
    }
}
