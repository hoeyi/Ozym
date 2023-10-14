using AutoMapper;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Maps custodian entities to DTOs and vice versa. 
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="AccountCustodian"/> - <see cref="AccountCustodianDto"/></item>
    /// </list>
    /// </remarks>
    public class AccountCustodianProfile : Profile
    {
        public AccountCustodianProfile()
        {
            #region Entity-DTO
            CreateMap<AccountCustodian, AccountCustodianDto>();
            #endregion

            #region DTO-Entity
            CreateMap<AccountCustodianDto, AccountCustodian>()
                .ForMember(a => a.Accounts, b => b.Ignore())
                .ForMember(a => a.SecuritySymbolMaps, b => b.Ignore());
            #endregion
        }
    }
}
