using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("ModelAttributeScope", Schema = "FinanceApp")]
    public partial class ModelAttributeScope
    {
        [Key]
        [Column("AttributeID")]
        public int AttributeId { get; set; }
        [Key]
        [StringLength(3)]
        public string ScopeCode { get; set; }

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty(nameof(ModelAttribute.ModelAttributeScopes))]
        public virtual ModelAttribute Attribute { get; set; }
    }
}
