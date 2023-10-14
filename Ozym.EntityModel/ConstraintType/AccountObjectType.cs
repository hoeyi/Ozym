using System.Runtime.Serialization;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Represents the supported values for <see cref="AccountObject.ObjectType"/>.
    /// </summary>
    public enum AccountObjectType
    {
        /// <summary>
        /// An individual custodian account.
        /// </summary>
        [EnumMember(Value = "a")]
        Account = 0,

        /// <summary>
        /// A collection of one or more accounts over time.
        /// </summary>
        [EnumMember(Value = "c")]
        Composite = 1
    }
}
