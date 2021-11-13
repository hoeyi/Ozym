using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.Resources
{
    /// <summary>
    /// Represents a noun.
    /// </summary>
    public class NounMetadata
    {
        /// <summary>
        /// Parses a string into a new instance of <see cref="NounMetadata"/>.
        /// </summary>
        /// <param name="noun">A string representation of </param>
        /// <returns>A new instance of <see cref="NounMetadata"/> with memebers 
        /// defined by the given string.</returns>
        public static NounMetadata Parse(string noun)
        {
            if (string.IsNullOrEmpty(noun))
                throw new ArgumentNullException(paramName: nameof(noun));

            var nounElements = noun.Split(':')
                                    .SelectMany(s => s.Split(','))
                                    .ToArray();

            return new NounMetadata()
            {
                SingularArticle = nounElements[0],
                Singular = nounElements[1],
                PluralArticle = nounElements[2],
                Plural = nounElements[3]
            };
        }

        public override string ToString()
        {
            return $"({SingularArticle},{Singular}):({PluralArticle},{Plural})";
        }

        /// <summary>
        /// The singular form of the noun.
        /// </summary>
        public string Singular { get; private set; }

        /// <summary>
        /// The nominative singular of the noun.
        /// </summary>
        public string SingularArticle { get; private set; }

        /// <summary>
        /// The plural form of the noun.
        /// </summary>
        public string Plural { get; private set; }

        /// <summary>
        /// The nominative plural of the noun.
        /// </summary>
        public string PluralArticle { get; private set; }
    }
}
