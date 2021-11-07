using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using EulerFinancial.Model;
using System;

namespace EulerFinancial.Blazor.Shared
{
    public partial class ModelView : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationHelper { get; set; }

        protected readonly IDictionary<string, ModelMetadata> ModelMetadata =
            new Dictionary<string, ModelMetadata>();

        protected ModelMetadata TryGetMetadata(Type type, string memberName)
        {
            return ModelMetadata.TryGetValue($"{type.Name}.{memberName}", out ModelMetadata modelMetadata) ?
                modelMetadata : null;
        }
    }
}
