﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("MarketHolidaySchedule", Schema = "EulerApp")]
    [Index(nameof(ObservanceDate), nameof(MarketHolidayId), Name = "UNI_MarketHolidaySchedule_RowDef", IsUnique = true)]
    public partial class MarketHolidaySchedule
    {
        [Key]
        [Column("MarketHolidayEntryID")]
        public int MarketHolidayEntryId { get; set; }
        [Column("MarketHolidayID")]
        public int MarketHolidayId { get; set; }
        [Column(TypeName = "date")]
        public DateTime ObservanceDate { get; set; }

        [ForeignKey(nameof(MarketHolidayId))]
        [InverseProperty("MarketHolidaySchedules")]
        public virtual MarketHoliday MarketHoliday { get; set; }
    }
}
