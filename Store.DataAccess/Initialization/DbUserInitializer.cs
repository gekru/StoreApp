using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.Shared.Enums.User;

namespace Store.DataAccess.Initialization
{
    public static class DbUserInitializer
    {
        public static void InitializeAdmin(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            if (userManager.FindByEmailAsync(configuration["AdminData:Email"]) is null)
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

            var result = userManager.CreateAsync(admin, configuration["AdminData:Password"]).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
            }
        }
    }
}
