using Ichosys.DataModel.Annotations;
using Ozym.DataTransfer.Common.Collections;
using Ozym.EntityModel.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(InvestmentModelDto_SR.Noun_Plural),
        PluralArticle = nameof(InvestmentModelDto_SR.Noun_Plural_Article),
        Singular = nameof(InvestmentModelDto_SR.Noun_Singular),
        SingularArticle = nameof(InvestmentModelDto_SR.Noun_Singular_Article),
        ResourceType = typeof(InvestmentModelDto_SR)
        )]
    public class InvestmentModelDtoBase : DtoBase
    {
        private int _investmentModelId;
        private string _displayName;
        private string _notes;

        [Key]
        public int InvestmentModelId
        {
            get { return _investmentModelId; }
            set
            {
                if (_investmentModelId != value)
                {
                    _investmentModelId = value;
                    OnPropertyChanged(nameof(InvestmentModelId));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentModelDto_SR.DisplayName_Name),
            Description = nameof(InvestmentModelDto_SR.DisplayName_Description),
            ResourceType = typeof(InvestmentModelDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentModelDto_SR.Notes_Name),
            Description = nameof(InvestmentModelDto_SR.Notes_Description),
            ResourceType = typeof(InvestmentModelDto_SR))]
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }
    }

    [Noun(
        Plural = nameof(InvestmentModelDto_SR.Noun_Plural),
        PluralArticle = nameof(InvestmentModelDto_SR.Noun_Plural_Article),
        Singular = nameof(InvestmentModelDto_SR.Noun_Singular),
        SingularArticle = nameof(InvestmentModelDto_SR.Noun_Singular_Article),
        ResourceType = typeof(InvestmentModelDto_SR)
        )]
    public class InvestmentModelDto : InvestmentModelDtoBase
    {
        private ICollection<InvestmentModelTargetDto> _targets;
        public InvestmentModelDto()
        {
            Targets = new HashSet<InvestmentModelTargetDto>();
        }

        public ICollection<InvestmentModelTargetDto> Targets
        {
            get { return _targets; }
            set
            {
                if(_targets != value)
                {
                    _targets = value;
                    TargetCollection = new(this);
                }
            }
        }

        [JsonIgnore]
        public InvestmentModelTargetDtoCollection TargetCollection { get; private set; }
    }
}
