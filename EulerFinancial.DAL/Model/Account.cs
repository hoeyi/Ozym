﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("Account", Schema = "EulerApp")]
    public partial class Account
    {
        public Account()
        {
            AccountGroupMembers = new HashSet<AccountGroupMember>();
            AccountWallets = new HashSet<AccountWallet>();
            BankTransactions = new HashSet<BankTransaction>();
            BrokerTransactions = new HashSet<BrokerTransaction>();
        }

        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(64)]
        public string AccountNumber { get; set; }
        public short DisplayOrder { get; set; }
        [Column("AccountCustodianID")]
        public int? AccountCustodianId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BooksClosedDate { get; set; }
        public bool IsComplianceTradable { get; set; }
        public bool HasWallet { get; set; }
        public bool HasBankTransaction { get; set; }
        public bool HasBrokerTransaction { get; set; }

        [ForeignKey(nameof(AccountCustodianId))]
        [InverseProperty("Accounts")]
        public virtual AccountCustodian AccountCustodian { get; set; }
        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(AccountObject.Account))]
        public virtual AccountObject AccountNavigation { get; set; }
        [InverseProperty(nameof(AccountGroupMember.Account))]
        public virtual ICollection<AccountGroupMember> AccountGroupMembers { get; set; }
        [InverseProperty(nameof(AccountWallet.Account))]
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        [InverseProperty(nameof(BankTransaction.Account))]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
        [InverseProperty(nameof(BrokerTransaction.Account))]
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
