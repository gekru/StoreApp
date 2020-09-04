using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;

namespace Store.BusinessLogic.Providers
{
    public class MapperProvider : Profile
    {
        public MapperProvider()
        {
            CreateMap<ApplicationUser, UserModel>().ReverseMap();
            CreateMap<ApplicationUser, RegisterModel>().ReverseMap();
            CreateMap<PaginationFilter, PaginationDataFilter>().ReverseMap();
            CreateMap<UserFilter, UserDataFilter>().ReverseMap();
        }
    }
}
