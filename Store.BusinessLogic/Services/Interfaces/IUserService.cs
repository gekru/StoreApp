using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync(PaginationFilter pageFilter, UserFilter userFilter);
        Task<ApplicationUser> GetUserByIdAsync(long userId);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(long userId);
        Task ChangeUserStatusAsync(string email);
    }
}
