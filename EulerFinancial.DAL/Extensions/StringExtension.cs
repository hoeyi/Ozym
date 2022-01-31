using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToLogTemplate(this string template, params string[] parameterNames)
        {
            if (string.IsNullOrEmpty(template))
                return null;

            if (parameterNames is null)
                return template;

            string logTemplate = null;
            for (int i = 0; i < parameterNames.Length; i++)
            {
                logTemplate = template.Replace($"{{{i}}}", $"{{{parameterNames[i]}}}");
            }

            return logTemplate;
        }
    }
}
