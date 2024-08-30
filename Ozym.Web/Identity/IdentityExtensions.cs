using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ozym.Web.Identity.Data;
using Serilog.Core;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ozym.Web.Identity
{
    public static class IdentityExtensions
    {
        const string _superuserPasswordKey = "SUPERUSER_PASSWORD";
        const string _superuserNameKey = "SUPERUSER_NAME";
        const string _errorsKey = "Errors";

        public static async Task ConfirmSuperuserCreatedAsync(
            this UserManager<ApplicationUser> userManager, IConfiguration configuration, ILogger logger = null)
        {
            var superUsername = configuration?.GetValue<string>(_superuserNameKey) ?? "SU";

            var superuser = await userManager.FindByNameAsync(superUsername);
            
            // If the superuser is created, the database is already updated.
            if (superuser is not null)
                return;

            // Implement a default superuser.
            superuser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = superUsername,
                Email = "su@example.com",
                EmailConfirmed = true,
                NormalizedUserName = "SU"
            };

            try
            {
                // Add new user.
                var result = await userManager.CreateAsync(superuser, configuration[_superuserPasswordKey]);
                if (!result.Succeeded)
                {
                    var exception = new InvalidOperationException("Failed to create user.");
                    exception.Data.Add(_errorsKey, result.Errors.Select(x => $"{x.Code}: {x.Description}"));
                    throw exception;
                }

                logger?.LogInformation("Default '{User}' created.", superuser.UserName);

                // Refresh the user instance.
                superuser = await userManager.FindByNameAsync(superuser.UserName);

                // Add new user to 'superuser' role.
                result = await userManager.AddToRoleAsync(superuser, "Superuser");
                if (!result.Succeeded)
                {
                    var exception = new InvalidOperationException("Failed to add user to role.");
                    exception.Data.Add(_errorsKey, result.Errors.Select(x => $"{x.Code}: {x.Description}"));
                    throw exception;
                }

                await userManager.UpdateAsync(superuser);

                logger?.LogInformation("{User} added to {Role}.", superuser.UserName, "Superuser");
            }
            catch (InvalidOperationException ioe)
            {
                // If invalid operation was thrown, likely a password requirements issue. 
                // Log and re-throw.
                logger?.LogError(
                    "Error creating default user '{User}' with role '{Role}' .\n {Errors}", 
                    superuser.UserName, 
                    "Superuser", 
                    ioe.Data[_errorsKey]);
                throw;
            }

        }
    }
}
