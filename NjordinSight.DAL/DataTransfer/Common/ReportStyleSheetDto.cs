using Ichosys.DataModel.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(ReportStyleSheetDto_SR.Noun_Plural),
        PluralArticle = nameof(ReportStyleSheetDto_SR.Noun_Plural_Article),
        Singular = nameof(ReportStyleSheetDto_SR.Noun_Singular),
        SingularArticle = nameof(ReportStyleSheetDto_SR.Noun_Singular_Article),
        ResourceType = typeof(ReportStyleSheetDto_SR)
        )]
    public class ReportStyleSheetDto : DtoBase
    {
        private int _styleSheetId;
        private string _styleSheetCode;
        private string _styleSheetDescription;
        private string _xmlDefinition;

        [Key]
        public int StyleSheetId
        {
            get { return _styleSheetId; }
            set
            {
                if (_styleSheetId != value)
                {
                    _styleSheetId = value;
                    OnPropertyChanged(nameof(StyleSheetId));
                }
            }
        }

        [Display(
            Name = nameof(ReportStyleSheetDto_SR.StyleSheetCode_Name),
            Description = nameof(ReportStyleSheetDto_SR.StyleSheetCode_Description),
            ResourceType = typeof(ReportStyleSheetDto_SR))]
        public string StyleSheetCode
        {
            get { return _styleSheetCode; }
            set
            {
                if (_styleSheetCode != value)
                {
                    _styleSheetCode = value;
                    OnPropertyChanged(nameof(StyleSheetCode));
                }
            }
        }

        [Display(
            Name = nameof(ReportStyleSheetDto_SR.StyleSheetDescription_Name),
            Description = nameof(ReportStyleSheetDto_SR.StyleSheetDescription_Description),
            ResourceType = typeof(ReportStyleSheetDto_SR))]
        public string StyleSheetDescription
        {
            get { return _styleSheetDescription; }
            set
            {
                if (_styleSheetDescription != value)
                {
                    _styleSheetDescription = value;
                    OnPropertyChanged(nameof(StyleSheetDescription));
                }
            }
        }

        [Display(
            Name = nameof(ReportStyleSheetDto_SR.XmlDefinition_Name),
            Description = nameof(ReportStyleSheetDto_SR.XmlDefinition_Description),
            ResourceType = typeof(ReportStyleSheetDto_SR))]
        public string XmlDefinition
        {
            get { return _xmlDefinition; }
            set
            {
                if (_xmlDefinition != value)
                {
                    _xmlDefinition = value;
                    OnPropertyChanged(nameof(XmlDefinition));
                }
            }
        }
    }

}
