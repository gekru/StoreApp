using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("users/")]
    public class UserController : Controller
    {
        
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = _userService.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(ApplicationUser user)
        {
            _userService.AddUser(user);

            return Ok(user);
        }

    }
}
