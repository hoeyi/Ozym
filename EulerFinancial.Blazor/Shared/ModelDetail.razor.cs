using EulerFinancial.Controllers;
using Microsoft.AspNetCore.Components;

namespace EulerFinancial.Blazor.Shared
{
    /// <summary>
    /// Base component for viewing details of a <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class ModelDetail<TModel> : ModelComponentBase<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the model for which details are provided. 
        /// </summary>
        [Parameter]
        public TModel Model { get; set; }
    }
}
