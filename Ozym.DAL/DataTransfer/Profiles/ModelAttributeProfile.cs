﻿using AutoMapper;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Maps attribute-related entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="ModelAttributeMember"/> - <see cref="ModelAttributeMemberDto"/></item>
    /// <item><see cref="ModelAttributeScope"/> - <see cref="ModelAttributeScopeDto"/></item>
    /// <item><see cref="ModelAttribute"/> - <see cref="ModelAttributeDtoBase"/></item>
    /// <item><see cref="ModelAttribute"/> - <see cref="ModelAttributeDto"/></item>
    /// </list>
    /// </remarks>
    public class ModelAttributeProfile : Profile
    {
        public ModelAttributeProfile()
        {
            #region Entity-DTO
            CreateMap<ModelAttributeMember, ModelAttributeMemberDto>();
            CreateMap<ModelAttributeMember, ModelAttributeMemberDtoBase>();

            CreateMap<ModelAttributeScope, ModelAttributeScopeDto>();

            CreateMap<ModelAttribute, ModelAttributeDtoBase>();

            CreateMap<ModelAttribute, ModelAttributeDto>()
                .ForMember(
                    a => a.AttributeValues,
                    b => b.MapFrom(x => x.ModelAttributeMembers))
                .ForMember(
                    a => a.AttributeScopes,
                    b => b.MapFrom(x => x.ModelAttributeScopes));
            #endregion

            #region DTO-Entity
            CreateMap<ModelAttributeMemberDto, ModelAttributeMember>()
                .ForMember(a => a.AttributeId, b => b.MapFrom(x => x.Attribute.AttributeId))
                .ForMember(a => a.Attribute, b => b.Ignore())
                .ForMember(a => a.AccountAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.BankTransactionCodeAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.BrokerTransactionCodeAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.Country, b => b.Ignore())
                .ForMember(a => a.CountryAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.InvestmentPerformanceAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.InvestmentStrategyTargets, b => b.Ignore())
                .ForMember(a => a.SecurityAttributeMemberEntries, b => b.Ignore())
                .ForMember(a => a.SecurityType, b => b.Ignore())
                .ForMember(a => a.SecurityTypeGroup, b => b.Ignore());

            CreateMap<ModelAttributeScopeDto, ModelAttributeScope>()
                .ForMember(a => a.Attribute, b => b.Ignore());

            CreateMap<ModelAttributeDtoBase, ModelAttribute>()
                .ForMember(a => a.ModelAttributeMembers, b => b.Ignore())
                .ForMember(a => a.ModelAttributeScopes, b => b.Ignore());

            CreateMap<ModelAttributeDto, ModelAttribute>()
                .ForMember(
                    a => a.ModelAttributeMembers,
                    b => b.MapFrom(x => x.AttributeValues))
                .ForMember(
                    a => a.ModelAttributeScopes,
                    b => b.MapFrom(x => x.AttributeScopes));
            #endregion
        }
    }
}
