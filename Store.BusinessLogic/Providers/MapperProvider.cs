using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Authors;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;

namespace Store.BusinessLogic.Providers
{
    public class MapperProvider : Profile
    {
        public MapperProvider()
        {
            // Entities to models
            CreateMap<ApplicationUser, UserModel>().ReverseMap();
            CreateMap<ApplicationUser, RegisterModel>().ReverseMap();
            CreateMap<PrintingEdition, PrintingEditionModel>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            
            // Filters
            CreateMap<BaseDataFilter, BaseFilter>().ReverseMap();
            CreateMap<PaginationFilter, PaginationDataFilter>().ReverseMap();
            CreateMap<UserFilter, UserDataFilter>().ReverseMap();
            CreateMap<AuthorDataFilter, AuthorFilter>().ReverseMap();
            CreateMap<PrintingEditionDataFilter, PrintingEditionFilter>().ReverseMap();
        }
    }
}
