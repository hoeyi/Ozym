using EulerFinancial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <inheritdoc/>
    public interface IAccountService : IModelService<Account> { }

    /// <inheritdoc/>
    public interface IAccountWalletService : IBatchModelService<AccountWallet, int> { }

}
