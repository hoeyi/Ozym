using AutoMapper;
using Ozym.EntityModel;
using Ozym.DataTransfer.Common;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Maps broker transaction and related entities to DTOs and vice versa. Requires:
    /// <list type="bullet">
    /// <item><see cref="ModelAttributeProfile"/></item>
    /// <item><see cref="AccountProfile"/></item>
    /// <item><see cref="SecurityProfile"</item>
    /// </list>
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="BrokerTransactionCode"/> - <see cref="BrokerTransactionCodeDto"/></item>
    /// <item><see cref="BrokerTransaction"/> - <see cref="BrokerTransactionDto"/></item>
    /// </list>
    /// </remarks>
    public class BrokerTransactionProfile : Profile
    {
        public BrokerTransactionProfile()
        {
            #region Entity-DTO
            CreateMap<BrokerTransactionCodeAttributeMemberEntry, BrokerTransactionCodeAttributeDto>()
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<BrokerTransactionCode, BrokerTransactionCodeDtoBase>();

            CreateMap<BrokerTransactionCode, BrokerTransactionCodeDto>()
                .ForMember(
                    a => a.Attributes, 
                    b => b.MapFrom(x => x.BrokerTransactionCodeAttributeMemberEntries))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());

            CreateMap<BrokerTransaction, BrokerTransactionDto>();

            #endregion

            #region DTO-Entity
            CreateMap<BrokerTransactionCodeAttributeDto, BrokerTransactionCodeAttributeMemberEntry>()
                .ForMember(
                    a => a.AttributeMemberId,
                    b => b.MapFrom(x => x.AttributeMemberId))
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight))
                .ForMember(a => a.AttributeMember, b => b.Ignore())
                .ForMember(a => a.TransactionCode, b => b.Ignore());

            CreateMap<BrokerTransactionCodeDto, BrokerTransactionCode>()
                .ForMember(
                    a => a.BrokerTransactionCodeAttributeMemberEntries,
                    b => b.MapFrom(x => x.Attributes))
                .ForMember(a => a.BrokerTransactions, b => b.Ignore());

            CreateMap<BrokerTransactionDto, BrokerTransaction>()
                .ForMember(a => a.TransactionCode, b => b.Ignore())
                .ForMember(a => a.Account, b => b.Ignore())
                .ForMember(a => a.Security, b => b.Ignore())
                .ForMember(a => a.DepSecurity, b => b.Ignore())
                .ForMember(a => a.TaxLot, b => b.Ignore())
                .ForMember(a => a.InverseTaxLot, b => b.Ignore());

            #endregion
        }
    }
}
