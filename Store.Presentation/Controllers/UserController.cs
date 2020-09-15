using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilterModel pageFilter, [FromQuery] UserFilterModel userFilter)
        {
            var result = await _userService.GetUsersAsync(pageFilter, userFilter);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            await _userService.AddUserAsync(user);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserModel user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> ChangeUserStatus(string email)
        {
            await _userService.ChangeUserStatusAsync(email);
            return Ok();
        }

    }
}
