using System;
using System.Threading.Tasks;
using GuguShop.Domain.Ums;
using GuguShop.Infrastructure.Data;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GuguShop.Infrastructure.Extensions;

public static class SetupAuthenticationExtensions
{
    public static IServiceCollection SetupAuthentication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddAuthentication();
        serviceCollection.AddScoped<IAuthUser, AuthUser>();
        serviceCollection.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<GuguDbContext>();
        var expiredTime = TimeSpan.FromDays(1);

        serviceCollection.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = expiredTime;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });
        serviceCollection.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.Name = "GuguCookie";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = expiredTime;

            options.LoginPath = "/api/login";
            options.SlidingExpiration = true;
            options.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = redirectContext =>
                {
                    redirectContext.HttpContext.Response.StatusCode = 401;
                    return Task.CompletedTask;
                }
            };
        });
        return serviceCollection;
    }
}