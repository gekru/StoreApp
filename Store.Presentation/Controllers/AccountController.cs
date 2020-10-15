using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Token;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Providers.Interfaces;
using Store.BusinessLogic.Services.Interfaces;
using Store.Presentation.Providers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUserAsync(user);

                if (result.Errors.Count > 0)
                {
                    return BadRequest(result.Errors);
                }

                var callbackUrl = Url.Action(
                    action: nameof(ConfirmEmail),
                    controller: nameof(AccountController).Replace("Controller", string.Empty),
                    values: new { email = user.Email, token = user.Token },
                    protocol: HttpContext.Request.Scheme);

                string mailSubject = "Confirm your account";
                string mailBody = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.";

                await _emailProvider.SendMailAsync(user.Email, mailSubject, mailBody);

                return Ok(user);
            }
            return Ok(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _accountService.ConfirmEmailAsync(email, token);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }
            return Redirect(result);
        }

        [HttpPost]
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

            var claims = _accountService.GetUserClaims(userModel);

            var accessToken = _jwtProvider.GenerateAccessToken(claims);
            var refreshToekn = _jwtProvider.GenerateRefreshToken();

            var tokenModel = new JwtTokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToekn
            };

            return Ok(tokenModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ForgotPasswordAsync(model);
                if (string.IsNullOrEmpty(result))
                {
                    return NotFound();
                }

                var callbackUrl = Url.Action(
                    action: nameof(ResetPassword),
                    controller: nameof(AccountController).Replace("Controller", string.Empty),
                    values: new { email = HttpUtility.UrlEncode(model.Email), token = HttpUtility.UrlEncode(model.Token) },
                    protocol: HttpContext.Request.Scheme);

                string mailSubject = "Reset Password";
                string mailBody = $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.";

                await _emailProvider.SendMailAsync(model.Email, mailSubject, mailBody);

                return Ok();
            }
            return Ok(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token = null)
        {
            var result = _accountService.ResetPassword(email, token);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }
            return Redirect(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (model.Email is null)
            {
                return BadRequest("Email cannot be null");
            }

            if (ModelState.IsValid)
            {
                var result = await _accountService.ResetPasswordAsync(model);
                
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task Logout()
        {
            await _accountService.LogoutAsync();
        }
    }
}
