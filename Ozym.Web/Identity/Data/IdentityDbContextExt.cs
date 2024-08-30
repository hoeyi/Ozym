using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ozym.Web.Identity.Data;

namespace Ozym.Web.Identity.Data
{
    /// <summary>
    /// <see cref="DbContext"/> child for working with <see cref="ApplicationUser"/> records.
    /// </summary>
    public partial class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("OzymIdentity");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.HasDefaultSchema("WebId");

            // Add built-in rules.
            var roles = new IdentityRole[]
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Superuser",
                    NormalizedName = "SUPERUSER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Datareader",
                    NormalizedName = "DATAREADER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Datawriter",
                    NormalizedName = "DATAWRITER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
