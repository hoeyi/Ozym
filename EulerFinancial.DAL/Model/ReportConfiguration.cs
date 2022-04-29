using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("ReportConfiguration", Schema = "EulerApp")]
    [Index(nameof(ConfigurationCode), Name = "UNI_ReportConfiguration_ConfigurationCode", IsUnique = true)]
    public partial class ReportConfiguration
    {
        [Key]
        [Column("ConfigurationID")]
        public int ConfigurationId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string ConfigurationCode { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string ConfigurationDescription { get; set; } = null!;
        [Column(TypeName = "xml")]
        public string XmlDefinition { get; set; } = null!;
    }
}
