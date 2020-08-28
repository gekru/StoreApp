using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Providers.Interfaces;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.Shared.Enums.User;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailProvider _emailProvider;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper, IEmailProvider emailProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailProvider = emailProvider;
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

        public async Task ConfirmEmailAsync(string email, string token)
        {
            if (email is null)
            {
                return;
            }
            var user = await _userManager.FindByEmailAsync(email);
            var mapperUser = _mapper.Map<ApplicationUser>(user);

            var result = await _userManager.ConfirmEmailAsync(mapperUser, token);

            if (result.Succeeded)
            {

            }
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
    }
}
