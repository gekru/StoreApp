using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Authors;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> CreateAuthorAsync(AuthorModel authorModel);
        Task DeleteAuthorAsync(long authorId);
        Task<Author> GetAuthorByIdAsync(long authorId);
        Task<IEnumerable<Author>> GetAuthorsAsync(PaginationFilter pageFilter, AuthorFilter authorFilter);
        Task UpdateAuthorAsync(AuthorModel authorModel);
    }
}
