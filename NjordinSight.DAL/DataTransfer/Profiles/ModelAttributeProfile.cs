﻿using AutoMapper;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.DataTransfer.Profiles
{
    public class ModelAttributeProfile : Profile
    {
        public ModelAttributeProfile()
        {
            #region Entity-DTO
            CreateMap<ModelAttributeMember, ModelAttributeMemberDto>();
            CreateMap<ModelAttributeScope, ModelAttributeScopeDto>();

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
