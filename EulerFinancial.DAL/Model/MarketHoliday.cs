using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("MarketHoliday", Schema = "EulerApp")]
    [Index(nameof(MarketHolidayName), Name = "UNI_MarketHoliday_MarketHolidayName", IsUnique = true)]
    public partial class MarketHoliday
    {
        public MarketHoliday()
        {
            MarketHolidaySchedules = new HashSet<MarketHolidaySchedule>();
        }

        [Key]
        [Column("MarketHolidayID")]
        public int MarketHolidayId { get; set; }
        [StringLength(72)]
        public string MarketHolidayName { get; set; } = null!;

        [InverseProperty(nameof(MarketHolidaySchedule.MarketHoliday))]
        public virtual ICollection<MarketHolidaySchedule> MarketHolidaySchedules { get; set; }
    }
}
