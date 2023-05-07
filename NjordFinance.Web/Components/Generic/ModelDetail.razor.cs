using Microsoft.AspNetCore.Components;
using NjordFinance.Web.Controllers;

namespace NjordFinance.Web.Components.Generic
{
    /// <summary>
    /// Base component for viewing details of a <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public partial class ModelDetail<TModel> : ModelPage<TModel>, INavigationSource
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the model for which details are provided. 
        /// </summary>
        protected TModel Model { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="IController{TModel}"/> for this component.
        /// </summary>
        [Inject]
        protected IController<TModel> Controller { get; set; } = default!;
    }
}
