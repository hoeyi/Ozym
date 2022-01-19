using Microsoft.AspNetCore.Components;
using Ichosoft.DataModel.Expressions;
using Ichosoft.DataModel;
using System.Globalization;

namespace EulerFinancial.Blazor.Shared
{
    public partial class LocalizedComponent : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationHelper { get; set; }

        [Inject]
        public IModelMetadataService ModelMetadata { get; set; }
    }
}
