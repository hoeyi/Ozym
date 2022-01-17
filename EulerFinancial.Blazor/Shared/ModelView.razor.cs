﻿using Microsoft.AspNetCore.Components;
using Ichosoft.DataModel.Expressions;
using Ichosoft.DataModel;

namespace EulerFinancial.Blazor.Shared
{
    public partial class ModelView : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationHelper { get; set; }

        [Inject]
        protected IExpressionBuilder ExpressionBuilder { get; set; }

        [Inject]
        protected IModelMetadataService ModelMetadata { get; set; }
    }
}
