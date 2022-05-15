using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ReportStyleSheet", Schema = "FinanceApp")]
    public partial class ReportStyleSheet
    {
        [Key]
        [Column("StyleSheetID")]
        public int StyleSheetId { get; set; }
        [Required]
        [StringLength(32)]
        public string StyleSheetCode { get; set; }
        [Required]
        [StringLength(128)]
        public string StyleSheetDescription { get; set; }
        [Required]
        [Column(TypeName = "xml")]
        public string XmlDefinition { get; set; }
    }
}
