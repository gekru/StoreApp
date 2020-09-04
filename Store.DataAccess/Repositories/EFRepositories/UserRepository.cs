using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : BaseEFRepository<ApplicationUser>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> _manager;

        public UserRepository(ApplicationContext context, UserManager<ApplicationUser> manager)
            : base(context)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync(PaginationDataFilter filter)
        {

            var skip = (filter.PageNumber - 1) * filter.PageSize;

            var users = await _entityDbSet.Skip(skip).Take(filter.PageSize).ToListAsync();
            return users;
        }
        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _manager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _manager.AddToRoleAsync(user, role);
        }
    }
}
