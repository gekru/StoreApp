using Store.BusinessLogic.Filters;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(PaginationFilter pageFilter, AuthorFilter authorFilter);
    }
}
