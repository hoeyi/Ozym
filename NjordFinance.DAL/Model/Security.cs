using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("Security", Schema = "FinanceApp")]
    public partial class Security
    {
        public Security()
        {
            AccountWallets = new HashSet<AccountWallet>();
            BrokerTransactionDepSecurities = new HashSet<BrokerTransaction>();
            BrokerTransactionSecurities = new HashSet<BrokerTransaction>();
            SecurityAttributeMemberEntries = new HashSet<SecurityAttributeMemberEntry>();
            SecurityPrices = new HashSet<SecurityPrice>();
            SecuritySymbols = new HashSet<SecuritySymbol>();
        }

        [Key]
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column("SecurityTypeID")]
        public int SecurityTypeId { get; set; }
        [Column("SecurityExchangeID")]
        public int? SecurityExchangeId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string SecurityDescription { get; set; } = null!;
        [StringLength(96)]
        public string Issuer { get; set; } = null!;
        public bool HasPerpetualMarket { get; set; }
        public bool HasPerpetualPrice { get; set; }

        [ForeignKey(nameof(SecurityExchangeId))]
        [InverseProperty("Securities")]
        public virtual SecurityExchange? SecurityExchange { get; set; }
        [ForeignKey(nameof(SecurityTypeId))]
        [InverseProperty("Securities")]
        public virtual SecurityType SecurityType { get; set; } = null!;
        [InverseProperty(nameof(AccountWallet.DenominationSecurity))]
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        [InverseProperty(nameof(BrokerTransaction.DepSecurity))]
        public virtual ICollection<BrokerTransaction> BrokerTransactionDepSecurities { get; set; }
        [InverseProperty(nameof(BrokerTransaction.Security))]
        public virtual ICollection<BrokerTransaction> BrokerTransactionSecurities { get; set; }
        [InverseProperty(nameof(SecurityAttributeMemberEntry.Security))]
        public virtual ICollection<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(SecurityPrice.Security))]
        public virtual ICollection<SecurityPrice> SecurityPrices { get; set; }
        [InverseProperty(nameof(SecuritySymbol.Security))]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
