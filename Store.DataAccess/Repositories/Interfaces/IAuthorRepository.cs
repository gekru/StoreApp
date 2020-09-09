using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetFilteredAuthorsAsync(PaginationDataFilterModel pageFilter, AuthorDataFilterModel authorFilter);
    }
}
