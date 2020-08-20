using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(long userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task AddUserAsync(ApplicationUser user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(long userId)
        {
           await _userRepository.DeleteAsync(userId);
        }

    }
}
