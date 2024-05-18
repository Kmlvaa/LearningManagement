using LearningManagement.Entities;
using Microsoft.AspNetCore.Identity;

namespace LearningManagement.Helper
{
    public static class DataSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = ["Admin"];

                foreach (var role in roles)
                {
                    var exists = await roleManager.RoleExistsAsync(role);
                    if (exists) continue;
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                var user = new AppUser()
                {
                    Firstname = "Samira",
                    Lastname = "Kamilova",
                    UserName = "Kmlvaa",
                    Email = "admin@gmail.com"
                };

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser != null) return;

                await userManager.CreateAsync(user, "admin123");
                await userManager.AddToRolesAsync(user, roles);

                return;
            }
        }
    }
}
