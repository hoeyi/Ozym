using NjordFinance.ModelMetadata;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="AccountComposite"/>.
    /// </summary>
    public class AccountCompositeViewModel : AccountObjectViewModel
    {
        private readonly string _objectType = AccountObjectType.Composite.ConvertToStringCode();
        public AccountComposite ToAccountComposite()
        {
            return new()
            {
                AccountCompositeId = AccountObjectId,
                AccountCompositeNavigation = new()
                {
                    AccountObjectId = AccountObjectId,
                    AccountObjectCode = AccountObjectCode,
                    ObjectDisplayName = DisplayName,
                    ObjectDescription = Description,
                    StartDate = StartDate,
                    CloseDate = CloseDate,
                    ObjectType = _objectType
                }
            };
        }
    }
}
