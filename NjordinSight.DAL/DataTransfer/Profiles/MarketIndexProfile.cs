using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps market index and index prices entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="MarketIndexPrice"/> - <see cref="MarketIndexPriceDtoBase"/></item>
    /// <item><see cref="MarketIndex"/> - <see cref="MarketIndexDto"/></item>
    /// </list>
    /// </remarks>
    public class MarketIndexProfile : Profile
    {
        public MarketIndexProfile()
        {
            #region Entity-DTO
            CreateMap<MarketIndex, MarketIndexDto>();

            CreateMap<MarketIndexPrice, MarketIndexPriceDtoBase>();
            #endregion

            #region DTO-Entity

            CreateMap<MarketIndexDto, MarketIndex>()
                .ForMember(a => a.MarketIndexPrices, b => b.Ignore());

            CreateMap<MarketIndexPriceDtoBase, MarketIndexPrice>()
                .ForMember(a => a.MarketIndex, b => b.Ignore());
            #endregion
        }
    }
}
