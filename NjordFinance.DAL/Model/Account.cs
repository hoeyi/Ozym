using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("Account", Schema = "FinanceApp")]
    [Index(nameof(AccountCustodianId), Name = "IX_Account_AccountCustodianID")]
    public partial class Account
    {
        public Account()
        {
            AccountCompositeMembers = new HashSet<AccountCompositeMember>();
            AccountWallets = new HashSet<AccountWallet>();
            BankTransactions = new HashSet<BankTransaction>();
            BrokerTransactions = new HashSet<BrokerTransaction>();
        }

        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string AccountNumber { get; set; }
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
        [InverseProperty(nameof(AccountCompositeMember.Account))]
        public virtual ICollection<AccountCompositeMember> AccountCompositeMembers { get; set; }
        [InverseProperty(nameof(AccountWallet.Account))]
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        [InverseProperty(nameof(BankTransaction.Account))]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
        [InverseProperty(nameof(BrokerTransaction.Account))]
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
