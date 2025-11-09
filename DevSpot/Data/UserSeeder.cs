using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using DevSpot.Constants;
using Microsoft.Identity.Client;

namespace DevSpot.Data
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await CreateUserWithRoles(userManager, "admin@email.com", "Admin1", "Admin123!", Roles.Admin);
            await CreateUserWithRoles(userManager, "jobseeker@email.com", "JobSeeker1", "JobSeeker123!", Roles.JobSeeker);
            await CreateUserWithRoles(userManager, "employer@email.com", "Employer1", "Employer123!", Roles.Employer);
        }

        private static async Task CreateUserWithRoles(
            UserManager<IdentityUser> userManager,
            string email,
            string userName,
            string password,
            string Role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    Email = email,
                    EmailConfirmed = true,
                    UserName = userName,
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    throw new Exception($"Failed creating user with email {user.Email}. " +
                                        $"Errors: {string.Join(",", result.Errors)}");
                }
            }
        }
    }
}
