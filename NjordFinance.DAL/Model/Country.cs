using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("Country", Schema = "FinanceApp")]
    public partial class Country
    {
        public Country()
        {
            CountryAttributeMemberEntries = new HashSet<CountryAttributeMemberEntry>();
        }

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72)]
        public string DisplayName { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(3)]
        public string IsoCode3 { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(ModelAttributeMember.Country))]
        public virtual ModelAttributeMember AttributeMemberNavigation { get; set; }

        [InverseProperty(nameof(CountryAttributeMemberEntry.Country))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
