using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(long userId);
        Task AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(long userId);
    }
}
