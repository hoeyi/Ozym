using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class MarketHolidaySchedule
    {
        public int MarketHolidayEntryId { get; set; }
        public int MarketHolidayId { get; set; }
        public DateTime ObservanceDate { get; set; }

        public virtual MarketHoliday MarketHoliday { get; set; }
    }
}
