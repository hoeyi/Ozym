using EulerFinancial.Model;

namespace EulerFinancial.ModelService
{
    /// <inheritdoc/>
    public interface IAccountService : IModelService<Account> { }

    /// <inheritdoc/>
    public interface IAccountWalletService : IBatchModelService<AccountWallet, int> { }

}
