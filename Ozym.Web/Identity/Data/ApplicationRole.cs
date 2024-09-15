using Ichosys.DataModel.Annotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ozym.Web.Identity.Data
{
    [Noun(
        Plural = nameof(ApplicationRole_SR.Noun_Plural),
        PluralArticle = nameof(ApplicationRole_SR.Noun_Plural_Article),
        Singular = nameof(ApplicationRole_SR.Noun_Singular),
        SingularArticle = nameof(ApplicationRole_SR.Noun_Singular_Article),
        ResourceType = typeof(ApplicationRole_SR)
        )]
    public class ApplicationRole : IdentityRole
    {
        /// <inheritdoc/>
        [Key]
        [Display(
            Name = nameof(ApplicationRole_SR.Id_Name),
            Description = nameof(ApplicationRole_SR.Id_Description),
            ResourceType = typeof(ApplicationRole_SR))]
        public override string Id { get; set; } = string.Empty;

        /// <inheritdoc/>
        [Display(
            Name = nameof(ApplicationRole_SR.Name_Name),
            Description = nameof(ApplicationRole_SR.Name_Description),
            ResourceType = typeof(ApplicationRole_SR))]
        public override string? Name { get; set; }

        /// <inheritdoc/>
        [Display(
            Name = nameof(ApplicationRole_SR.NormalizedName_Name),
            Description = nameof(ApplicationRole_SR.NormalizedName_Description),
            ResourceType = typeof(ApplicationRole_SR))]
        public override string? NormalizedName { get; set; }

        /// <inheritdoc/>
        public override string? ConcurrencyStamp { get; set; }
    }
}
