using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps security price entities to DTOs and vice versa. 
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="SecurityPrice"/> - <see cref="SecurityPriceDto"/></item>
    /// </list>
    /// </remarks>
    public class SecurityPriceProfile : Profile
    {
        public SecurityPriceProfile()
        {
            #region Entity-DTO
            CreateMap<SecurityPrice, SecurityPriceDto>();
            #endregion

            #region DTO-Entity
            CreateMap<SecurityPriceDto, SecurityPrice>()
                .ForMember(a => a.Security, b => b.Ignore());
            #endregion
        }
    }
}
