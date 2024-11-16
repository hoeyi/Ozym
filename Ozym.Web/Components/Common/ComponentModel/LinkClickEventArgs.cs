using Microsoft.AspNetCore.Components.Web;

namespace Ozym.Web.Components.Common
{
    /// <summary>
    /// Supplies information about a clicked link event raised. Derives from 
    /// <see cref="MouseEventArgs"/>.
    /// </summary>
    public class LinkClickEventArgs : MouseEventArgs
    {
        /// <summary>
        /// The relative URI path that was clicked to raise the event.
        /// </summary>
        public string UriPath { get; init; } = string.Empty;
    }
}
