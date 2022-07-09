using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("AccountObject", Schema = "FinanceApp")]
    public partial class AccountObject
    {
        public AccountObject()
        {
            AccountAttributeMemberEntries = new HashSet<AccountAttributeMemberEntry>();
            InvestmentPerformanceAttributeMemberEntries = new HashSet<InvestmentPerformanceAttributeMemberEntry>();
            InvestmentPerformanceEntries = new HashSet<InvestmentPerformanceEntry>();
        }

        [Key]
        [Column("AccountObjectID")]
        public int AccountObjectId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(12)]
        public string AccountObjectCode { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(1)]
        public string ObjectType { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CloseDate { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72)]
        public string ObjectDisplayName { get; set; }
        [StringLength(128)]
        public string ObjectDescription { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(13)]
        public string PrefixedObjectCode { get; set; }

        [InverseProperty("AccountNavigation")]
        public virtual Account Account { get; set; }
        [InverseProperty("AccountCompositeNavigation")]
        public virtual AccountComposite AccountComposite { get; set; }
        [InverseProperty(nameof(AccountAttributeMemberEntry.AccountObject))]
        public virtual ICollection<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentPerformanceAttributeMemberEntry.AccountObject))]
        public virtual ICollection<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentPerformanceEntry.AccountObject))]
        public virtual ICollection<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; }
    }
}
