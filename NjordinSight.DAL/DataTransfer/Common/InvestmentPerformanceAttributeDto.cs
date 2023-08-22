using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    internal class InvestmentPerformanceAttributeDto : InvestmentPerformanceDto
    {
        private int _attributeMemberId;

        [Display(
            Name = nameof(InvestmentPerformanceAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(InvestmentPerformanceAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(InvestmentPerformanceAttributeDto_SR))]
        public int AttributeMemberId
        {
            get { return _attributeMemberId; }
            set
            {
                if (_attributeMemberId != value)
                {
                    _attributeMemberId = value;
                    OnPropertyChanged(nameof(AttributeMemberId));
                }
            }
        }
    }
}
