using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("MarketHolidayObservance", Schema = "FinanceApp")]
    [Index(nameof(MarketHolidayId), Name = "IX_MarketHolidaySchedule_MarketHolidayID")]
    public partial class MarketHolidayObservance
    {
        [Key]
        [Column("MarketHolidayID", Order = 0)]
        public int MarketHolidayId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 1)]
        public DateTime ObservanceDate { get; set; }

        [ForeignKey(nameof(MarketHolidayId))]
        [InverseProperty("MarketHolidaySchedules")]
        public virtual MarketHoliday MarketHoliday { get; set; }
    }
}
