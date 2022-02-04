using EulerFinancial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.Controllers
{
    public interface IAccountController : IController<Account> { }

    public interface IAccountWalletsController : IBatchController<AccountWallet, int> { }
}
