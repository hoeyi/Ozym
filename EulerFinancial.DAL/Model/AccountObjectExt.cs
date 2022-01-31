using EulerFinancial.Model.Annotations;

namespace EulerFinancial.Model
{
    [Searchable(new string[]
    {
        nameof(AccountObjectCode),
        nameof(ObjectDipslayName),
        nameof(ObjectDescription),
        nameof(StartDate),
        nameof(CloseDate)
    })]
    public partial class AccountObject
    {
    }
}
