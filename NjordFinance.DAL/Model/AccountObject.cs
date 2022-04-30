using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountObject", Schema = "FinanceApp")]
    [Index(nameof(AccountObjectCode), Name = "UNI_AccountObject_AccountObjectCode", IsUnique = true)]
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
        [StringLength(16)]
        [Unicode(false)]
        public string AccountObjectCode { get; set; } = null!;
        [StringLength(1)]
        [Unicode(false)]
        public string ObjectType { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CloseDate { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string ObjectDisplayName { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? ObjectDescription { get; set; }
        [StringLength(17)]
        [Unicode(false)]
        public string PrefixedObjectCode { get; set; } = null!;

        [InverseProperty("AccountNavigation")]
        public virtual Account Account { get; set; } = null!;
        [InverseProperty("AccountCompositeNavigation")]
        public virtual AccountComposite AccountComposite { get; set; } = null!;
        [InverseProperty(nameof(AccountAttributeMemberEntry.AccountObject))]
        public virtual ICollection<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentPerformanceAttributeMemberEntry.AccountObject))]
        public virtual ICollection<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(InvestmentPerformanceEntry.AccountObject))]
        public virtual ICollection<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; }
    }
}
