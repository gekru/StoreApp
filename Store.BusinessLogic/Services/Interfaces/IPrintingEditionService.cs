using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<PrintingEdition> CreatePrintingEditionAsync(PrintingEditionModel printingModel);
        Task DeletePrintingEditionAsync(long printinId);
        Task<PrintingEdition> GetPrintingEditionByIdAsync(long printingId);
        Task<IEnumerable<PrintingEdition>> GetPrintingEditionsAsync(PaginationFilter pageFilter, PrintingEditionFilter printingFilter);
        Task UpdatePrintingEditionAsync(PrintingEditionModel printingModel);
    }
}
