﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NjordinSight.EntityModel.Context {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NjordinSight.EntityModel.Context.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Duplicate key values for the same entity type were found in the configuration collection. Review applied entity configurations for the following types/sources..
        /// </summary>
        internal static string ConfigurationCollection_Validation_KeyDuplication {
            get {
                return ResourceManager.GetString("ConfigurationCollection_Validation_KeyDuplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The order for composite key on type {0} could not be determined..
        /// </summary>
        internal static string EntityConfiguration_Exception_CompositeKeyNotOrdered {
            get {
                return ResourceManager.GetString("EntityConfiguration_Exception_CompositeKeyNotOrdered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No public properties for type {0} with key indicator &apos;{1}&apos; applied were found..
        /// </summary>
        internal static string EntityConfiguration_Exception_NoKeyForType {
            get {
                return ResourceManager.GetString("EntityConfiguration_Exception_NoKeyForType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Asset Class.
        /// </summary>
        internal static string ModelAttribute_AssetClass {
            get {
                return ResourceManager.GetString("ModelAttribute_AssetClass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction Category.
        /// </summary>
        internal static string ModelAttribute_BrokerTransactionCategory {
            get {
                return ResourceManager.GetString("ModelAttribute_BrokerTransactionCategory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction Class.
        /// </summary>
        internal static string ModelAttribute_BrokerTransactionClass {
            get {
                return ResourceManager.GetString("ModelAttribute_BrokerTransactionClass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Country Exposure.
        /// </summary>
        internal static string ModelAttribute_CountryExposure {
            get {
                return ResourceManager.GetString("ModelAttribute_CountryExposure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Security Type.
        /// </summary>
        internal static string ModelAttribute_SecurityType {
            get {
                return ResourceManager.GetString("ModelAttribute_SecurityType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Security Type Group.
        /// </summary>
        internal static string ModelAttribute_SecurityTypeGroup {
            get {
                return ResourceManager.GetString("ModelAttribute_SecurityTypeGroup", resourceCulture);
            }
        }
    }
}
