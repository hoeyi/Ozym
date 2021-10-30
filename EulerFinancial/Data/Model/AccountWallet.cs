using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountWallet
    {
        public int AccountWalletId { get; set; }
        public int AccountId { get; set; }
        public string AddressCode { get; set; }
        public string AddressTag { get; set; }
        public int DenominationSecurityId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Security DenominationSecurity { get; set; }
    }
}
