namespace EulerFinancial.Web.Components.Shared
{
    public struct NavMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconKey">The </param>
        /// <param name="caption"></param>
        /// <param name="uriStem"></param>
        public NavMenuItem(string iconKey, string caption, string uriStem)
        {
            IconKey = iconKey;
            Caption = caption;
            UriStem = uriStem;
        }

        /// <summary>
        /// Gets or sets the key for the navigation menu item.
        /// </summary>
        public string? IconKey { get; set; }

        /// <summary>
        /// Gets or sets the caption for the navigation menu item.
        /// </summary>
        public string? Caption { get; set; }

        /// <summary>
        /// Gets or sets the uri stem for the navigation menu item.
        /// </summary>
        public string? UriStem { get; set; }

        /// <summary>
        /// Gets whether any instance properties are undefined.
        /// </summary>
        public bool IsIncomplete
        {
            get
            {
                return string.IsNullOrEmpty(IconKey) ||
                        string.IsNullOrEmpty(Caption) ||
                        string.IsNullOrEmpty(UriStem);
            }
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is NavMenuItem navIcon)
                return navIcon.GetHashCode() == GetHashCode();
            else
                return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return System.HashCode.Combine(IconKey, Caption, UriStem);
        }

        public static bool operator ==(NavMenuItem left, NavMenuItem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NavMenuItem left, NavMenuItem right)
        {
            return !(left == right);
        }
    }
}
