using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ReportStyleSheet", Schema = "FinanceApp")]
    [Index(nameof(StyleSheetCode), Name = "UNI_ReportStyleSheet_StyleSheetCode", IsUnique = true)]
    public partial class ReportStyleSheet
    {
        [Key]
        [Column("StyleSheetID")]
        public int StyleSheetId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string StyleSheetCode { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string StyleSheetDescription { get; set; } = null!;
        [Column(TypeName = "xml")]
        public string XmlDefinition { get; set; } = null!;
    }
}
