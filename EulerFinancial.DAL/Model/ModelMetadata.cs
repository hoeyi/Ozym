namespace EulerFinancial.Model
{
    /// <summary>
    /// Represents a visible field in a UI element.
    /// </summary>
    public class ModelMetadata
    {
        internal ModelMetadata(
            string declaringMemberName,
            string qualifiedMemberName,
            string displayName,
            string description)
        {
            DeclaringMemberName = declaringMemberName;
            QualifiedMemberName = qualifiedMemberName;
            DisplayName = displayName;
            Description = description;
        }

        /// <summary>
        /// Gets the field name, including the declarying type.
        /// </summary>
        public string DeclaringMemberName { get; }

        /// <summary>
        /// Gets the period-delimited member name, excluding the declarying type. 
        /// </summary>
        /// <example>From Account: AccountNavigationStartDate, AccountFull</example>
        /// <remarks>Use this property when constructing search epxressions dynamcially.</remarks>
        public string QualifiedMemberName { get; }
        
        /// <summary>
        /// Gets the display name of the member.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the description of the member.
        /// </summary>
        public string Description { get; }
    }
}
