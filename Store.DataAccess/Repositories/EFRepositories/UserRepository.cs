using Microsoft.AspNetCore.Identity;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
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
