using EulerFinancial.Controllers;
using Microsoft.AspNetCore.Components;

namespace EulerFinancial.Blazor.Shared
{
    /// <summary>
    /// A component for creating, reading, updating, or deleting a model or models.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public partial class ModelCRUD<TModel> : ModelDetail<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Gets or sets the <see cref="IController{TModel}"/> for this component.
        /// </summary>
        [Inject]
        protected IController<TModel> Controller { get; set; }
    }
}
