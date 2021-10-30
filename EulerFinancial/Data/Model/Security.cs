using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
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

        public int SecurityId { get; set; }
        public int SecurityTypeId { get; set; }
        public int? SecurityExchangeId { get; set; }
        public string SecurityDescription { get; set; }
        public string CurrentSymbol { get; set; }
        public string Issuer { get; set; }
        public bool HasPerpetualMarket { get; set; }
        public bool HasPerpetualPrice { get; set; }

        public virtual SecurityExchange SecurityExchange { get; set; }
        public virtual SecurityType SecurityType { get; set; }
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        public virtual ICollection<BrokerTransaction> BrokerTransactionDepSecurities { get; set; }
        public virtual ICollection<BrokerTransaction> BrokerTransactionSecurities { get; set; }
        public virtual ICollection<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
        public virtual ICollection<SecurityPrice> SecurityPrices { get; set; }
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
