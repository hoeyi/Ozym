using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NjordinSight.Web.Components.Shared
{
#nullable enable
    /// <summary>
    /// Represents the base element for items in a traditional tiered navigation menu.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Create an <see cref="MenuItem"/>.
        /// </summary>
        public MenuItem() : this(isRoot: false)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="MenuItem"/> as a root item or not.
        /// </summary>
        /// <param name="isRoot"></param>
        protected MenuItem(bool isRoot)
        {
            IsRoot = isRoot;
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
        /// Gets or sets the children <see cref="MenuItem"/> of this item.
        /// </summary>
        public SortedList<int, MenuItem> Children { get; init; } = new();

        /// <summary>
        /// Gets whether this item has children.
        /// </summary>
        [JsonIgnore]
        public bool HasChildren
        {
            get { return Children.Count > 0; }
        }

        /// <summary>
        /// Gets whether this menu item is part of the first level of menu items.
        /// </summary>
        public bool IsRoot { get; private set; }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is MenuItem item)
                return item.GetHashCode() == GetHashCode();
            else
                return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return System.HashCode.Combine(IconKey, Caption, UriStem);
        }

        public static bool operator ==(MenuItem left, MenuItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MenuItem left, MenuItem right)
        {
            return !(left == right);
        }
    }
#nullable disable
}
