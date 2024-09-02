using Ichosys.DataModel.Annotations;
using Microsoft.AspNetCore.Identity;
using Ozym.DataTransfer.Common;
using System.ComponentModel.DataAnnotations;

namespace Ozym.Web.Identity.Data;

[Noun(
        Plural = nameof(ApplicationUser_SR.Noun_Plural),
        PluralArticle = nameof(ApplicationUser_SR.Noun_Plural_Article),
        Singular = nameof(ApplicationUser_SR.Noun_Singular),
        SingularArticle = nameof(ApplicationUser_SR.Noun_Singular_Article),
        ResourceType = typeof(ApplicationUser_SR)
        )]
public class ApplicationUser : IdentityUser
{
    [Key]
    [Display(
            Name = nameof(ApplicationUser_SR.Id_Name),
            Description = nameof(ApplicationUser_SR.Id_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string Id { get; set; } = string.Empty;

    /// <inheritdoc/>
    [ProtectedPersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.UserName_Name),
            Description = nameof(ApplicationUser_SR.UserName_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    [Required]
    public override string? UserName { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.NormalizedUserName_Name),
            Description = nameof(ApplicationUser_SR.NormalizedUserName_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? NormalizedUserName { get; set; }

    /// <inheritdoc/>
    [ProtectedPersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.Email_Name),
            Description = nameof(ApplicationUser_SR.Email_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? Email { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.NormalizedEmail_Name),
            Description = nameof(ApplicationUser_SR.NormalizedEmail_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? NormalizedEmail { get; set; }

    /// <inheritdoc/>
    [PersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.EmailConfirmed_Name),
            Description = nameof(ApplicationUser_SR.EmailConfirmed_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override bool EmailConfirmed { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.PasswordHash_Name),
            Description = nameof(ApplicationUser_SR.PasswordHash_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? PasswordHash { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.SecurityStamp_Name),
            Description = nameof(ApplicationUser_SR.SecurityStamp_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? SecurityStamp { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.ConcurrencyStamp_Name),
            Description = nameof(ApplicationUser_SR.ConcurrencyStamp_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    /// <inheritdoc/>
    [ProtectedPersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.PhoneNumber_Name),
            Description = nameof(ApplicationUser_SR.PhoneNumber_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override string? PhoneNumber { get; set; }

    /// <inheritdoc/>
    [PersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.PhoneNumberConfirmed_Name),
            Description = nameof(ApplicationUser_SR.PhoneNumberConfirmed_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override bool PhoneNumberConfirmed { get; set; }

    /// <inheritdoc/>
    [PersonalData]
    [Display(
            Name = nameof(ApplicationUser_SR.TwoFactorEnabled_Name),
            Description = nameof(ApplicationUser_SR.TwoFactorEnabled_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override bool TwoFactorEnabled { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.LockoutEnd_Name),
            Description = nameof(ApplicationUser_SR.LockoutEnd_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override DateTimeOffset? LockoutEnd { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.LockoutEnabled_Name),
            Description = nameof(ApplicationUser_SR.LockoutEnabled_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override bool LockoutEnabled { get; set; }

    /// <inheritdoc/>
    [Display(
            Name = nameof(ApplicationUser_SR.AccessFailedCount_Name),
            Description = nameof(ApplicationUser_SR.AccessFailedCount_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public override int AccessFailedCount { get; set; }
}

