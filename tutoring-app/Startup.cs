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
using tutoring_app.Models;
using tutoring_app.Areas.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
            // services.AddMvc();

            // duplicated code in Areas/Identity/IdentityHostingStartup.cs
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                /*
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>
                .AddSignInManager<ApplicationSignInManager>()
                */
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("readpolicy",
                    builder => builder.RequireRole("Admin", "Tutor", "Student"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("Admin"));
            });

            // CreateRolesAndUsers(services.BuildServiceProvider());
            // CreateRolesAndUsers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IServiceProvider serviceProvider)
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
    }
}
        
        /*private async void CreateRolesAndUsers(*//*IServiceProvider serviceProvider*//*)
        {
            // var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            ApplicationDbContext context = new ApplicationDbContext(null);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new ApplicationUserStore(context));

            bool roleExists = await roleManager.RoleExistsAsync("Admin");

            // creating Admin role
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(role);

                // creating admin superuser
                var user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                };
                
                string userPassword = "Password1!";
                var result = await userManager.CreateAsync(user, userPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            roleExists = await roleManager.RoleExistsAsync("Tutor");

            // creating Tutor role
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = "Tutor"
                };
                await roleManager.CreateAsync(role);
            }

            roleExists = await roleManager.RoleExistsAsync("Student");

            // creating Student role
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = "Student"
                };
                await roleManager.CreateAsync(role);
            }
        }
    }*/
