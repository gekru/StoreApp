using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync(PaginationDataFilterModel pageFilter, UserDataFilterModel userFilter);
    }
}
