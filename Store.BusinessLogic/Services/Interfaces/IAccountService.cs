using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Account;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task ConfirmEmailAsync(string email, string token);
        Task ForgotPasswordAsync(ForgotPasswordModel model);
        Task<RegisterModel> RegisterUserAsync(RegisterModel user);
        ResetPasswordModel ResetPassword(string token);
        Task ResetPasswordAsync(ResetPasswordModel model);
    }
}
