using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NjordinSight.DAL.Test")]

namespace NjordinSight.Configuration
{
    public static class AssemblyInfo
    {
        #region Assembly attributes
        /// <summary>
        /// Gets the title of the calling assembly from the <see cref="AssemblyTitleAttribute"/>, 
        /// else the <see cref="Assembly.FullName"/> if none exists.
        /// </summary>
        public static string AssemblyTitle
        {
            get
            {
                Assembly assembly = Assembly.GetCallingAssembly();
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    return string
                        .IsNullOrEmpty(titleAttribute.Title) ? assembly.FullName : titleAttribute.Title;
                }
                else
                {
                    return assembly.FullName;
                }
            }
        }

        /// <summary>
        /// Gets the version of the calling assembly as a string from the 
        /// <see cref="AssemblyVersionAttribute"/>.
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetCallingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the description of the calling assembly from the <see cref="AssemblyDescriptionAttribute"/>, 
        /// or an empty string if none exists.
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly
                    .GetCallingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the description of the calling assembly from the <see cref="AssemblyDescriptionAttribute"/>, 
        /// or an empty string if none exists.
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly
                    .GetCallingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the copyright of the calling assembly from the <see cref="AssemblyCopyrightAttribute"/>, 
        /// or an empty string if none exists.
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly
                    .GetCallingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the company of the calling assembly from the <see cref="AssemblyCompanyAttribute"/>, 
        /// or an empty string if none exists.
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly
                    .GetCallingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        /// <summary>
        /// Gets the simple name for the calling assembly.
        /// </summary>
        public static string AssemblyName
        {
            get
            {
                return Assembly.GetCallingAssembly().GetName().Name;
            }
        }

        /// <summary>
        /// Gets the full path or UNC location for the calling assembly.
        /// </summary>
        public static string AssemblyPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            }
        }

        /// <summary>
        /// Gets the full path or UNC location for the executing assembly.
        /// </summary>
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
