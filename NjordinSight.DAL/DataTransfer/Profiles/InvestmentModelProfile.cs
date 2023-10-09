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
    /// Maps investment model and related entities to DTOs and vice versa. Requires 
    /// <see cref="ModelAttributeProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="InvestmentStrategyTarget"/> - <see cref="InvestmentModelTargetDto"/></item>
    /// <item><see cref="InvestmentStrategy"/> - <see cref="InvestmentModelDto"/></item>
    /// </list>
    /// </remarks>
    public class InvestmentModelProfile : Profile
    {
        public InvestmentModelProfile()
        {
            #region Entity-DTO
            CreateMap<InvestmentStrategyTarget, InvestmentModelTargetDto>()
                .ForMember(a => a.InvestmentModelId, b => b.MapFrom(x => x.InvestmentStrategyId))
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<InvestmentStrategy, InvestmentModelDto>()
                .ForMember(a => a.InvestmentModelId, b => b.MapFrom(x => x.InvestmentStrategyId))
                .ForMember(a => a.TargetCollection, b => b.Ignore())
                .ForMember(
                    a => a.Targets,
                    b => b.MapFrom(x => x.InvestmentStrategyTargets));
            #endregion

            #region DTO-Entity
            CreateMap<InvestmentModelTargetDto, InvestmentStrategyTarget>()
                .ForMember(
                    a => a.AttributeMemberId,
                    b => b.MapFrom(x => x.AttributeMemberId))
                .ForMember(a => a.InvestmentStrategyId, b => b.MapFrom(x => x.InvestmentModelId))
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight))
                .ForMember(a => a.AttributeMember, b => b.Ignore())
                .ForMember(a => a.InvestmentStrategy, b => b.Ignore());

            CreateMap<InvestmentModelDto, InvestmentStrategy>()
                .ForMember(
                    a => a.InvestmentStrategyTargets, b => b.MapFrom(x => x.Targets))
                .ForMember(a => a.InvestmentStrategyId, b => b.MapFrom(x => x.InvestmentModelId));
            #endregion
        }
    }
}
