using NjordFinance.Model.Metadata;
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

        private string _isoCode3;

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(3,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string IsoCode3
        {
            get { return _isoCode3; }
            set
            {
                if(_isoCode3 != value)
                {
                    _isoCode3 = value;
                    if (AttributeMemberNavigation is not null)
                        AttributeMemberNavigation.DisplayName = _isoCode3;
                }
            }
        }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(ModelAttributeMember.Country))]
        public virtual ModelAttributeMember AttributeMemberNavigation { get; set; }

        [InverseProperty(nameof(CountryAttributeMemberEntry.Country))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
