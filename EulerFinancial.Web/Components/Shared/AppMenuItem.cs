using System.Collections.Generic;

namespace EulerFinancial.Web.Components.Shared
{
    /// <summary>
    /// Represents the base element for items in a traditional tiered navigation menu.
    /// </summary>
    public class AppMenuItem
    {
        /// <summary>
        /// Create an <see cref="AppMenuItem"/>.
        /// </summary>
        public AppMenuItem()
        {
        }

        /// <summary>
        /// Creates an <see cref="AppMenuItem"/>.
        /// </summary>
        /// <param name="iconKey">The </param>
        /// <param name="caption"></param>
        /// <param name="uriStem"></param>
        public AppMenuItem(string iconKey, string caption, string uriStem)
        {
            IconKey = iconKey;
            Caption = caption;
            UriStem = uriStem;
        }

        /// <summary>
        /// Gets or sets the key for the navigation menu item.
        /// </summary>
        public string? IconKey { get; init; }

        /// <summary>
        /// Gets or sets the caption for the navigation menu item.
        /// </summary>
        public string? Caption { get; init; }

        /// <summary>
        /// Gets or sets the uri stem for the navigation menu item.
        /// </summary>
        public string? UriStem { get; init; }

        /// <summary>
        /// Gets or sets the children <see cref="AppMenuItem"/> of this item.
        /// </summary>
        public SortedList<int, AppMenuItem> Children { get; init; } = new();

        /// <summary>
        /// Gets whether this item has children.
        /// </summary>
        public bool HasChildren
        {
            get { return Children.Count > 0; }
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is AppMenuItem navIcon)
                return navIcon.GetHashCode() == GetHashCode();
            else
                return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return System.HashCode.Combine(IconKey, Caption, UriStem);
        }

        public static bool operator ==(AppMenuItem left, AppMenuItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AppMenuItem left, AppMenuItem right)
        {
            return !(left == right);
        }
    }
}
