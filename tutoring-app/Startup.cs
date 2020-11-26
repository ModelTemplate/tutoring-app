using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using tutoring_app.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace tutoring_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            // duplicated code in Areas/Identity/IdentityHostingStartup.cs
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("readpolicy",
                    builder => builder.RequireRole("Admin", "Tutor", "Student"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("Admin"));
            });

            CreateRolesAndUsers(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private async void CreateRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            bool roleExists = await roleManager.RoleExistsAsync("Admin");

            // creating Admin role
            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                // creating admin superuser
                var user = new IdentityUser();
                user.Email = "admin@admin.com";
                string userPassword = "password";
                IdentityResult checkUser = await userManager.CreateAsync(user, userPassword);

                if (checkUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            roleExists = await roleManager.RoleExistsAsync("Tutor");

            // creating Tutor role
            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "Tutor";
                await roleManager.CreateAsync(role);
            }

            roleExists = await roleManager.RoleExistsAsync("Student");

            // creating Student role
            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "Student";
                await roleManager.CreateAsync(role);
            }
        }
    }
}
