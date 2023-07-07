using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps security type and group entities to DTOs and vice versa. 
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="SecurityType"/> - <see cref="SecurityTypeDto"/></item>
    /// <item><see cref="SecurityTypeGroup"/> - <see cref="SecurityTypeGroupDto"/></item>
    /// </list>
    /// </remarks>
    public class SecurityTypeProfile : Profile
    {
        public SecurityTypeProfile()
        {
            #region Entity-DTO
            CreateMap<SecurityTypeGroup, SecurityTypeGroupDto>()
                .ForMember(
                    a => a.DisplayOrder, 
                    b => b.MapFrom(x => x.AttributeMemberNavigation.DisplayOrder));

            CreateMap<SecurityType, SecurityTypeDto>()
                .ForMember(
                    a => a.DisplayOrder, 
                    b => b.MapFrom(x => x.AttributeMemberNavigation.DisplayOrder));
            #endregion

            #region DTO-Entity
            CreateMap<SecurityTypeGroupDto, SecurityTypeGroup>()
                .ForMember(a => a.SecurityTypes, b => b.Ignore())
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayName,
                    b => b.MapFrom(x => x.SecurityTypeGroupName))
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayOrder,
                    b => b.MapFrom(x => x.DisplayOrder));

            CreateMap<SecurityTypeDto, SecurityType>()
                .ForMember(a => a.SecurityTypeGroup, b => b.Ignore())
                .ForMember(a => a.Securities, b => b.Ignore())
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayName,
                    b => b.MapFrom(x => x.SecurityTypeName))
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayOrder,
                    b => b.MapFrom(x => x.DisplayOrder));
            #endregion
        }
    }
}
