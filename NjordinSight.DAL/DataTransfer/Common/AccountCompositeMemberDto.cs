using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(AccountCompositeMemberDto_SR.Noun_Plural),
        PluralArticle = nameof(AccountCompositeMemberDto_SR.Noun_Plural_Article),
        Singular = nameof(AccountCompositeMemberDto_SR.Noun_Singular),
        SingularArticle = nameof(AccountCompositeMemberDto_SR.Noun_Singular_Article),
        ResourceType = typeof(AccountCompositeMemberDto_SR)
        )]
    public class AccountCompositeMemberDto : DtoBase
    {
        private int _accountCompositeId;
        private int _accountId;
        private DateTime _entryDate;
        private DateTime? _exitDate;
        private int _displayOrder;
        private string _comment;

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.AccountCompositeId_Name),
            Description = nameof(AccountCompositeMemberDto_SR.AccountCompositeId_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public int AccountCompositeId
        {
            get { return _accountCompositeId; }
            set
            {
                if (_accountCompositeId != value)
                {
                    _accountCompositeId = value;
                    OnPropertyChanged(nameof(AccountCompositeId));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.AccountId_Name),
            Description = nameof(AccountCompositeMemberDto_SR.AccountId_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(nameof(AccountId));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.EntryDate_Name),
            Description = nameof(AccountCompositeMemberDto_SR.EntryDate_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set
            {
                if (_entryDate != value)
                {
                    _entryDate = value;
                    OnPropertyChanged(nameof(EntryDate));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.ExitDate_Name),
            Description = nameof(AccountCompositeMemberDto_SR.ExitDate_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public DateTime? ExitDate
        {
            get { return _exitDate; }
            set
            {
                if (_exitDate != value)
                {
                    _exitDate = value;
                    OnPropertyChanged(nameof(ExitDate));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.DisplayOrder_Name),
            Description = nameof(AccountCompositeMemberDto_SR.DisplayOrder_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set
            {
                if (_displayOrder != value)
                {
                    _displayOrder = value;
                    OnPropertyChanged(nameof(DisplayOrder));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeMemberDto_SR.Comment_Name),
            Description = nameof(AccountCompositeMemberDto_SR.Comment_Description),
            ResourceType = typeof(AccountCompositeMemberDto_SR))]
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }
    }

}
