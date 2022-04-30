using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("InvestmentPerformanceEntry", Schema = "EulerApp")]
    [Index(nameof(FromDate), nameof(AccountObjectId), Name = "UNI_InvestmentPerformanceEntry_RowDef", IsUnique = true)]
    public partial class InvestmentPerformanceEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AccountObjectID")]
        public int AccountObjectId { get; set; }
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
        [InverseProperty("InvestmentPerformanceEntries")]
        public virtual AccountObject AccountObject { get; set; } = null!;
    }
}
