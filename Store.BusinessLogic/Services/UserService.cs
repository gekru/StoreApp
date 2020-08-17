using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public ApplicationUser GetUserById(long userId)
        {
            return _userRepository.GetById(userId);
        }

        public void AddUser(ApplicationUser user)
        {
            _userRepository.Create(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(long userId)
        {
            _userRepository.Delete(userId);
        }

    }
}
