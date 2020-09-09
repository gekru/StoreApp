using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IRepository<PrintingEdition>
    {
        Task<IEnumerable<PrintingEdition>> GetFilteredPrintingEditionsAsync(PaginationDataFilterModel pageFilter,
            PrintingEditionDataFilterModel printingFilter);
    }
}
