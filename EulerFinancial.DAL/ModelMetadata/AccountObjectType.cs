using System.Runtime.Serialization;

namespace EulerFinancial.ModelMetadata
{
    /// <summary>
    /// List the support account object types and 
    /// their database codes.
    /// </summary>
    public enum AccountObjectType
    {
        /// <summary>
        /// An individual custodian account.
        /// </summary>
        [EnumMember(Value = "a")]
        Account = 0,

        /// <summary>
        /// A collection of one or more accounts.
        /// </summary>
        [EnumMember(Value = "g")]
        Group = 1
    }
}
