using NjordFinance.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.EntityModel
{
    [Table("ReportConfiguration", Schema = "FinanceApp")]
    public partial class ReportConfiguration
    {
        [Key]
        [Column("ConfigurationID")]
        public int ConfigurationId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string ConfigurationCode { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string ConfigurationDescription { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Column(TypeName = "xml")]
        public string XmlDefinition { get; set; }
    }
}
