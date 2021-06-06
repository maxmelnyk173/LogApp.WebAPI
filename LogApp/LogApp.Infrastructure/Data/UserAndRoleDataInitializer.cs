using LogApp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LogApp.Infrastructure.Data
{
    public static class UserAndRoleDataInitializer
    {
        public async static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedUsers(userManager);
        }

        private async static Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("superadmin@prod.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "superadmin@prod.com",
                    FirstName = "Super",
                    LastName = "Admin",
                    Role = "SuperAdmin"
                };
                user.UserName = user.FirstName + user.LastName;

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, user.Role);
                }
            }
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                IdentityRole role = new IdentityRole { Name = "SuperAdmin" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Admin" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Logistic").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Logistic" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Inventory").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Inventory" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Customs").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Customs" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Security").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Security" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Planning").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Planning" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Other").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Other" };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
