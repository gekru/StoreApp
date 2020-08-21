using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Users;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAsync()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet("GetById/{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost("CreateUser", Name = "CreateNewUser")]
        public async Task<IActionResult> PostAsync(UserModel user)
        {
            await _userService.AddUserAsync(user);

            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteAync(long id)
        {
            var currentUser = await GetUserByIdAsync(id);

            if (currentUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);

            return Ok(currentUser);
        }

    }
}
