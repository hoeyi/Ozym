using Ichosys.DataModel.Annotations;
using Ozym.EntityModel;
using Ozym.EntityModel.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(AccountCompositeDto_SR.Noun_Plural),
        PluralArticle = nameof(AccountCompositeDto_SR.Noun_Plural_Article),
        Singular = nameof(AccountCompositeDto_SR.Noun_Singular),
        SingularArticle = nameof(AccountCompositeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(AccountCompositeDto_SR)
        )]
    public class AccountCompositeDto : AccountBaseDto
    {
        public AccountCompositeDto()
        {
            AccountMembers = new HashSet<AccountCompositeMemberDto>();
        }

        [Display(
            Name = nameof(AccountCompositeDto_SR.ShortCode_Name),
            Description = nameof(AccountCompositeDto_SR.ShortCode_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string ShortCode { get => base.ShortCode; set => base.ShortCode = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.StartDate_Name),
            Description = nameof(AccountCompositeDto_SR.StartDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        public override DateTime StartDate { get => base.StartDate; set => base.StartDate = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.CloseDate_Name),
            Description = nameof(AccountCompositeDto_SR.CloseDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        public override DateTime? CloseDate { get => base.CloseDate; set => base.CloseDate = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.Description_Name),
            Description = nameof(AccountCompositeDto_SR.Description_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string Description { get => base.Description; set => base.Description = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.DisplayName_Name),
            Description = nameof(AccountCompositeDto_SR.DisplayName_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string DisplayName { get => base.DisplayName; set => base.DisplayName = value; }

        public override string ObjectType { get; } = AccountObjectType.Composite.ConvertToStringCode();

        public ICollection<AccountCompositeMemberDto> AccountMembers { get; set; }
    }
}
