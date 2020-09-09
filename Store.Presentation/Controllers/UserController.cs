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
    [Route("users")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilterModel pageFilter, [FromQuery] UserFilterModel userFilter)
        {
            var result = await _userService.GetUsersAsync(pageFilter, userFilter);
            return Ok(result);
        }

        [HttpGet("GetById/{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("CreateUser", Name = "CreateNewUser")]
        public async Task<IActionResult> PostAsync(UserModel user)
        {
            await _userService.AddUserAsync(user);

            return Ok(user);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateAsync(UserModel user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteAync(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);

            return Ok(result);
        }

        [HttpPost("ChangeUserStatus")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> ChangeUserStatus(string email)
        {
            await _userService.ChangeUserStatusAsync(email);
            return Ok();
        }

    }
}
