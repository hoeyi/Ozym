using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("SecurityExchange", Schema = "FinanceApp")]
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
        [Required]
        [StringLength(128)]
        public string ExchangeDescription { get; set; }

        [InverseProperty(nameof(Security.SecurityExchange))]
        public virtual ICollection<Security> Securities { get; set; }
    }
}
