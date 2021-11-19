using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("ResourceImage", Schema = "EulerApp")]
    public partial class ResourceImage
    {
        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }
        [Required]
        [StringLength(128)]
        public string ImageDescription { get; set; }
        [Required]
        public byte[] ImageBinary { get; set; }
        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }
    }
}
