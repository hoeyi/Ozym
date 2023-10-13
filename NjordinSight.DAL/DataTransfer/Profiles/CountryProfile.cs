using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.ConstraintType;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps country-related entities to DTOs and vice versa. Requires 
    /// <see cref="ModelAttributeProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="CountryAttributeMemberEntry"/> - <see cref="CountryAttributeDto"/></item>
    /// <item><see cref="Country"/> - <see cref="CountryDto"/></item>
    /// </list>
    /// </remarks>
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            #region Entity-DTO
            CreateMap<CountryAttributeMemberEntry, CountryAttributeDto>()
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<Country, CountryDtoBase>()
                .ForMember(a => a.DisplayOrder, b => b.MapFrom(x => x.AttributeMemberNavigation.DisplayOrder));

            CreateMap<Country, CountryDto>()
                .ForMember(
                    a => a.Attributes,
                    b => b.MapFrom(x => x.CountryAttributeMemberEntries))
                .ForMember(
                    a => a.DisplayOrder, 
                    b => b.MapFrom(x => x.AttributeMemberNavigation.DisplayOrder))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());
            #endregion

            #region DTO-Entity
            CreateMap<CountryAttributeDto, CountryAttributeMemberEntry>()
                .ForMember(
                    a => a.AttributeMemberId,
                    b => b.MapFrom(x => x.AttributeMemberId))
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight))
                .ForMember(a => a.AttributeMember, b => b.Ignore())
                .ForMember(a => a.Country, b => b.Ignore());

            CreateMap<CountryDto, Country>()
                .ForMember(
                    a => a.CountryAttributeMemberEntries, b => b.MapFrom(x => x.Attributes))
                .ForPath(
                    a => a.AttributeMemberNavigation.AttributeId, 
                    b => b.MapFrom(x => (int)ModelAttributeEnum.CountryExposure))
                .ForPath(
                    a => a.AttributeMemberNavigation.AttributeMemberId,
                    b => b.MapFrom(x => x.CountryId))
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayName,
                    b => b.MapFrom(x => x.IsoCode3))
                .ForPath(
                    a => a.AttributeMemberNavigation.DisplayOrder,
                    b => b.MapFrom(x => x.DisplayOrder));
            #endregion
        }
    }
}
