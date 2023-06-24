using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class MarketHolidayDto : DtoBase
    {
        private int _marketHolidayId;
        private string _marketHolidayName;

        [Display(
            Name = nameof(MarketHolidayDto_SR.MarketHolidayId_Name),
            Description = nameof(MarketHolidayDto_SR.MarketHolidayId_Description),
            ResourceType = typeof(MarketHolidayDto_SR))]
        public int MarketHolidayId
        {
            get { return _marketHolidayId; }
            set
            {
                if (_marketHolidayId != value)
                {
                    _marketHolidayId = value;
                    OnPropertyChanged(nameof(MarketHolidayId));
                }
            }
        }

        [Display(
            Name = nameof(MarketHolidayDto_SR.MarketHolidayName_Name),
            Description = nameof(MarketHolidayDto_SR.MarketHolidayName_Description),
            ResourceType = typeof(MarketHolidayDto_SR))]
        public string MarketHolidayName
        {
            get { return _marketHolidayName; }
            set
            {
                if (_marketHolidayName != value)
                {
                    _marketHolidayName = value;
                    OnPropertyChanged(nameof(MarketHolidayName));
                }
            }
        }
    }

}
