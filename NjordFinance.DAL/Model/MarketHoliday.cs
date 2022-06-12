using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("MarketHoliday", Schema = "FinanceApp")]
    public partial class MarketHoliday
    {
        public MarketHoliday()
        {
            MarketHolidaySchedules = new HashSet<MarketHolidayObservance>();
        }

        [Key]
        [Column("MarketHolidayID")]
        public int MarketHolidayId { get; set; }
        [Required]
        [StringLength(72)]
        public string MarketHolidayName { get; set; }

        [InverseProperty(nameof(MarketHolidayObservance.MarketHoliday))]
        public virtual ICollection<MarketHolidayObservance> MarketHolidaySchedules { get; set; }
    }
}
