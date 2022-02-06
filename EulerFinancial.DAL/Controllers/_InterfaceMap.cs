using EulerFinancial.Model;

namespace EulerFinancial.Controllers
{
    public interface IAccountController : IController<Account> { }

    public interface IAccountWalletsController : IBatchController<AccountWallet, int> { }
}
