namespace Ecommerce.Web.Infrastructure.Extensions
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    
    using Data;
    using Ecommerce.Web.Models;
    using Ecommerce.Data.EntityModels;

    public static class ApplicationBuilderExtensions
    {
        private const string AdminUsername = " ";
        private const string AdminEmail = " ";
        private const string AdminPassword = " ";

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EcommerceDbContext>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                Task
                    .Run(async () =>
                    {
                        var roles = new[]
                        {
                            "Admin", "Dealer", "Seller"
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminUser = await userManager.FindByEmailAsync(AdminEmail);

                        if (adminUser == null)
                        {                           
                            adminUser = new User
                            {
                                Name = "",
                                UserName = AdminUsername, 
                                Email = AdminEmail
                            };

                            var result = await userManager.CreateAsync(adminUser, AdminPassword);

                            // Add User to Role
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(adminUser, "Admin");
                            }
                        }
                        else
                        {
                            // Add User to Role
                            await userManager.AddToRoleAsync(adminUser, "Admin");
                        }
                    }).GetAwaiter().GetResult();
            }
            return app;
        }
    }
}
