using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task ConfirmEmailAsync(string email, string token);
        Task<UserModel> FindByEmailAsync(string email);
        Task ForgotPasswordAsync(ForgotPasswordModel model);
        Task<IList<string>> GetRolesAsync(string email);
        List<Claim> GetUserClaims(UserModel userModel);
        Task<SignInResult> LoginAsync(UserModel userModel);
        Task LogoutAsync();
        Task<RegisterModel> RegisterUserAsync(RegisterModel user);
        ResetPasswordModel ResetPassword(string token);
        Task ResetPasswordAsync(ResetPasswordModel model);
    }
}
