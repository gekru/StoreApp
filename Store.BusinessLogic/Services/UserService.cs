﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using Store.Shared.Enums.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(long userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task AddUserAsync(UserModel user)
        {

            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(user));

            if (result.Succeeded)
            {
                await AddToRoleAsync(user, UserRole.Client.ToString());
            }
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var currentUser = await _userManager.FindByEmailAsync(user.Email);

            if (currentUser is null)
            {
                user.Errors.Add("User not found");
                return user;
            }

            if (user.FirstName is not null)
            {
                currentUser.FirstName = user.FirstName;
            }

            if (user.LastName is not null)
            {
                currentUser.LastName = user.LastName;
            }

            var result = await _userManager.UpdateAsync(currentUser);

            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(item =>
                {
                    user.Errors.Add($"{item}");
                });
                return user;
            }

            return user;
        }

        public async Task DeleteUserAsync(long userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<IList<string>> GetRolesAsync(UserModel user)
        {
            return await _userManager.GetRolesAsync(_mapper.Map<ApplicationUser>(user));
        }

        public async Task<IdentityResult> AddToRoleAsync(UserModel user, string role)
        {
            return await _userManager.AddToRoleAsync(_mapper.Map<ApplicationUser>(user), role);
        }

    }
}
