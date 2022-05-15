using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ReportConfiguration", Schema = "FinanceApp")]
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
