using NjordFinance.Web.Components.Shared;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace NjordFinance.Web.Resources
{
    /// <summary>
    /// Helper methods for retrieving embedded file resoures.
    /// </summary>
    static class ResourceHelper
    {
        private const string DefaultMenuJsonQualifiedName 
            = "NjordFinance.Web.Resources.DefaultMenu.json";
        public static async Task<Menu?> GetDefaultMenu()
        {
            using var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(DefaultMenuJsonQualifiedName);

            if (stream is null)
                throw new InvalidOperationException();

            using var reader = new StreamReader(stream);

            string menuJson = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<Menu>(menuJson);
        }
    }
}
