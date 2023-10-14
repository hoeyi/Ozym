using Ozym.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozym.EntityModel
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
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string MarketHolidayName { get; set; }

        [InverseProperty(nameof(MarketHolidayObservance.MarketHoliday))]
        public virtual ICollection<MarketHolidayObservance> MarketHolidaySchedules { get; set; }
    }
}
