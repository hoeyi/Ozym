using System.Reflection;
using System.IO;

namespace EulerFinancial.Configuration
{
    public static class AssemblyInfoHelper
    {
        #region Assembly attributes
        public static string AssemblyTitle
        {
            get
            {
                Assembly assembly = Assembly.GetCallingAssembly();
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    return string.IsNullOrEmpty(titleAttribute.Title) ? assembly.FullName : titleAttribute.Title;
                }
                else
                {
                    return assembly.FullName;
                }
            }
        }
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetCallingAssembly().GetName().Version.ToString();
            }
        }
        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        public static string AssemblyName
        {
            get
            {
                return Assembly.GetCallingAssembly().GetName().Name;
            }
        }

        public static string AssemblyPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            }
        }
        public static string ExecutingAssemblyPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }
        #endregion
    }
}
