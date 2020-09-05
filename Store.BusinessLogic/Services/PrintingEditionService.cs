using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _repository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrintingEdition>> GetPrintingEditionsAsync(PaginationFilter pageFilter,
            PrintingEditionFilter printingFilter)
        {
            var mapperPageFilter = _mapper.Map<PaginationDataFilter>(pageFilter);
            var mappePrintingFilter = _mapper.Map<PrintingEditionDataFilter>(printingFilter);

            var result = await _repository.GetFilteredPrintingEditionsAsync(mapperPageFilter, mappePrintingFilter);

            return result;
        }

    }
}
