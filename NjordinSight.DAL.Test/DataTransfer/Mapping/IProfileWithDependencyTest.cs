using AutoMapper;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Represents the requirements for a test class targetting a class derived from
    /// <see cref="Profile"/>, where valid configuration depends on adding one or more
    /// <see cref="Profile"/>-derived classes as prerequisite.
    /// </summary>
    internal interface IProfileWithDependencyTest
    {
        /// <summary>
        /// Verify a configuration built without all required profiles in the dependency tree
        /// throws an <see cref="AutoMapperConfigurationException"/>.
        /// </summary>
        void Configuration_WithoutProfileDependencies_IsInvalid();
    }
}
