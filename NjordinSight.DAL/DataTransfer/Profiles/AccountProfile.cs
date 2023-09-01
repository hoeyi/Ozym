using AutoMapper;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps account-related entities to DTOs and vice versa. Requires 
    /// <see cref="ModelAttributeProfile"/>.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="AccountAttributeMemberEntry"/> - <see cref="AccountBaseAttributeDto"/></item>
    /// <item><see cref="Account"/> - <see cref="AccountDto"/></item>
    /// <item><see cref="AccountCompositeMember"/> - <see cref="AccountCompositeMemberDto"/></item>
    /// <item><see cref="AccountComposite"/> - <see cref="AccountCompositeDto"/></item>
    /// </list>
    /// </remarks>
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            #region Entity-DTO
            CreateMap<AccountAttributeMemberEntry, AccountBaseAttributeDto>()
                .ForMember(a => a.PercentWeight, b => b.MapFrom(x => x.Weight));

            CreateMap<Account, AccountDto>()
                .ForMember(
                    a => a.Attributes,
                    b => b.MapFrom(x => x.AccountNavigation.AccountAttributeMemberEntries))
                .ForMember(a => a.Id, b => b.MapFrom(x => x.AccountNavigation.AccountObjectId))
                .ForMember(a => a.ShortCode, b => b.MapFrom(x => x.AccountNavigation.AccountObjectCode))
                .ForMember(a => a.StartDate, b => b.MapFrom(x => x.AccountNavigation.StartDate))
                .ForMember(a => a.CloseDate, b => b.MapFrom(x => x.AccountNavigation.CloseDate))
                .ForMember(a => a.Description, b => b.MapFrom(x => x.AccountNavigation.ObjectDescription))
                .ForMember(a => a.DisplayName, b => b.MapFrom(x => x.AccountNavigation.ObjectDisplayName))
                .ForMember(a => a.ObjectType, b => b.MapFrom(x => x.AccountNavigation.ObjectType))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());

            CreateMap<AccountCompositeMember, AccountCompositeMemberDto>();

            CreateMap<AccountComposite, AccountCompositeDto>()
                .ForMember(
                     a => a.Attributes,
                     b => b.MapFrom(x => x.AccountCompositeNavigation.AccountAttributeMemberEntries))
                .ForMember(
                    a => a.AccountMembers,
                    b => b.MapFrom(x => x.AccountCompositeMembers))
                .ForMember(a => a.Id, b => b.MapFrom(x => x.AccountCompositeNavigation.AccountObjectId))
                .ForMember(a => a.ShortCode, b => b.MapFrom(x => x.AccountCompositeNavigation.AccountObjectCode))
                .ForMember(a => a.StartDate, b => b.MapFrom(x => x.AccountCompositeNavigation.StartDate))
                .ForMember(a => a.CloseDate, b => b.MapFrom(x => x.AccountCompositeNavigation.CloseDate))
                .ForMember(a => a.Description, b => b.MapFrom(x => x.AccountCompositeNavigation.ObjectDescription))
                .ForMember(a => a.DisplayName, b => b.MapFrom(x => x.AccountCompositeNavigation.ObjectDisplayName))
                .ForMember(a => a.ObjectType, b => b.MapFrom(x => x.AccountCompositeNavigation.ObjectType))
                .ForMember(a => a.AttributeCollection, b => b.Ignore());

            CreateMap<AccountWallet, AccountWalletDto>();

            #endregion

            #region DTO-Entity
            CreateMap<AccountBaseAttributeDto, AccountAttributeMemberEntry>()
                .ForMember(a => a.AttributeMemberId, b => b.MapFrom(x => x.AttributeMember.AttributeMemberId))
                .ForMember(a => a.Weight, b => b.MapFrom(x => x.PercentWeight))
                .ForMember(a => a.AttributeMember, b => b.Ignore())
                .ForMember(a => a.AccountObject, b => b.Ignore());

            CreateMap<AccountDto, Account>()
#pragma warning disable CS0618 // Type or member is obsolete
                .ForMember(a => a.IsComplianceTradable, b => b.Ignore()) 
#pragma warning restore CS0618 // Type or member is obsolete
                .ForMember(a => a.AccountId, b => b.MapFrom(x => x.Id))
                .ForMember(a => a.AccountCustodian, b => b.Ignore())
                .ForMember(a => a.AccountWallets, b => b.Ignore())
                .ForMember(a => a.BankTransactions, b => b.Ignore())
                .ForMember(a => a.BrokerTransactions, b => b.Ignore())
                .ForMember(a => a.AccountCompositeMembers, b => b.Ignore())
                .ForPath(a => a.AccountNavigation.AccountObjectId, b => b.MapFrom(x => x.Id))
                .ForPath(a => a.AccountNavigation.AccountObjectCode, b => b.MapFrom(x => x.ShortCode))
                .ForPath(a => a.AccountNavigation.StartDate, b => b.MapFrom(x => x.StartDate))
                .ForPath(a => a.AccountNavigation.CloseDate, b => b.MapFrom(x => x.CloseDate))
                .ForPath(a => a.AccountNavigation.ObjectDescription, b => b.MapFrom(x => x.Description))
                .ForPath(a => a.AccountNavigation.ObjectDisplayName, b => b.MapFrom(x => x.DisplayName))
                .ForPath(a => a.AccountNavigation.ObjectType, b => b.MapFrom(x => x.ObjectType))
                .ForPath(
                    a => a.AccountNavigation.AccountAttributeMemberEntries,
                    b => b.MapFrom(x => x.Attributes));

            CreateMap<AccountCompositeMemberDto, AccountCompositeMember>()
                .ForMember(a => a.AccountComposite, b => b.Ignore())
                .ForMember(a => a.Account, b => b.Ignore());
                
            CreateMap<AccountCompositeDto, AccountComposite>()
                .ForMember(a => a.AccountCompositeId, b => b.MapFrom(x => x.Id))
                .ForMember(a => a.AccountCompositeMembers, b => b.MapFrom(x => x.AccountMembers))
                .ForPath(a => a.AccountCompositeNavigation.AccountObjectId, b => b.MapFrom(x => x.Id))
                .ForPath(a => a.AccountCompositeNavigation.AccountObjectCode, b => b.MapFrom(x => x.ShortCode))
                .ForPath(a => a.AccountCompositeNavigation.StartDate, b => b.MapFrom(x => x.StartDate))
                .ForPath(a => a.AccountCompositeNavigation.CloseDate, b => b.MapFrom(x => x.CloseDate))
                .ForPath(a => a.AccountCompositeNavigation.ObjectDescription, b => b.MapFrom(x => x.Description))
                .ForPath(a => a.AccountCompositeNavigation.ObjectDisplayName, b => b.MapFrom(x => x.DisplayName))
                .ForPath(a => a.AccountCompositeNavigation.ObjectType, b => b.MapFrom(x => x.ObjectType))
                .ForPath(
                    a => a.AccountCompositeNavigation.AccountAttributeMemberEntries,
                    b => b.MapFrom(x => x.Attributes));

            CreateMap<AccountWalletDto, AccountWallet>()
                .ForMember(a => a.Account, b => b.Ignore())
                .ForMember(a => a.DenominationSecurity, b => b.Ignore());
            #endregion
        }
    }
}
