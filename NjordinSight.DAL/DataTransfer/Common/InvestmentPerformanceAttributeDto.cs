using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(InvestmentPerformanceAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(InvestmentPerformanceAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(InvestmentPerformanceAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(InvestmentPerformanceAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(InvestmentPerformanceAttributeDto_SR)
        )]
    public class InvestmentPerformanceAttributeDto : InvestmentPerformanceDto
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

        public ModelAttributeDtoBase Attribute { get; set; } = new();
    }
}
