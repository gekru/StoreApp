using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<RegisterModel> RegisterUserAsync(RegisterModel user)
        {
            var mapperUser = _mapper.Map<ApplicationUser>(user);
            mapperUser.UserName = mapperUser.Email;

            var result = await _userManager.CreateAsync(mapperUser, user.Password);

            if (!result.Succeeded)
            {
                int errorCount = 1;
                result.Errors.ToList().ForEach(item =>
                {
                    user.Errors.Add($"Error {errorCount++} - {item.Description}");
                });
                return user;
            }

            await AddToRoleAsync(mapperUser, UserRole.Client.ToString());

            user.Token = await _userManager.GenerateEmailConfirmationTokenAsync(mapperUser);

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

        public async Task<string> ForgotPasswordAsync(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return null;
            }

            model.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return model.Token;
        }

        public string ResetPassword(string email, string token)
        {
            var model = new ResetPasswordModel { Token = token };
            // Getting section from appsetings.json
            var clientSidePath = _configuration.GetSection("ClientSide");
            string userData = $"?email={email}&token={model.Token}";

            string redirectPath = clientSidePath["Url"] + clientSidePath["ResetPasswordPath"] + userData;

            return redirectPath;
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return IdentityResult.Failed();
            }

            return await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        }

        public async Task<string> ConfirmEmailAsync(string email, string token)
        {
            if (email is null)
            {
                return null;
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return null;
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return null;
            }

            // Getting section from appsetings.json
            var clientSidePath = _configuration.GetSection("ClientSide");
            string userData = $"?firstName={user.FirstName}&lastName={user.LastName}";

            string redirectPath = clientSidePath["Url"] + clientSidePath["ConfirmedMailPath"] + userData;

            return redirectPath;
        }

        public List<Claim> GetUserClaims(UserModel userModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.FirstName),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.LastName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userModel.Roles.FirstOrDefault())
            };

            return claims;
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
