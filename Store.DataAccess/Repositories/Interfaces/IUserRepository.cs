using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(int userId);
        void AddUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(int userId);
        void Save();
    }
}
