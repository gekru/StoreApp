using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public ApplicationUser GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public void AddUser(ApplicationUser user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public void Save()
        {
            _userRepository.Save();
        }

    }
}
