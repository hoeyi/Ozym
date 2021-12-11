using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using EulerFinancial.Model;
using System;
using EulerFinancial.UI;
using EulerFinancial.Expressions;

namespace EulerFinancial.Blazor.Shared
{
    public partial class ModelView : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationHelper { get; set; }

        [Inject]
        protected IUserInterfaceHelper UIHelper { get; set; }

        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; }

        protected readonly IDictionary<string, ModelMemberMetadata> ModelMetadata =
            new Dictionary<string, ModelMemberMetadata>();
        
        protected ModelMemberMetadata TryGetMetadata(Type type, string memberName)
        {
            return ModelMetadata.TryGetValue($"{type.Name}.{memberName}", out ModelMemberMetadata modelMetadata) ?
                modelMetadata : null;
        }
    }
}
