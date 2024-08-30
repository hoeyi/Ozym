using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ozym.Web.Identity.Data;
using System.Threading.Tasks;

namespace Ozym.Web.Identity
{
    public static class IdentityExtensions
    {
        public static async Task ConfirmSuperuserCreatedAsync(
            this UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            var superuser = await userManager.FindByNameAsync("su");
            
            // If the superuser is created, the database is already updated.
            if (superuser is not null)
                return;

            // Implement a default superuser.
            superuser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "su",
                Email = "su@example.com",
                EmailConfirmed = true,
                NormalizedUserName = "SU"
            };

            // Add new user and their role
            await userManager.CreateAsync(superuser, configuration["SUPERUSER_PASSWORD"]);
            superuser = await userManager.FindByNameAsync("su");
            await userManager.AddToRoleAsync(superuser, "Superuser");
        }
    }
}
