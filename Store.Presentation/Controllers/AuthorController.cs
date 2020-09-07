using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Authors;
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

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _authorService.GetAuthorByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> Create(AuthorModel authorModel)
        {
            await _authorService.CreateAuthorAsync(authorModel);
            return Ok(authorModel);
        }

        [HttpPost("UpdateAuthor")]
        public async Task<IActionResult> Update(AuthorModel authorModel)
        {
            var result = await _authorService.GetAuthorByIdAsync(authorModel.Id);
            if (result is null)
            {
                return NotFound();
            }
            await _authorService.UpdateAuthorAsync(authorModel);
            return Ok(authorModel);
        }

        [HttpDelete("DeleteAuthor")]
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
