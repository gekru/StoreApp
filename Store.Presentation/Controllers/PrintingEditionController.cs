using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintingEditionController : Controller
    {
        private readonly IPrintingEditionService _printingService;

        public PrintingEditionController(IPrintingEditionService printingService)
        {
            _printingService = printingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilter pageFilter,
            [FromQuery] PrintingEditionFilter filter)
        {
            var result = await _printingService.GetPrintingEditionsAsync(pageFilter, filter);
            return Ok(result);
        }

    }
}
