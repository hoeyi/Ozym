using System;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(BankTransactionDto_SR.Noun_Plural),
        PluralArticle = nameof(BankTransactionDto_SR.Noun_Plural_Article),
        Singular = nameof(BankTransactionDto_SR.Noun_Singular),
        SingularArticle = nameof(BankTransactionDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BankTransactionDto_SR)
        )]
    public class BankTransactionDto : DtoBase
    {
        private int _accountId;
        private int _transactionId;
        private DateTime _transactionDate;
        private int _transactionCodeId;
        private decimal _amount;
        private string _comment;

        public int AccountId
        {
            get
            {
                return _accountId;
            }
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
        public int TransactionId
        {
            get { return _transactionId; }
            set
            {
                if (_transactionId != value)
                {
                    _transactionId = value;
                    OnPropertyChanged(nameof(TransactionId));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionDto_SR.TransactionDate_Name),
            Description = nameof(BankTransactionDto_SR.TransactionDate_Description),
            ResourceType = typeof(BankTransactionDto_SR))]
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                if (_transactionDate != value)
                {
                    _transactionDate = value;
                    OnPropertyChanged(nameof(TransactionDate));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionDto_SR.TransactionCodeId_Name),
            Description = nameof(BankTransactionDto_SR.TransactionCodeId_Description),
            ResourceType = typeof(BankTransactionDto_SR))]
        public int TransactionCodeId
        {
            get { return _transactionCodeId; }
            set
            {
                if (_transactionCodeId != value)
                {
                    _transactionCodeId = value;
                    OnPropertyChanged(nameof(TransactionCodeId));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionDto_SR.Amount_Name),
            Description = nameof(BankTransactionDto_SR.Amount_Description),
            ResourceType = typeof(BankTransactionDto_SR))]
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionDto_SR.Comment_Name),
            Description = nameof(BankTransactionDto_SR.Comment_Description),
            ResourceType = typeof(BankTransactionDto_SR))]
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

        public byte[] TransactionVersion { get; set; }
    }
}
