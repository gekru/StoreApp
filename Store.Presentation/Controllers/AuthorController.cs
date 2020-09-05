using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilter pageFilter,
            [FromQuery] AuthorFilter authorFilter)
        {
            var result = await _authorService.GetAuthorsAsync(pageFilter, authorFilter);
            return Ok(result);
        }
    }
}
