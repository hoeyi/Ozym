using AutoMapper;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps bank transaction and related entities to DTOs and vice versa. Requires 
    /// <see cref="ModelAttributeProfile"/> and <see cref="AccountProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="BankTransactionCode"/> - <see cref="BankTransactionCodeDto"/></item>
    /// <item><see cref="BankTransaction"/> - <see cref="BankTransactionDto"/></item>
    /// </list>
    /// </remarks>
    public class BankTransactionProfile : Profile
    {
        public BankTransactionProfile()
        {
            #region Entity-DTO
            CreateMap<BankTransactionCodeAttributeMemberEntry, BankTransactionCodeAttributeDto>()
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<BankTransactionCode, BankTransactionCodeDtoBase>();

            CreateMap<BankTransactionCode, BankTransactionCodeDto>()
                .ForMember(
                    a => a.Attributes, 
                    b => b.MapFrom(x => x.BankTransactionCodeAttributeMemberEntries))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());

            CreateMap<BankTransaction, BankTransactionDto>();

            #endregion

            #region DTO-Entity
            CreateMap<BankTransactionCodeAttributeDto, BankTransactionCodeAttributeMemberEntry>()
                .ForMember(
                    a => a.AttributeMemberId,
                    b => b.MapFrom(x => x.AttributeMember.AttributeMemberId))
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight))
                .ForMember(a => a.AttributeMember, b => b.Ignore())
                .ForMember(a => a.TransactionCode, b => b.Ignore());

            CreateMap<BankTransactionCodeDto, BankTransactionCode>()
                .ForMember(
                    a => a.BankTransactionCodeAttributeMemberEntries,
                    b => b.MapFrom(x => x.Attributes))
                .ForMember(a => a.BankTransactions, b => b.Ignore());

            CreateMap<BankTransactionDto, BankTransaction>()
                .ForMember(a => a.TransactionCode, b => b.Ignore())
                .ForMember(a => a.Account, b => b.Ignore());

            #endregion
        }
    }
}
