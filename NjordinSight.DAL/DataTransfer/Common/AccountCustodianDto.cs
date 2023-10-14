using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(AccountCustodianDto_SR.Noun_Plural),
        PluralArticle = nameof(AccountCustodianDto_SR.Noun_Plural_Article),
        Singular = nameof(AccountCustodianDto_SR.Noun_Singular),
        SingularArticle = nameof(AccountCustodianDto_SR.Noun_Singular_Article),
        ResourceType = typeof(AccountCustodianDto_SR)
        )]
    public class AccountCustodianDto : DtoBase
    {
        private int _accountCustodianId;
        private string _custodianCode;
        private string _displayName;

        [Key]
        public int AccountCustodianId
        {
            get { return _accountCustodianId; }
            set
            {
                if (_accountCustodianId != value)
                {
                    _accountCustodianId = value;
                    OnPropertyChanged(nameof(AccountCustodianId));
                }
            }
        }

        [Display(
            Name = nameof(AccountCustodianDto_SR.CustodianCode_Name),
            Description = nameof(AccountCustodianDto_SR.CustodianCode_Description),
            ResourceType = typeof(AccountCustodianDto_SR))]
        public string CustodianCode
        {
            get { return _custodianCode; }
            set
            {
                if (_custodianCode != value)
                {
                    _custodianCode = value;
                    OnPropertyChanged(nameof(CustodianCode));
                }
            }
        }

        [Display(
            Name = nameof(AccountCustodianDto_SR.DisplayName_Name),
            Description = nameof(AccountCustodianDto_SR.DisplayName_Description),
            ResourceType = typeof(AccountCustodianDto_SR))]
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }
    }

}
