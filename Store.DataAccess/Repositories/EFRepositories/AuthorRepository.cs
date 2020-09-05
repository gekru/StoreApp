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
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetFilteredAuthorsAsync(PaginationDataFilter pageFilter,
            AuthorDataFilter authorFilter)
        {
            var authors = _entityDbSet.AsQueryable();

            if (authorFilter.PropertyName is not null)
            {
                authors = authors.OrderBy(authorFilter.PropertyName, authorFilter.SortType.ToString());
            }
            var skip = (pageFilter.PageNumber - 1) * pageFilter.PageSize;

            var result = await authors.Skip(skip).Take(pageFilter.PageSize).ToListAsync();

            return result;
        }
    }
}
