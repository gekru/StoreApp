using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Authors;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync(PaginationFilter pageFilter,
           AuthorFilter authorFilter)
        {
            var mapperPageFilter = _mapper.Map<PaginationDataFilter>(pageFilter);
            var mappeAuthorFilter = _mapper.Map<AuthorDataFilter>(authorFilter);

            var result = await _repository.GetFilteredAuthorsAsync(mapperPageFilter, mappeAuthorFilter);

            return result;
        }

        public async Task<Author> GetAuthorByIdAsync(long authorId)
        {
            return await _repository.GetByIdAsync(authorId);
        }

        public async Task<Author> CreateAuthorAsync(AuthorModel authorModel)
        {
            var mapperAuthor = _mapper.Map<Author>(authorModel);
            return await _repository.CreateAsync(mapperAuthor);
        }

        public async Task DeleteAuthorAsync(long authorId)
        {
            await _repository.DeleteAsync(authorId);
        }

        public async Task UpdateAuthorAsync(AuthorModel authorModel)
        {
            var mapperAuthor = _mapper.Map<Author>(authorModel);
            await _repository.UpdateAsync(mapperAuthor);
        }

    }
}
