using DevSpot.Constants;
using Microsoft.AspNetCore.Identity;

namespace DevSpot.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (! await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.JobSeeker))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.JobSeeker));
            }

            if (!await roleManager.RoleExistsAsync(Roles.Employer))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Employer));//
            }
        }
    }
}
