using LogApp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LogApp.Infrastructure.Data
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRolesAsync(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
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
                   userManager.AddToRoleAsync(user, user.Role).Wait();
                }
            }
        }

        private static void SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                IdentityRole role = new IdentityRole { Name = "SuperAdmin" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Admin" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Logistic").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Logistic" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Inventory").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Inventory" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Customs").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Customs" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Security").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Security" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Planning").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Planning" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Other").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Other" };
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
