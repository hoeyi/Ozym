using System.Resources;
using System.Globalization;

namespace EulerFinancial.Resources
{

    /// <summary>
    /// Contains helper methods for accessing culture-specific application resources.
    /// </summary>
    static class ResourceHelper
    {
        private static readonly ResourceManager nounManager = new(typeof(NounString));
        
        /// <summary>
        /// Gets or sets the culture to use for the <see cref="ResourceHelper"/>. Default is <see cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        public static CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Retrieves noun-metadata matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="NounMetadata"/> that is the culture-sepcific variant of the noun.</returns>
        public static NounMetadata GetNounMetadata(string name)
        {
            string noun = nounManager.GetString(name: name);

            return NounMetadata.Parse(noun);
        }
    }
}
