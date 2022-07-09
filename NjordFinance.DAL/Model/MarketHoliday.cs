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
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string MarketHolidayName { get; set; }

        [InverseProperty(nameof(MarketHolidayObservance.MarketHoliday))]
        public virtual ICollection<MarketHolidayObservance> MarketHolidaySchedules { get; set; }
    }
}
