using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Token;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Providers.Interfaces;
using Store.BusinessLogic.Services.Interfaces;
using Store.Presentation.Providers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEmailProvider _emailProvider;
        private readonly IJwtProvider _jwtProvider;

        public AccountController(IAccountService accountService, IEmailProvider emailProvider, IJwtProvider jwtProvider)
        {
            _accountService = accountService;
            _emailProvider = emailProvider;
            _jwtProvider = jwtProvider;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterAsync(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUserAsync(user);

                if (result.Errors.Count > 0)
                {
                    return Ok(result.Errors);
                }

                var callbackUrl = Url.Action(
                    action: nameof(ConfirmEmail),
                    controller: nameof(AccountController).Replace("Controller", string.Empty),
                    values: new { email = user.Email, token = user.Token },
                    protocol: HttpContext.Request.Scheme);

                string mailSubject = "Confirm your account";
                string mailBody = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.";

                await _emailProvider.SendMailAsync(user.Email, mailSubject, mailBody);

                return Content("Check your mail");
            }
            return Ok(user);
        }

        [HttpGet("ConfirnEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            await _accountService.ConfirmEmailAsync(email, token);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var userModel = new UserModel()
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };

            var result = await _accountService.LoginAsync(userModel);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            userModel = await _accountService.FindByEmailAsync(userModel.Email);
            userModel.Roles = await _accountService.GetRolesAsync(userModel.Email) as List<string>;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.FirstName),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.LastName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userModel.Roles.FirstOrDefault())
            };

            var accessToken = _jwtProvider.GenerateAccessToken(claims);
            var refreshToekn = _jwtProvider.GenerateRefreshToken();

            var tokenModel = new JwtTokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToekn
            };

            return Ok(tokenModel);
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                await _accountService.ForgotPasswordAsync(model);

                var callbackUrl = Url.Action(
                    action: nameof(ResetPassword),
                    controller: nameof(AccountController).Replace("Controller", string.Empty),
                    values: new { email = model.Email, token = model.Token },
                    protocol: HttpContext.Request.Scheme);

                string mailSubject = "Reset Password";
                string mailBody = $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.";

                await _emailProvider.SendMailAsync(model.Email, mailSubject, mailBody);

                return Content("Check your mail");
            }
            return Ok(model);
        }

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword(string token = null)
        {
            _accountService.ResetPassword(token);
            return Ok();
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                await _accountService.ResetPasswordAsync(model);
            }
            return Ok();
        }

        [HttpPost("Logout")]
        public async Task Logout()
        {
            await _accountService.LogoutAsync();
        }
    }
}
