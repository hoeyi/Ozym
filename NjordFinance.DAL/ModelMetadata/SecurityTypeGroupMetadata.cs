using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="SecurityTypeGroup"/>.
    /// </summary>
    public class SecurityTypeGroupMetadata
    {
    }

    [MetadataType(typeof(SecurityTypeGroupMetadata))]
    public partial class SecurityTypeGroup
    {
        internal SecurityTypeGroup(
            int securityTypeGroupId,
            string securityTypeGroupName,
            int attributeMemberId)
        {
            SecurityTypeGroupId = securityTypeGroupId;
            SecurityTypeGroupName = securityTypeGroupName;
            AttributeMemberId = attributeMemberId;
        }
    }
}
