using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class MarketIndexDto : DtoBase
    {
        private int _indexId;
        private string _indexCode;
        private string _indexDescription;

        [Display(
            Name = nameof(MarketIndexDto_SR.IndexId_Name),
            Description = nameof(MarketIndexDto_SR.IndexId_Description),
            ResourceType = typeof(MarketIndexDto_SR))]
        public int IndexId
        {
            get { return _indexId; }
            set
            {
                if (_indexId != value)
                {
                    _indexId = value;
                    OnPropertyChanged(nameof(IndexId));
                }
            }
        }

        [Display(
            Name = nameof(MarketIndexDto_SR.IndexCode_Name),
            Description = nameof(MarketIndexDto_SR.IndexCode_Description),
            ResourceType = typeof(MarketIndexDto_SR))]
        public string IndexCode
        {
            get { return _indexCode; }
            set
            {
                if (_indexCode != value)
                {
                    _indexCode = value;
                    OnPropertyChanged(nameof(IndexCode));
                }
            }
        }

        [Display(
            Name = nameof(MarketIndexDto_SR.IndexDescription_Name),
            Description = nameof(MarketIndexDto_SR.IndexDescription_Description),
            ResourceType = typeof(MarketIndexDto_SR))]
        public string IndexDescription
        {
            get { return _indexDescription; }
            set
            {
                if (_indexDescription != value)
                {
                    _indexDescription = value;
                    OnPropertyChanged(nameof(IndexDescription));
                }
            }
        }
    }

}
