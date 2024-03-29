﻿using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(AccountWalletDto_SR.Noun_Plural),
        PluralArticle = nameof(AccountWalletDto_SR.Noun_Plural_Article),
        Singular = nameof(AccountWalletDto_SR.Noun_Singular),
        SingularArticle = nameof(AccountWalletDto_SR.Noun_Singular_Article),
        ResourceType = typeof(AccountWalletDto_SR)
        )]
    public class AccountWalletDto : DtoBase
    {
        private int _accountId;
        private int _accountWalletId;
        private string _addressCode;
        private string _addressTag;
        private int _denominationSecurityId;

        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if(_accountId != value )
                {
                    _accountId = value;
                    OnPropertyChanged(nameof(AccountId));
                }
            }
        }

        [Key]
        public int AccountWalletId
        {
            get { return _accountWalletId; }
            set
            {
                if (_accountWalletId != value)
                {
                    _accountWalletId = value;
                    OnPropertyChanged(nameof(AccountWalletId));
                }
            }
        }

        [Display(
            Name = nameof(AccountWalletDto_SR.AddressCode_Name),
            Description = nameof(AccountWalletDto_SR.AddressCode_Description),
            ResourceType = typeof(AccountWalletDto_SR))]
        public string AddressCode
        {
            get { return _addressCode; }
            set
            {
                if (_addressCode != value)
                {
                    _addressCode = value;
                    OnPropertyChanged(nameof(AddressCode));
                }
            }
        }

        [Display(
            Name = nameof(AccountWalletDto_SR.AddressTag_Name),
            Description = nameof(AccountWalletDto_SR.AddressTag_Description),
            ResourceType = typeof(AccountWalletDto_SR))]
        public string AddressTag
        {
            get { return _addressTag; }
            set
            {
                if (_addressTag != value)
                {
                    _addressTag = value;
                    OnPropertyChanged(nameof(AddressTag));
                }
            }
        }

        [Display(
            Name = nameof(AccountWalletDto_SR.DenominationSecurityId_Name),
            Description = nameof(AccountWalletDto_SR.DenominationSecurityId_Description),
            ResourceType = typeof(AccountWalletDto_SR))]
        public int DenominationSecurityId
        {
            get { return _denominationSecurityId; }
            set
            {
                if (_denominationSecurityId != value)
                {
                    _denominationSecurityId = value;
                    OnPropertyChanged(nameof(DenominationSecurityId));
                }
            }
        }
    }

}
