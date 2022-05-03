using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("InvestmentPerformanceAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AccountObjectId), Name = "IX_InvestmentPerformanceAttributeMemberEntry_AccountObjectID")]
    [Index(nameof(AttributeMemberId), Name = "IX_InvestmentPerformanceAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(FromDate), nameof(AccountObjectId), nameof(AttributeMemberId), Name = "UNI_InvestmentPerformanceAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class InvestmentPerformanceAttributeMemberEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AccountObjectID")]
        public int AccountObjectId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal MarketValue { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal NetContribution { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal AverageCapital { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Gain { get; set; }
        [Column("IRR", TypeName = "decimal(9, 4)")]
        public decimal Irr { get; set; }

        [ForeignKey(nameof(AccountObjectId))]
        [InverseProperty("InvestmentPerformanceAttributeMemberEntries")]
        public virtual AccountObject AccountObject { get; set; }
        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.InvestmentPerformanceAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
    }
}
