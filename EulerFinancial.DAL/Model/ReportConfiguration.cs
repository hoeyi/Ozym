using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("ReportConfiguration", Schema = "EulerApp")]
    [Index(nameof(ConfigurationCode), Name = "UNI_ReportConfiguration_ConfigurationCode", IsUnique = true)]
    public partial class ReportConfiguration
    {
        [Key]
        [Column("ConfigurationID")]
        public int ConfigurationId { get; set; }
        [Required]
        [StringLength(32)]
        public string ConfigurationCode { get; set; }
        [Required]
        [StringLength(128)]
        public string ConfigurationDescription { get; set; }
        [Required]
        [Column(TypeName = "xml")]
        public string XmlDefinition { get; set; }
    }
}
