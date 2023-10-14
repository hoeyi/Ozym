using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ozym.Web.Areas.Identity.Data;

namespace Ozym.Web.Data
{
    /// <summary>
    /// <see cref="DbContext"/> child for working with <see cref="WebAppUser"/> records.
    /// </summary>
    public partial class IdentityDbContext : IdentityDbContext<WebAppUser>
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
