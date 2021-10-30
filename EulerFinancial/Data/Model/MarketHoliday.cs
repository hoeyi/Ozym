using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class MarketHoliday
    {
        public MarketHoliday()
        {
            MarketHolidaySchedules = new HashSet<MarketHolidaySchedule>();
        }

        public int MarketHolidayId { get; set; }
        public string MarketHolidayName { get; set; }

        public virtual ICollection<MarketHolidaySchedule> MarketHolidaySchedules { get; set; }
    }
}
