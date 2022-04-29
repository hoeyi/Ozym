using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [StringLength(16)]
        [Unicode(false)]
        public string ExchangeCode { get; set; } = null!;
        [StringLength(128)]
        public string? ExchangeDescription { get; set; }

        [InverseProperty(nameof(Security.SecurityExchange))]
        public virtual ICollection<Security> Securities { get; set; }
    }
}
