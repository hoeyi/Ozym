using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ozym.Web.Resources
{
    /// <summary>
    /// Helper methods for retrieving embedded file resoures.
    /// </summary>
    static class ResourceHelper
    {
        static ResourceHelper()
        {
            ResourceNamespace = typeof(ResourceHelper).Namespace!;
            DefaultMenuJsonQualifiedName = $"{ResourceNamespace}.DefaultMenu.json";

            ArgumentException.ThrowIfNullOrEmpty(ResourceNamespace);
        }

        private static string DefaultMenuJsonQualifiedName { get; }

        private static string ResourceNamespace { get; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public static async Task<T?> GetDefaultMenu<T>(string? shortName = null)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            string resourceName = string.IsNullOrEmpty(shortName) ?
                DefaultMenuJsonQualifiedName :
                $"{ResourceNamespace}.{shortName}";

            using var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException();

            using var reader = new StreamReader(stream);

            string menuJson = await reader.ReadToEndAsync();
            var obj = JsonSerializer.Deserialize<T>(menuJson);

            return JsonSerializer.Deserialize<T>(menuJson);
        }
    }
}
