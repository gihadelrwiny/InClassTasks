namespace WebApplication1.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development", p => p
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("Production", p => p
                    .WithOrigins(
                        "https://yourfrontend.com",
                        "https://admin.yourfrontend.com")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Authorization", "Content-Type")
                    .AllowCredentials());
            });

            return services;
        }
    }
}
