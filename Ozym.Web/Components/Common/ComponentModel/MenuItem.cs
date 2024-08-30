using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;

namespace Ozym.Web.Components.Common
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
        [JsonPropertyName("IconKey")]
        public string? IconKey { get; set; }

        /// <summary>
        /// Gets or sets the caption for the navigation menu item.
        /// </summary>
        [JsonPropertyName("Caption")]
        public string? Caption { get; set; }

        /// <summary>
        /// Gets or sets the uri stem for the navigation menu item.
        /// </summary>
        [JsonPropertyName("UriRelativePath")]
        public string? UriRelativePath { get; init; }

        /// <summary>
        /// Gets or sets the children <see cref="MenuItem"/> of this item.
        /// </summary>
        [JsonPropertyName("Children")]
        public List<MenuItem>? Children { get; init; }

        [JsonPropertyName("ChildMenuOptions")]
        public DisplayOptions ChildMenuOptions { get; set; } = new(initialValue: true);

        /// <summary>
        /// Gets whether this item has children.
        /// </summary>
        [JsonIgnore]
        public bool HasChildren
        {
            get { return Children?.Any() ?? false; }
        }

        [JsonIgnore]
        /// <summary>
        /// Returns true if this item is a root-level node in the menu tree.
        /// </summary>
        public bool IsRoot { get; private init; }

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
            return System.HashCode.Combine(IconKey, Caption, UriRelativePath);
        }

        public static bool operator ==(MenuItem left, MenuItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MenuItem left, MenuItem right)
        {
            return !(left == right);
        }

        public struct DisplayOptions
        {
            [JsonConstructor]
            public DisplayOptions()
            {
            }

            public DisplayOptions(bool initialValue) 
            {
                DisplayIcon = initialValue;
                DisplayCaption = initialValue;
                DisplayChildMenuChevron = initialValue;
            }

            [JsonPropertyName("DisplayIcon")]
            public bool DisplayIcon { get; set; }

            [JsonPropertyName("DisplayCaption")]
            public bool DisplayCaption { get; set; }

            [JsonPropertyName("DisplayChildMenuChevron")]
            public bool DisplayChildMenuChevron { get; set; }
        }
    }
#nullable disable
}
