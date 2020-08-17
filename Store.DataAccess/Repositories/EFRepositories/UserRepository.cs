using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUserById(long userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(ApplicationUser user)
        {
            _context.Users.Add(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(long userId)
        {
            ApplicationUser user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
