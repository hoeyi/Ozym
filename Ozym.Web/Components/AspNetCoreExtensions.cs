using Microsoft.AspNetCore.Http;

namespace Ozym.Web.Components
{
    internal static class AspNetCoreExtensions
    {
        /// <summary>
        /// Checks if the given path starts with any of the specified segments.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <param name="others">The segments to compare against.</param>
        /// <returns><c>true</c> if the path starts with any of the specified segments; otherwise, <c>false</c>.</returns>
        /// <remarks>Only the first match is confirmed. Subsequent matches are not checked for.</remarks>
        public static bool StartsWithSegments(this PathString path, PathString[] others)
        {
            if (others.Length == 0)
                throw new InvalidOperationException($"Paramater '{nameof(others)} must not be empty.");

            bool result = false;
            foreach (var other in others)
            {
                result = path.StartsWithSegments(other);
                if (result) break;
            }

            return result;
        }
    }
}
