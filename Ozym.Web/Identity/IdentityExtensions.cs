using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ozym.Web.Identity.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ozym.Web.Identity
{
    public static class IdentityExtensions
    {
        const string _superuserPasswordKey = "SUPERUSER_PASSWORD";
        const string _superuserNameKey = "SUPERUSER_NAME";
        const string _errorsKey = "Errors";
        
        /// <summary>
        /// Confirms if the superuser has been created and updates the database if not.
        /// </summary>
        /// <param name="userManager">The <see cref="UserManager{TUser}"> to sue.</param>
        /// <param name="configuration">The app <see cref="IConfiguration"/> instance..</param>
        /// <param name="logger">The logger.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task ConfirmSuperuserCreatedAsync(
            this UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger logger)
        {
            if (configuration.GetValue<string>(_superuserPasswordKey) is null)
                throw new InvalidOperationException(
                    $"Configuration key '{_superuserPasswordKey}' is required.");

            var superUsername = configuration.GetValue<string>(_superuserNameKey) ?? "SU";

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

            static async Task HandleOrThrowAsync(Task<IdentityResult> identityTask, string errorMessage)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
                    
                var result = await identityTask;
                if (!result.Succeeded)
                {
                    var exception = new InvalidOperationException(errorMessage);
                    exception.Data.Add(_errorsKey, result.Errors.Select(x => $"{x.Code}: {x.Description}"));
                    throw exception;
                }
            }

            try
            {
                // Add new user.
                await HandleOrThrowAsync(
                    userManager.CreateAsync(superuser, configuration[_superuserPasswordKey]!),
                    errorMessage: "Error creating default user.");

                logger?.LogInformation("Default user '{User}' created.", superuser.UserName);

                // Refresh the user instance.
                superuser = await userManager.FindByNameAsync(superuser.UserName);

                // Add new user to 'superuser' role.
                await HandleOrThrowAsync(
                    userManager.AddToRoleAsync(superuser!, "Superuser"),
                    errorMessage: "Error assigning user role");

                logger?.LogInformation("'{User}' added to role '{Role}'.", superuser!.UserName, "Superuser");
            }
            catch (InvalidOperationException ioe)
            {
                // If invalid operation was thrown, likely a password requirements issue. 
                // Log and re-throw.
                logger?.LogError(
                    "Error creating default user '{User}' with role '{Role}' .\n {Errors}",
                    superuser?.UserName,
                    "Superuser",
                    ioe.Data[_errorsKey]);
                throw;
            }

        }
    }
}
