using Microsoft.AspNetCore.Components;
using Serilog;
using EulerFinancial.Controllers;

namespace EulerFinancial.Blazor.Shared
{
    public partial class ModelComponentBase<TModel> : LocalizedComponent
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the <see cref="ILogger"/> used by this component.
        /// </summary>
        [Inject]
        protected ILogger Logger { get; set; }
    }
}
