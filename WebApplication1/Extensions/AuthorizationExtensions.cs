namespace WebApplication1.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(
            this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanManageProducts", policy =>
                {
                    policy.RequireRole("Admin");
                });
            });

            return services;
        }
    }
}
