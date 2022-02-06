using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("ReportStyleSheet", Schema = "EulerApp")]
    [Index(nameof(StyleSheetCode), Name = "UNI_ReportStyleSheet_StyleSheetCode", IsUnique = true)]
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
