using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(ReportConfigurationDto_SR.Noun_Plural),
        PluralArticle = nameof(ReportConfigurationDto_SR.Noun_Plural_Article),
        Singular = nameof(ReportConfigurationDto_SR.Noun_Singular),
        SingularArticle = nameof(ReportConfigurationDto_SR.Noun_Singular_Article),
        ResourceType = typeof(ReportConfigurationDto_SR)
        )]
    public class ReportConfigurationDto : DtoBase
    {
        private int _configurationId;
        private string _configurationCode;
        private string _configurationDescription;
        private string _xmlDefinition;

        [Key]
        public int ConfigurationId
        {
            get { return _configurationId; }
            set
            {
                if (_configurationId != value)
                {
                    _configurationId = value;
                    OnPropertyChanged(nameof(ConfigurationId));
                }
            }
        }

        [Display(
            Name = nameof(ReportConfigurationDto_SR.ConfigurationCode_Name),
            Description = nameof(ReportConfigurationDto_SR.ConfigurationCode_Description),
            ResourceType = typeof(ReportConfigurationDto_SR))]
        public string ConfigurationCode
        {
            get { return _configurationCode; }
            set
            {
                if (_configurationCode != value)
                {
                    _configurationCode = value;
                    OnPropertyChanged(nameof(ConfigurationCode));
                }
            }
        }

        [Display(
            Name = nameof(ReportConfigurationDto_SR.ConfigurationDescription_Name),
            Description = nameof(ReportConfigurationDto_SR.ConfigurationDescription_Description),
            ResourceType = typeof(ReportConfigurationDto_SR))]
        public string ConfigurationDescription
        {
            get { return _configurationDescription; }
            set
            {
                if (_configurationDescription != value)
                {
                    _configurationDescription = value;
                    OnPropertyChanged(nameof(ConfigurationDescription));
                }
            }
        }

        [Display(
            Name = nameof(ReportConfigurationDto_SR.XmlDefinition_Name),
            Description = nameof(ReportConfigurationDto_SR.XmlDefinition_Description),
            ResourceType = typeof(ReportConfigurationDto_SR))]
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
