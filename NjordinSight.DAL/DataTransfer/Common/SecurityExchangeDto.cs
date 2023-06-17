using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class SecurityExchangeDto : DtoBase
    {
        private int _exchangeId;
        private string _exchangeCode;
        private string _exchangeDescription;

        [Display(
            Name = nameof(SecurityExchangeDto_SR.ExchangeId_Name),
            Description = nameof(SecurityExchangeDto_SR.ExchangeId_Description),
            ResourceType = typeof(SecurityExchangeDto_SR))]
        public int ExchangeId
        {
            get { return _exchangeId; }
            set
            {
                if (_exchangeId != value)
                {
                    _exchangeId = value;
                    OnPropertyChanged(nameof(ExchangeId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityExchangeDto_SR.ExchangeCode_Name),
            Description = nameof(SecurityExchangeDto_SR.ExchangeCode_Description),
            ResourceType = typeof(SecurityExchangeDto_SR))]
        public string ExchangeCode
        {
            get { return _exchangeCode; }
            set
            {
                if (_exchangeCode != value)
                {
                    _exchangeCode = value;
                    OnPropertyChanged(nameof(ExchangeCode));
                }
            }
        }

        [Display(
            Name = nameof(SecurityExchangeDto_SR.ExchangeDescription_Name),
            Description = nameof(SecurityExchangeDto_SR.ExchangeDescription_Description),
            ResourceType = typeof(SecurityExchangeDto_SR))]
        public string ExchangeDescription
        {
            get { return _exchangeDescription; }
            set
            {
                if (_exchangeDescription != value)
                {
                    _exchangeDescription = value;
                    OnPropertyChanged(nameof(ExchangeDescription));
                }
            }
        }
    }

}
