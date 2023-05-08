namespace NjordinSight.EntityModel.Annotations
{
    /// <summary>
    /// Provides a class attribute for specifying the allowable <see cref="ModelAttribute"/> 
    /// definitions for the decorated type, based on predefined <see cref="ModelAttributeScopeCode"/> 
    /// values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ModelAttributeSupportAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the supported scope codes.
        /// </summary>
        public ModelAttributeScopeCode SupportedScopes { get; init; }
    }
}
