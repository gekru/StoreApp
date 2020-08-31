using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Providers.Interfaces;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEmailProvider _emailProvider;

        public AccountController(IAccountService accountService, IEmailProvider emailProvider)
        {
            _accountService = accountService;
            _emailProvider = emailProvider;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterAsync(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                await _accountService.RegisterUserAsync(user);

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
    }
}
