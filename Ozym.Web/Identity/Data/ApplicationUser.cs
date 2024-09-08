using Ichosys.DataModel.Annotations;
using Microsoft.AspNetCore.Identity;
using Ozym.DataTransfer.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Ozym.Web.Identity.Data;

/// <summary>
/// Implementation of the <see cref="IdentityUser"/> base class for the application.
/// </summary>
[Noun(
        Plural = nameof(ApplicationUser_SR.Noun_Plural),
        PluralArticle = nameof(ApplicationUser_SR.Noun_Plural_Article),
        Singular = nameof(ApplicationUser_SR.Noun_Singular),
        SingularArticle = nameof(ApplicationUser_SR.Noun_Singular_Article),
        ResourceType = typeof(ApplicationUser_SR)
        )]
public partial class ApplicationUser : IdentityUser
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

#region Un-mapped properties and methods
public partial class ApplicationUser
{
    private static readonly HashSet<ApplicationRole> _roles = new(new ApplicationRoleComparer());

    /// <summary>
    /// Gets the collection of roles assigned to this user. Default is an empty collection.
    /// </summary>
    [NotMapped]
    [Display(
            Name = nameof(ApplicationUser_SR.Roles_Name),
            Description = nameof(ApplicationUser_SR.Roles_Description),
            ResourceType = typeof(ApplicationUser_SR))]
    public ICollection<ApplicationRole> Roles
    {
        get { return _roles;  }
    }


    /// <summary>
    /// Sets the roles assigned to this user.
    /// </summary>
    /// <param name="roles">The roles to assign.</param>
    public void SetRoles(IEnumerable<ApplicationRole> roles)
    {
        _roles.Clear();
        foreach (var role in roles)
            _roles.Add(role);
    }

    /// <summary>
    /// Implements <see cref="IEqualityComparer{T}"/> for the <see cref="ApplicationRole"/> class.
    /// </summary>
    internal sealed class ApplicationRoleComparer : IEqualityComparer<ApplicationRole>
    {
        /// <inheritdoc/>
        public bool Equals(ApplicationRole? x, ApplicationRole? y)
        {
            if(x is null || y is null || x.Name is null || y.Name is null)
                return false;

            return x.Name.Equals(y.Name);
        }

        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] ApplicationRole obj)
        {
            return obj.Name!.GetHashCode();
        }
    }
}
#endregion