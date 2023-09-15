using Ichosys.DataModel.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(MarketIndexDto_SR.Noun_Plural),
        PluralArticle = nameof(MarketIndexDto_SR.Noun_Plural_Article),
        Singular = nameof(MarketIndexDto_SR.Noun_Singular),
        SingularArticle = nameof(MarketIndexDto_SR.Noun_Singular_Article),
        ResourceType = typeof(MarketIndexDto_SR)
        )]
    public class MarketIndexDto : DtoBase
    {
        private int _indexId;
        private string _indexCode;
        private string _indexDescription;

        [Key]
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
