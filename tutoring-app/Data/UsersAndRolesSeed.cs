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
    /// <summary>
    /// Seeding the database with these default roles
    /// </summary>
    public static class UsersAndRolesSeed
    {
        public async static Task Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(userManager, roleManager);
            await SeedAdminAsync(userManager, roleManager);
            await SeedUsersAsync(userManager, roleManager);
        }

        private async static Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // seed roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Tutor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Student.ToString()));
        }

        private async static Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // seed admin user
            var defaultUser = new ApplicationUser
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "User",
                Address = null,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password1!");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Tutor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Student.ToString());
                }
            }
        }

        private async static Task SeedUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager.FindByEmailAsync("johndoe@localhost").Result == null)
            {
                Student user = new Student
                {
                    Email = "johndoe@localhost",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "222-222-222",
                    Grade = "Kindergarden",
                    Address = null,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "12345Aa!");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }

            if (userManager.FindByEmailAsync("alex@localhost").Result == null)
            {
                Tutor user = new Tutor
                {
                    Email = "alex@localhost",
                    FirstName = "Alex",
                    LastName = "Calingasan",
                    PhoneNumber = "111-111-1111",
                    Address = null,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                
                var result = await userManager.CreateAsync(user, "12345Aa!");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Tutor").Wait();
                }
            }
        }
    }
}
