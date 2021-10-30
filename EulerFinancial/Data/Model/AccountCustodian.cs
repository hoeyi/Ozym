using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountCustodian
    {
        public AccountCustodian()
        {
            Accounts = new HashSet<Account>();
            SecuritySymbolMaps = new HashSet<SecuritySymbolMap>();
        }

        public int AccountCustodianId { get; set; }
        public string CustodianCode { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
