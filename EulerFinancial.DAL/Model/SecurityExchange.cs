using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("SecurityExchange", Schema = "EulerApp")]
    [Index(nameof(ExchangeCode), Name = "UNI_SecurityExchange_ExchangeCode", IsUnique = true)]
    public partial class SecurityExchange
    {
        public SecurityExchange()
        {
            Securities = new HashSet<Security>();
        }

        [Key]
        [Column("ExchangeID")]
        public int ExchangeId { get; set; }
        [Required]
        [StringLength(16)]
        public string ExchangeCode { get; set; }
        [StringLength(128)]
        public string ExchangeDescription { get; set; }

        [InverseProperty(nameof(Security.SecurityExchange))]
        public virtual ICollection<Security> Securities { get; set; }
    }
}
