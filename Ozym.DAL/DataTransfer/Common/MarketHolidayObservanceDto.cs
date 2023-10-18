using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(MarketHolidayObservanceDto_SR.Noun_Plural),
        PluralArticle = nameof(MarketHolidayObservanceDto_SR.Noun_Plural_Article),
        Singular = nameof(MarketHolidayObservanceDto_SR.Noun_Singular),
        SingularArticle = nameof(MarketHolidayObservanceDto_SR.Noun_Singular_Article),
        ResourceType = typeof(MarketHolidayObservanceDto_SR)
        )]
    public class MarketHolidayObservanceDto : DtoBase
    {
        private int _marketHolidayId;
        private DateTime _observanceDate;

        [Display(
            Name = nameof(MarketHolidayObservanceDto_SR.MarketHolidayId_Name),
            Description = nameof(MarketHolidayObservanceDto_SR.MarketHolidayId_Description),
            ResourceType = typeof(MarketHolidayObservanceDto_SR))]
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
            Name = nameof(MarketHolidayObservanceDto_SR.ObservanceDate_Name),
            Description = nameof(MarketHolidayObservanceDto_SR.ObservanceDate_Description),
            ResourceType = typeof(MarketHolidayObservanceDto_SR))]
        public DateTime ObservanceDate
        {
            get { return _observanceDate; }
            set
            {
                if (_observanceDate != value)
                {
                    _observanceDate = value;
                    OnPropertyChanged(nameof(ObservanceDate));
                }
            }
        }
    }

}
