using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ModelAttributeScope"/>.
    /// </summary>
    public class ModelAttributeScopeMetadata
    {
    }

    [MetadataType(typeof(ModelAttributeScopeMetadata))]
    public partial class ModelAttributeScope
    {
        public ModelAttributeScope()
        {
        }

        internal ModelAttributeScope(int attributeId, string scopeCode)
        {
            AttributeId = attributeId;
            ScopeCode = scopeCode;
        }
    }
}
