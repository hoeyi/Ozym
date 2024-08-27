using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ozym.Web.Components.Identity
{
    /// <summary>
    /// Extension methods overriding the default behavior of 
    /// </summary>
    public static class IdentityComponentsEndpointRouteBuilderOverrides
    {
        /// <summary>
        /// Registers authentication and supporting services with modified cookie options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddCustomIdentityCookies(o => { });

            return services;
        }

        /// <summary>
        /// Adds cookie authentication with custom route '/User'. Overrides behavior of 
        /// <see cref=""/>
        /// </summary>
        /// <param name="builder">The <see cref="AuthenticationBuilder"/> instance.</param>
        /// <param name="configureCookies">The action to configure the identity cookies.</param>
        /// <returns>The <see cref="IdentityCookiesBuilder"/> instance.</returns>
        public static IdentityCookiesBuilder AddCustomIdentityCookies(
            this AuthenticationBuilder builder, Action<IdentityCookiesBuilder> configureCookies)
        {
            var cookieBuilder = new IdentityCookiesBuilder
            {
                ApplicationCookie = builder.AddCustomApplicationCookie(),
                ExternalCookie = builder.AddExternalCookie(),
                TwoFactorRememberMeCookie = builder.AddTwoFactorRememberMeCookie(),
                TwoFactorUserIdCookie = builder.AddTwoFactorUserIdCookie()
            };
            configureCookies?.Invoke(cookieBuilder);

            return cookieBuilder;
        }

        /// <summary>
        /// Adds identity cookie with custom route '/User'.
        /// </summary>
        /// <param name="builder">The <see cref="AuthenticationBuilder"/> instance.</param>
        /// <returns>The <see cref="OptionsBuilder{CookieAuthenticationOptions}"/> instance.</returns>
        private static OptionsBuilder<CookieAuthenticationOptions> AddCustomApplicationCookie(
            this AuthenticationBuilder builder)
        {
            builder.AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/User/Logout";
                options.AccessDeniedPath = "/User/AccessDenied";
                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
                };
            });

            return new OptionsBuilder<CookieAuthenticationOptions>(builder.Services, IdentityConstants.ApplicationScheme);
        }
    }
}
