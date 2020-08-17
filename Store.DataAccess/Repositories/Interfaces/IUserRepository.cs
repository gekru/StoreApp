using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    }
}
