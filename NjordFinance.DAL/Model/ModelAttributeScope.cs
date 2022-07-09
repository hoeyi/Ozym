using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("ModelAttributeScope", Schema = "FinanceApp")]
    public partial class ModelAttributeScope
    {
        [Key]
        [Column("AttributeID", Order = 0)]
        public int AttributeId { get; set; }
        [Key]
        [StringLength(3,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [Column(nameof(ScopeCode), Order = 1)]
        public string ScopeCode { get; set; }

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty(nameof(ModelAttribute.ModelAttributeScopes))]
        public virtual ModelAttribute Attribute { get; set; }
    }
}
