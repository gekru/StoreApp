using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository
    {
        Task<IEnumerable<PrintingEdition>> GetFilteredPrintingEditionsAsync(PaginationDataFilter pageFilter,
            PrintingEditionDataFilter printingFilter);
    }
}
