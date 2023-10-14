using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(MarketHolidayDto_SR.Noun_Plural),
        PluralArticle = nameof(MarketHolidayDto_SR.Noun_Plural_Article),
        Singular = nameof(MarketHolidayDto_SR.Noun_Singular),
        SingularArticle = nameof(MarketHolidayDto_SR.Noun_Singular_Article),
        ResourceType = typeof(MarketHolidayDto_SR)
        )]
    public class MarketHolidayDto : DtoBase
    {
        private int _marketHolidayId;
        private string _marketHolidayName;

        [Key]
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
