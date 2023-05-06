using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.EntityModel
{
    [Table("InvestmentPerformanceAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AccountObjectId), Name = "IX_InvestmentPerformanceAttributeMemberEntry_AccountObjectID")]
    [Index(nameof(AttributeMemberId), Name = "IX_InvestmentPerformanceAttributeMemberEntry_AttributeMemberID")]
    public partial class InvestmentPerformanceAttributeMemberEntry
    {
        [Key]
        [Column("AccountObjectID", Order = 0)]
        public int AccountObjectId { get; set; }
        [Key]
        [Column("AttributeMemberID", Order = 1)]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 2)]
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
