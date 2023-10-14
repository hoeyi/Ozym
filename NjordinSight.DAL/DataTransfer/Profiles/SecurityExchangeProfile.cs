using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps security exchange entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="SecurityExchange"/> - <see cref="SecurityExchangeDto"/></item>
    /// </list>
    /// </remarks>
    public class SecurityExchangeProfile : Profile
    {
        public SecurityExchangeProfile()
        {
            #region Entity-DTO
            CreateMap<SecurityExchange, SecurityExchangeDto>();
            #endregion

            #region DTO-Entity
            CreateMap<SecurityExchangeDto, SecurityExchange>()
                .ForMember(a => a.Securities, b => b.Ignore());
            #endregion
        }
    }
}
