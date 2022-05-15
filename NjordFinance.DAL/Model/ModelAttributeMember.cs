using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ModelAttributeMember", Schema = "FinanceApp")]
    [Index(nameof(AttributeId), Name = "IX_ModelAttributeMember_AttributeID")]
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

        [Key]
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column("AttributeID")]
        public int AttributeId { get; set; }
        [Required]
        [StringLength(72)]
        public string DisplayName { get; set; }
        public short DisplayOrder { get; set; }

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty(nameof(ModelAttribute.ModelAttributeMembers))]
        public virtual ModelAttribute Attribute { get; set; }
        [InverseProperty("SecurityTypeNavigation")]
        public virtual SecurityType SecurityType { get; set; }
        [InverseProperty("SecurityTypeGroupNavigation")]
        public virtual SecurityTypeGroup SecurityTypeGroup { get; set; }
        [InverseProperty(nameof(AccountAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BankTransactionCodeAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BrokerTransactionCodeAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(CountryAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentPerformanceAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentStrategyTarget.AttributeMember))]
        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
        [InverseProperty(nameof(SecurityAttributeMemberEntry.AttributeMember))]
        public virtual ICollection<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
    }
}
