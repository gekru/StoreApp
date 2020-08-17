using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(long userId);
        void AddUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(long userId);
    }
}
