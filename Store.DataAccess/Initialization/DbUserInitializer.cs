using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.DataAccess.Initialization
{
    public static class DbUserInitializer
    {
        public static async Task InitializeAdmin(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            if (await userManager.FindByEmailAsync(configuration["AdminData:Email"]) is not null)
            {
                return;
            }

            var admin = new ApplicationUser
            {
                FirstName = "AdminFirstName",
                LastName = "AdminLastName",
                Email = configuration["AdminData:Email"],
                UserName = configuration["AdminData:Email"],
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(admin, configuration["AdminData:Password"]);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
            }
        }
    }
}
