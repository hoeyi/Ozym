﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ozym.UserInterface {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringTemplate {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringTemplate() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ozym.UserInterface.StringTemplate", typeof(StringTemplate).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt; Select &gt;.
        /// </summary>
        internal static string Caption_InputSelect_Placeholder {
            get {
                return ResourceManager.GetString("Caption_InputSelect_Placeholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New {0}.
        /// </summary>
        internal static string CreateModel {
            get {
                return ResourceManager.GetString("CreateModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}.
        /// </summary>
        internal static string IndexModel {
            get {
                return ResourceManager.GetString("IndexModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: {1}.
        /// </summary>
        internal static string IndexModelAsChild {
            get {
                return ResourceManager.GetString("IndexModelAsChild", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; does not have a noun attribute applied. The page title cannot be generated..
        /// </summary>
        internal static string ModelNoun_NotFound_Exception {
            get {
                return ResourceManager.GetString("ModelNoun_NotFound_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: {1}.
        /// </summary>
        internal static string ReadModel {
            get {
                return ResourceManager.GetString("ReadModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit {0}: {1}.
        /// </summary>
        internal static string UpdateModel {
            get {
                return ResourceManager.GetString("UpdateModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit {0}.
        /// </summary>
        internal static string UpdateModelNoParent {
            get {
                return ResourceManager.GetString("UpdateModelNoParent", resourceCulture);
            }
        }
    }
}
