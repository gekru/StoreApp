﻿using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.PrintingEditions;
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

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _printingService.GetPrintingEditionByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("CreatePrintingEdition")]
        public async Task<IActionResult> Create(PrintingEditionModel printingModel)
        {
            await _printingService.CreatePrintingEditionAsync(printingModel);
            return Ok(printingModel);
        }

        [HttpPost("UpdatePrintingEdition")]
        public async Task<IActionResult> Update(PrintingEditionModel printingModel)
        {
            var result = await _printingService.GetPrintingEditionByIdAsync(printingModel.Id);
            if (result is null)
            {
                return NotFound();
            }

            await _printingService.UpdatePrintingEditionAsync(printingModel);
            return Ok(printingModel);
        }

        [HttpDelete("DeletePrintingEdition")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _printingService.GetPrintingEditionByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            await _printingService.DeletePrintingEditionAsync(id);
            return Ok(result);
        }

    }
}
