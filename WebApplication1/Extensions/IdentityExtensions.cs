using Microsoft.AspNetCore.Identity;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityConfiguration(
            this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<jwtcontext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
