namespace NjordFinance.Model
{
    /// <summary>
    /// Represents a visible member of a model class.
    /// </summary>
    public class ModelMemberMetadata
    {
        internal ModelMemberMetadata(
            string declaringMemberName,
            string qualifiedMemberName,
            string displayName,
            string description,
            int displayOrder)
        {
            DeclaringMemberName = declaringMemberName;
            QualifiedMemberName = qualifiedMemberName;
            DisplayName = displayName;
            Description = description;
            DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Gets the field name, including the declarying type.
        /// </summary>
        /// <example>AccountObject.StartDate</example>
        public string DeclaringMemberName { get; }

        /// <summary>
        /// Gets the period-delimited member name, excluding the declarying type. 
        /// </summary>
        /// <example>From Account: AccountNavigation.StartDate, AccountFull</example>
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

        /// <summary>
        /// Gets the display order of the member.
        /// </summary>
        public int DisplayOrder { get; }
    }
}
