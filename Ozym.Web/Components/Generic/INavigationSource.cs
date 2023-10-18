using Microsoft.AspNetCore.Components;

namespace Ozym.Web.Components.Generic
{
    /// <summary>
    /// Represents a component that can redirect focus to a 
    /// new page.
    /// </summary>
    public interface INavigationSource
    {
        /// <summary>
        /// Gets the navigation manager for this component.
        /// </summary>
        protected NavigationManager NavigationHelper { get; }
    }
}
