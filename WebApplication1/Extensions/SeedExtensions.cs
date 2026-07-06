using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Extensions
{
    public static class SeedExtensions
    {
        public static async Task SeedRolesAndAdminAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = await userManager.FindByEmailAsync("admin@gmail.com");

            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                await userManager.CreateAsync(admin, "Admin123@");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
