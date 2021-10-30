using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class Account
    {
        public Account()
        {
            AccountGroupMembers = new HashSet<AccountGroupMember>();
            AccountWallets = new HashSet<AccountWallet>();
            BankTransactions = new HashSet<BankTransaction>();
            BrokerTransactions = new HashSet<BrokerTransaction>();
        }

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public short DisplayOrder { get; set; }
        public int? AccountCustodianId { get; set; }
        public DateTime? BooksClosedDate { get; set; }
        public bool IsComplianceTradable { get; set; }
        public bool HasWallet { get; set; }
        public bool HasBankTransaction { get; set; }
        public bool HasBrokerTransaction { get; set; }

        public virtual AccountCustodian AccountCustodian { get; set; }
        public virtual AccountObject AccountNavigation { get; set; }
        public virtual ICollection<AccountGroupMember> AccountGroupMembers { get; set; }
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
