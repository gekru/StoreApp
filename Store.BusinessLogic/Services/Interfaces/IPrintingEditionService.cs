using Store.BusinessLogic.Filters;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<IEnumerable<PrintingEdition>> GetPrintingEditionsAsync(PaginationFilter pageFilter, PrintingEditionFilter printingFilter);
    }
}
