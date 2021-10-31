using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EulerFinancial.Data.Model;

namespace EulerFinancial.Data
{
    public interface IAccountService : IModelService<Account>
    {
        Task<IList<AccountCustodian>> GetAccountCustodians();

    }
}
