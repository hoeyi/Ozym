using AutoMapper;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;


namespace NjordinSight.DataTransfer.Profiles
{
    public class AccountCompositeProfile : Profile
    {
        public AccountCompositeProfile()
        {
            CreateMap<AccountComposite, AccountCompositeDto>().ForMember(
                 a => a.Attributes,
                 b => b.MapFrom(x => x.AccountCompositeNavigation.AccountAttributeMemberEntries));
        }
    }
}
