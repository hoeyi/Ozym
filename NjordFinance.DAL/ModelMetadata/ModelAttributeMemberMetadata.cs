using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ModelAttributeMember"/>.
    /// </summary>
    public class ModelAttributeMemberMetadata
    {
    }

    [MetadataType(typeof(ModelAttributeMemberMetadata))]
    public partial class ModelAttributeMember
    {
        internal ModelAttributeMember(
            int attributeMemberId, int attributeId, string displayName, short displayOrder)
        {
            AttributeMemberId = attributeMemberId;
            AttributeId = attributeId;
            DisplayName = displayName;
            DisplayOrder = displayOrder;
        }
    }
}
