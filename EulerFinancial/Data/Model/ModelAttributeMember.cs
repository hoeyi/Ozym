using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ModelAttributeMember
    {
        public ModelAttributeMember()
        {
            AccountAttributeMemberEntries = new HashSet<AccountAttributeMemberEntry>();
            BankTransactionCodeAttributeMemberEntries = new HashSet<BankTransactionCodeAttributeMemberEntry>();
            BrokerTransactionCodeAttributeMemberEntries = new HashSet<BrokerTransactionCodeAttributeMemberEntry>();
            CountryAttributeMemberEntries = new HashSet<CountryAttributeMemberEntry>();
            InvestmentPerformanceAttributeMemberEntries = new HashSet<InvestmentPerformanceAttributeMemberEntry>();
            InvestmentStrategyTargets = new HashSet<InvestmentStrategyTarget>();
            SecurityAttributeMemberEntries = new HashSet<SecurityAttributeMemberEntry>();
        }

        public int AttributeMemberId { get; set; }
        public int AttributeId { get; set; }
        public string DisplayName { get; set; }
        public short? DisplayOrder { get; set; }

        public virtual ModelAttribute Attribute { get; set; }
        public virtual ICollection<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        public virtual ICollection<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        public virtual ICollection<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
        public virtual ICollection<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
        public virtual ICollection<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
    }
}
