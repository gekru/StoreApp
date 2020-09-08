using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<RegisterModel> RegisterUserAsync(RegisterModel user)
        {
            var mapperUser = _mapper.Map<ApplicationUser>(user);
            mapperUser.UserName = mapperUser.Email;

            var result = await _userManager.CreateAsync(mapperUser, user.Password);

            if (result.Succeeded)
            {
                await AddToRoleAsync(mapperUser, UserRole.Client.ToString());

                user.Token = await _userManager.GenerateEmailConfirmationTokenAsync(mapperUser);
            }
            else
            {
                int errorCount = 1;
                result.Errors.ToList().ForEach(item =>
                {
                    user.Errors.Add($"Error {errorCount++} - {item.Description}");
                });
                return user;
            }
            return user;
        }

        public async Task<SignInResult> LoginAsync(UserModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email);

            if (user is null)
            {
                return SignInResult.Failed;
            }

            if (user.IsActive is false)
            {
                return SignInResult.NotAllowed;
            }

            return await _signInManager.PasswordSignInAsync(user, userModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);
        }

        public async Task ForgotPasswordAsync(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return;
            }

            model.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public ResetPasswordModel ResetPassword(string token)
        {
            var model = new ResetPasswordModel { Token = token };
            return model;
        }

        public async Task ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return;
            }

            await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        }

        public async Task ConfirmEmailAsync(string email, string token)
        {
            if (email is null)
            {
                return;
            }
            var user = await _userManager.FindByEmailAsync(email);

            await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<UserModel> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return null;
            }
            var mapperUser = _mapper.Map<UserModel>(user);

            return mapperUser;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }


        public async Task<IList<string>> GetRolesAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return null;
            }
            return await _userManager.GetRolesAsync(user);

        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
