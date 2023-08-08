﻿using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.EntityModel.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class InvestmentModelDtoBase : DtoBase
    {
        private int _investmentModelId;
        private string _displayName;
        private string _notes;

        [Display(
            Name = nameof(InvestmentModelDto_SR.InvestmentModelId_Name),
            Description = nameof(InvestmentModelDto_SR.InvestmentModelId_Description),
            ResourceType = typeof(InvestmentModelDto_SR))]
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

    public class InvestmentModelDto : InvestmentModelDtoBase
    {
        public InvestmentModelDto()
        {
            TargetCollection = new(this);
            Targets = new List<InvestmentModelTargetDto>();
        }

        public InvestmentModelTargetDtoCollection TargetCollection { get; set; }

        public ICollection<InvestmentModelTargetDto> Targets { get; set; }
    }

}
