using LogApp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace LogApp.Infrastructure.Data
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("superadmin@prod.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = "superadmin@prod.com";
                user.FirstName = "Super";
                user.LastName = "Admin";
                user.UserName = user.FirstName + user.LastName;
                user.Role = "Admin";

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, user.Role).Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Logistic").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Logistic";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Inventory").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Inventory";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Customs").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customs";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Security").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Security";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Planning").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Planning";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Other").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Other";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
