﻿using System;
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
    public class BrokerTransactionDto : DtoBase, INotifyPropertyChanged
    {
        private int _transactionId;
        private int _transactionCodeId;
        private DateTime _tradeDate;
        private DateTime? _settleDate;
        private DateTime? _acquisitionDate;
        private int _securityId;
        private decimal? _quantity;
        private decimal _amount;
        private decimal? _fee;
        private decimal? _withholding;
        private int? _depSecurityId;
        private int? _taxLotId;

        [Display(
            Name = nameof(BrokerTransactionDto_SR.TransactionId_Name),
            Description = nameof(BrokerTransactionDto_SR.TransactionId_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
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
            Name = nameof(BrokerTransactionDto_SR.TransactionCodeId_Name),
            Description = nameof(BrokerTransactionDto_SR.TransactionCodeId_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
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
            Name = nameof(BrokerTransactionDto_SR.TradeDate_Name),
            Description = nameof(BrokerTransactionDto_SR.TradeDate_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public DateTime TradeDate
        {
            get { return _tradeDate; }
            set
            {
                if (_tradeDate != value)
                {
                    _tradeDate = value;
                    OnPropertyChanged(nameof(TradeDate));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.SettleDate_Name),
            Description = nameof(BrokerTransactionDto_SR.SettleDate_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public DateTime? SettleDate
        {
            get { return _settleDate; }
            set
            {
                if (_settleDate != value)
                {
                    _settleDate = value;
                    OnPropertyChanged(nameof(SettleDate));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.AcquisitionDate_Name),
            Description = nameof(BrokerTransactionDto_SR.AcquisitionDate_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public DateTime? AcquisitionDate
        {
            get { return _acquisitionDate; }
            set
            {
                if (_acquisitionDate != value)
                {
                    _acquisitionDate = value;
                    OnPropertyChanged(nameof(AcquisitionDate));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.SecurityId_Name),
            Description = nameof(BrokerTransactionDto_SR.SecurityId_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public int SecurityId
        {
            get { return _securityId; }
            set
            {
                if (_securityId != value)
                {
                    _securityId = value;
                    OnPropertyChanged(nameof(SecurityId));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.Quantity_Name),
            Description = nameof(BrokerTransactionDto_SR.Quantity_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public decimal? Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.Amount_Name),
            Description = nameof(BrokerTransactionDto_SR.Amount_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
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
            Name = nameof(BrokerTransactionDto_SR.Fee_Name),
            Description = nameof(BrokerTransactionDto_SR.Fee_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public decimal? Fee
        {
            get { return _fee; }
            set
            {
                if (_fee != value)
                {
                    _fee = value;
                    OnPropertyChanged(nameof(Fee));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.Withholding_Name),
            Description = nameof(BrokerTransactionDto_SR.Withholding_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public decimal? Withholding
        {
            get { return _withholding; }
            set
            {
                if (_withholding != value)
                {
                    _withholding = value;
                    OnPropertyChanged(nameof(Withholding));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.DepSecurityId_Name),
            Description = nameof(BrokerTransactionDto_SR.DepSecurityId_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public int? DepSecurityId
        {
            get { return _depSecurityId; }
            set
            {
                if (_depSecurityId != value)
                {
                    _depSecurityId = value;
                    OnPropertyChanged(nameof(DepSecurityId));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionDto_SR.TaxLotId_Name),
            Description = nameof(BrokerTransactionDto_SR.TaxLotId_Description),
            ResourceType = typeof(BrokerTransactionDto_SR))]
        public int? TaxLotId
        {
            get { return _taxLotId; }
            set
            {
                if (_taxLotId != value)
                {
                    _taxLotId = value;
                    OnPropertyChanged(nameof(TaxLotId));
                }
            }
        }
    }

}
