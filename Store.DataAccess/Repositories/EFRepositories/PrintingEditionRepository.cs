using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Extensions;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<PrintingEdition>> GetFilteredPrintingEditionsAsync(PaginationDataFilter pageFilter,
            PrintingEditionDataFilter printingFilter)
        {
            var printingEditions = _entityDbSet.AsQueryable();

            if (printingFilter.PropertyName is not null)
            {
                printingEditions = printingEditions.OrderBy(printingFilter.PropertyName, printingFilter.SortType.ToString());
            }
            var skip = (pageFilter.PageNumber - 1) * pageFilter.PageSize;

            var result = await printingEditions.Skip(skip).Take(pageFilter.PageSize).ToListAsync();

            return result;
        }
    }
}
