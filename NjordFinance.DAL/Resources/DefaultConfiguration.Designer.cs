﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NjordFinance.Resources {
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
    internal class DefaultConfiguration {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DefaultConfiguration() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NjordFinance.Resources.DefaultConfiguration", typeof(DefaultConfiguration).Assembly);
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
        ///   Looks up a localized string similar to {
        ///  &quot;Id&quot;: 0,
        ///  &quot;ObjectGuid&quot;: &quot;9ced3bce-4e09-4217-b013-88518257e1c4&quot;,
        ///  &quot;Name&quot;: &quot;Display.Account&quot;,
        ///  &quot;ApplicableTo&quot;: &quot;NjordFinance.Model.Account, NjordFinance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&quot;,
        ///  &quot;DisplayOrder&quot;: {
        ///    &quot;AccountObject.AccountObjectCode&quot;: 0,
        ///    &quot;AccountObject.StartDate&quot;: 1,
        ///    &quot;AccountObject.CloseDate&quot;: 2
        ///  }
        ///}.
        /// </summary>
        internal static string Display_Account {
            get {
                return ResourceManager.GetString("Display.Account", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;ReportConfiguration xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&lt;Settings&gt;&lt;Setting Name=&quot;CurrencyPrecision&quot; Label=&quot;Currency Precision&quot; Value=&quot;c&quot; /&gt;&lt;Setting Name=&quot;IncludeClosed&quot; Label=&quot;Include Closed&quot; Value=&quot;false&quot; /&gt;&lt;Setting Name=&quot;TradableAccountsOnly&quot; Label=&quot;Tradable Accounts Only&quot; Value=&quot;true&quot; /&gt;&lt;Setting Name=&quot;Theme&quot; Label=&quot;Theme&quot; Value=&quot;Default&quot; /&gt;&lt;/Settings&gt;&lt;/ReportConfiguration&gt;.
        /// </summary>
        internal static string Report_Parameters {
            get {
                return ResourceManager.GetString("Report.Parameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;StyleSheet xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&lt;Fonts&gt;&lt;Font Name=&quot;TableGroupHeader&quot; FontFamily=&quot;Arial&quot; FontWeight=&quot;Bold&quot; TextDecoration=&quot;Default&quot; FontStyle=&quot;Default&quot; FontSize=&quot;8pt&quot; Color=&quot;gray5&quot; BackColor=&quot;blue&quot; /&gt;&lt;Font Name=&quot;TableSubGroupHeader&quot; FontFamily=&quot;Arial&quot; FontWeight=&quot;SemiBold&quot; TextDecoration=&quot;Default&quot; FontStyle=&quot;Default&quot; FontSize=&quot;8pt&quot; Color=&quot;gray1&quot; BackColor=&quot;No Color&quot; /&gt;&lt;Font Name=&quot;TableColumnHeader&quot; FontFamily=&quot;Arial&quot; FontWeight=&quot;S [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Report_StyleSheet {
            get {
                return ResourceManager.GetString("Report.StyleSheet", resourceCulture);
            }
        }
    }
}
