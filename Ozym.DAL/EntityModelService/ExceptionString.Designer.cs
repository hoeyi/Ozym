﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ozym.EntityModelService {
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
    internal class ExceptionString {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionString() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ozym.EntityModelService.ExceptionString", typeof(ExceptionString).Assembly);
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
        ///   Looks up a localized string similar to The required context for this service has not initialized..
        /// </summary>
        internal static string ModelBatchService_SharedContextNotSet {
            get {
                return ResourceManager.GetString("ModelBatchService_SharedContextNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not add {0}. The parent identifier was not set..
        /// </summary>
        internal static string ModelService_AddFailed_RequiredParentNotset {
            get {
                return ResourceManager.GetString("ModelService_AddFailed_RequiredParentNotset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Member delegate &apos;{0}&apos; not set to instance of an object..
        /// </summary>
        internal static string ModelService_DelegateIsNull {
            get {
                return ResourceManager.GetString("ModelService_DelegateIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parent key for this service has already been set and cannot be modified..
        /// </summary>
        internal static string ModelService_ParentKeyAlreadySet {
            get {
                return ResourceManager.GetString("ModelService_ParentKeyAlreadySet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The service parent key has not been set. This error occurs when a service method is called before a call to &apos;Initialize(TParentKey)&apos;..
        /// </summary>
        internal static string ModelService_ParentKeyNotSet {
            get {
                return ResourceManager.GetString("ModelService_ParentKeyNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parents for this service are not supported..
        /// </summary>
        internal static string ModelService_ParentNotSupported {
            get {
                return ResourceManager.GetString("ModelService_ParentNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query complexity limit ({0}) reached. Consider increasing the navigation path limit or re-writing the query..
        /// </summary>
        internal static string ModelService_QueryComplexityNotSupported {
            get {
                return ResourceManager.GetString("ModelService_QueryComplexityNotSupported", resourceCulture);
            }
        }
    }
}
