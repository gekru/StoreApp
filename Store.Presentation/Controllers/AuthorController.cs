using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Authors;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilterModel pageFilter,
            [FromQuery] AuthorFilterModel authorFilter)
        {
            var result = await _authorService.GetAuthorsAsync(pageFilter, authorFilter);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _authorService.GetAuthorByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorModel authorModel)
        {
            await _authorService.CreateAuthorAsync(authorModel);
            return Ok(authorModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorModel authorModel)
        {
            try
            {
                await _authorService.UpdateAuthorAsync(authorModel);
                return Ok(authorModel);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _authorService.GetAuthorByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            await _authorService.DeleteAuthorAsync(id);
            return Ok(result);
        }
       
    }
}
