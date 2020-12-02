using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tutoring_app.Data;
using tutoring_app.Models;

namespace tutoring_app.Data
{
    public static class RolesSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // seed roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Tutor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Student.ToString()));
        }
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // seed admin user
            var defaultUser = new ApplicationUser
            {
                Email = "admin@user.com",
                FirstName = "Admin",
                LastName = "User",
                Address = null,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password1!.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Tutor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Student.ToString());
                }

            }
        }
    }
}
