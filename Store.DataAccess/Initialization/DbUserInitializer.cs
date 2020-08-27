using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.Shared.Enums.User;

namespace Store.DataAccess.Initialization
{
    public static class DbUserInitializer
    {
        public static async void InitializeAdmin(UserManager<ApplicationUser> userManager, IConfiguration configuration)
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
            
            IdentityResult result = userManager.CreateAsync(admin, configuration["AdminData:Password"]).Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, UserRole.Admin.ToString()).GetAwaiter().GetResult();
            }
        }
    }
}
