using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NjordinSight.DataTransfer.Common
{
    public class AccountCustodianDto : DtoBase
    {
        private int _accountCustodianId;
        private string _custodianCode;
        private string _displayName;

        [Display(
            Name = nameof(AccountCustodianDto_SR.AccountCustodianId_Name),
            Description = nameof(AccountCustodianDto_SR.AccountCustodianId_Description),
            ResourceType = typeof(AccountCustodianDto_SR))]
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
