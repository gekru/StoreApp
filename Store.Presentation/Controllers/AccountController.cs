using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
                    controller: "Account",
                    values: new { email = user.Email, token = user.Token},
                    protocol: HttpContext.Request.Scheme);


                string mailSubject = "Confirm your account";
                string mailBody = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.";

                await _emailProvider.SendMailAsync(user.Email, mailSubject, mailBody);

                return Content("Check your mail");
            }
            return Ok(user);


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            await _accountService.ConfirmEmailAsync(email, token);
            return Ok();
        }

    }
}
