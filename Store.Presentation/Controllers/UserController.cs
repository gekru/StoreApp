using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ApplicationUser user)
        {
            await _userService.AddUserAsync(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
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
