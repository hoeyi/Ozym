using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;
using AutoMapper;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps market holiday and holiday observance entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="MarketHolidayObservance"/> - <see cref="MarketHolidayObservanceDto"/></item>
    /// <item><see cref="MarketHoliday"/> - <see cref="MarketHolidayDto"/></item>
    /// </list>
    /// </remarks>
    public class MarketHolidayProfile : Profile
    {
        public MarketHolidayProfile()
        {
            #region Entity-DTO
            CreateMap<MarketHolidayObservance, MarketHolidayObservanceDto>();

            CreateMap<MarketHoliday, MarketHolidayDto>();

            #endregion

            #region DTO-Entity
            CreateMap<MarketHolidayObservanceDto, MarketHolidayObservance>()
                .ForMember(a => a.MarketHoliday, b => b.Ignore());

            CreateMap<MarketHolidayDto, MarketHoliday>()
                .ForMember(a => a.MarketHolidaySchedules, b => b.Ignore());
            #endregion
        }
    }
}
