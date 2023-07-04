using AutoMapper;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Represents the base requirements for a test class targetting a class derived from
    /// <see cref="Profile"/>.
    /// </summary>
    internal interface IProfileTest
    {
        /// <summary>
        /// Verify a configuration built with all required profiles in the dependency tree is valid.
        /// </summary>
        public void Configuration_IsValid();
    }
}
