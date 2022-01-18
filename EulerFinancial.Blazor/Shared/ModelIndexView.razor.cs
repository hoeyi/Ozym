using Microsoft.AspNetCore.Components;
using Ichosoft.DataModel.Expressions;
using Ichosoft.DataModel;
using System.Globalization;

namespace EulerFinancial.Blazor.Shared
{
    public partial class ModelIndexView : LocalizedComponent
    {
        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; }
    }
}
