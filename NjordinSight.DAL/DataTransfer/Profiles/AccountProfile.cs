using AutoMapper;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountAttributeDto, AccountAttributeMemberEntry>();
            CreateMap<Account, AccountDto>().ForMember(
                a => a.Attributes,
                b => b.MapFrom(x => x.AccountNavigation.AccountAttributeMemberEntries));
        }
    }
}
