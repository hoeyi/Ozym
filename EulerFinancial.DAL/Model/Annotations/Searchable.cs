using System;

namespace EulerFinancial.Model.Annotations
{
    /// <summary>
    /// Indicates a class has searchable properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SearchableAttribute : Attribute
    {
        private readonly string[] searchableMembers;
        public SearchableAttribute(params string[] memberNames)
        {
            searchableMembers = memberNames ?? Array.Empty<string>();
        }

        public string[] SearchableMembers
        {
            get{ return searchableMembers; }
        }
    }
}
