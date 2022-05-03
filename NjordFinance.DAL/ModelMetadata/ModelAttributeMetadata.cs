using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ModelAttribute"/>.
    /// </summary>
    public class ModelAttributeMetadata
    {
    }

    [MetadataType(typeof(ModelAttributeMetadata))]
    public partial class ModelAttribute
    {
        internal ModelAttribute(int attributeId, string displayName)
        {
            AttributeId = attributeId;
            DisplayName = displayName;
        }
    }
}
