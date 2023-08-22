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
    /// Maps security entities to DTOs and vice versa. 
    /// Requires <see cref="ModelAttributeProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="Security"/> - <see cref="SecurityDto"/></item>
    /// <item><see cref="SecurityAttributeMemberEntry"/> - <see cref="SecurityAttributeDto"/></item>
    /// <item><see cref="SecuritySymbol"/> - <see cref="SecuritySymbolDto"/></item>
    /// <item><see cref="SecuritySymbolType"/> - <see cref="SecuritySymbolTypeDto"/></item>
    /// <item><see cref="SecuritySymbolMap"/> - <see cref="SecuritySymbolMapDto"/></item>
    /// </list>
    /// </remarks>
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {
            #region Entity-DTO
            CreateMap<Security, SecurityDtoBase>();

            CreateMap<Security, SecurityDto>()
                .ForMember(a => a.Attributes, b => b.MapFrom(x => x.SecurityAttributeMemberEntries))
                .ForMember(a => a.Symbols, b => b.MapFrom(x => x.SecuritySymbols))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());

            CreateMap<SecurityAttributeMemberEntry, SecurityAttributeDto>()
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<SecuritySymbol, SecuritySymbolDto>()
                .ForMember(a => a.Symbol, b => b.MapFrom(x => x.SymbolCode));

            CreateMap<SecuritySymbolType, SecuritySymbolTypeDto>();

            CreateMap<SecuritySymbolMap, SecuritySymbolMapDto>();

            #endregion

            #region DTO-Entity
            CreateMap<SecurityDto, Security>()
                .ForMember(a => a.AccountWallets, b => b.Ignore())
                .ForMember(a => a.BrokerTransactionSecurities, b => b.Ignore())
                .ForMember(a => a.BrokerTransactionDepSecurities, b => b.Ignore())
                .ForMember(a => a.SecurityExchange, b => b.Ignore())
                .ForMember(a => a.SecurityPrices, b => b.Ignore())
                .ForMember(a => a.SecurityType, b => b.Ignore())
                .ForMember(a => a.SecuritySymbol, b => b.Ignore())
                .ForMember(a => a.SecurityAttributeMemberEntries, b => b.MapFrom(x => x.Attributes))
                .ForMember(a => a.SecuritySymbols, b => b.MapFrom(x => x.Symbols));

            CreateMap<SecurityAttributeDto, SecurityAttributeMemberEntry>()
                .ForMember(a => a.AttributeMemberId, b => b.MapFrom(x => x.AttributeMember.AttributeMemberId))
                .ForMember(a => a.Security, b => b.Ignore())
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight));

            CreateMap<SecuritySymbolDto, SecuritySymbol>()
                .ForMember(a => a.SecuritySymbolMaps, b => b.Ignore())
                .ForMember(a => a.SymbolType, b => b.Ignore())
                .ForMember(a => a.Security, b => b.Ignore())
                .ForMember(a => a.SymbolCode, b => b.Ignore());

            CreateMap<SecuritySymbolTypeDto, SecuritySymbolType>()
                .ForMember(a => a.SecuritySymbols, b => b.Ignore());

            CreateMap<SecuritySymbolMapDto, SecuritySymbolMap>()
                .ForMember(a => a.AccountCustodian, b => b.Ignore())
                .ForMember(a => a.SecuritySymbol, b => b.Ignore());
            #endregion
        }
    }
}
