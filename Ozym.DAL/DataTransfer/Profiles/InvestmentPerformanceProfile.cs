using AutoMapper;
using Ozym.EntityModel;
using Ozym.DataTransfer.Common;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Maps account-related entities to DTOs and vice versa. Requires 
    /// <see cref="ModelAttributeProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="InvestmentPerformanceEntry"/> - <see cref="InvestmentPerformanceDto"/></item>
    /// </list>
    /// </remarks>
    public class InvestmentPerformanceProfile : Profile
    {
        public InvestmentPerformanceProfile()
        {
            #region Entity-DTO
            CreateMap<InvestmentPerformanceEntry, InvestmentPerformanceDto>()
                .ForMember(a => a.AccountBaseId, b => b.MapFrom(x => x.AccountObjectId));

            CreateMap<InvestmentPerformanceAttributeMemberEntry, InvestmentPerformanceAttributeDto>()
                .ForMember(a => a.AccountBaseId, b => b.MapFrom(x => x.AccountObjectId))
                .ForMember(a => a.Attribute, b => b.MapFrom(x => x.AttributeMember.Attribute));
            #endregion


            #region DTO-Entity
            CreateMap<InvestmentPerformanceDto, InvestmentPerformanceEntry>()
                .ForMember(a => a.AccountObjectId, b => b.MapFrom(x => x.AccountBaseId))
                .ForMember(a => a.AccountObject, b => b.Ignore());

            CreateMap<InvestmentPerformanceAttributeDto, InvestmentPerformanceAttributeMemberEntry>()
                .ForMember(a => a.AccountObjectId, b => b.MapFrom(x => x.AccountBaseId))
                .ForMember(a => a.AccountObject, b => b.Ignore())
                .ForMember(a => a.AttributeMember, b => b.Ignore());
            #endregion
        }
    }
}
