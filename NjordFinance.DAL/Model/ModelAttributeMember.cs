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
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string DisplayName { get; set; }
        public short DisplayOrder { get; set; }
        [ForeignKey(nameof(AttributeId))]
        [InverseProperty(nameof(ModelAttribute.ModelAttributeMembers))]
        public virtual ModelAttribute Attribute { get; set; }
        [InverseProperty("AttributeMemberNavigation")]
        public virtual SecurityType SecurityType { get; set; }
        [InverseProperty("AttributeMemberNavigation")]
        public virtual SecurityTypeGroup SecurityTypeGroup { get; set; }
        [InverseProperty("AttributeMemberNavigation")]
        public virtual Country Country { get; set; }
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
