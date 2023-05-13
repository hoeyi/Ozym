using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModel.Context.Configurations
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class KeyRangeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRangeAttribute"/>.
        /// </summary>
        /// <param name="lowerBound">The inclusive start of the range.</param>
        /// <param name="upperBound">The exclusive end of the range.</param>
        /// <exception cref="InvalidOperationException">The value of <paramref name="lowerBound"/> 
        /// was greater than or equal to the value of <paramref name="upperBound"/>.</exception>
        public KeyRangeAttribute(int lowerBound, int upperBound)
        {
            if (lowerBound >= upperBound)
                throw new InvalidOperationException(string.Format(
                    Strings.Context_KeyRangeAttribute_InvalidOperationException,
                    nameof(lowerBound),
                    nameof(upperBound),
                    lowerBound,
                    upperBound));

            Range = new(start: lowerBound, end: upperBound);
        }

        /// <summary>
        /// Gets the <see cref="System.Range"/> representing reserved key values for the annotated 
        /// class.
        /// </summary>
        public Range Range { get; }
    }
}
