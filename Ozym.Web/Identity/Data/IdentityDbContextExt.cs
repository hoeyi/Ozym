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
    }
}
