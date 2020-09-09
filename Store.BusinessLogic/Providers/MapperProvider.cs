using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Authors;
using Store.BusinessLogic.Models.Orders;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Linq;

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
            CreateMap<Author, AuthorModel>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.Name.Split().FirstOrDefault()))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.Name.Split().LastOrDefault()))
                .ReverseMap()
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => string.Join(" ", src.FirstName, src.LastName)));
            CreateMap<Order, OrderModel>().ReverseMap();

            // Filters
            CreateMap<BaseDataFilterModel, BaseFilterModel>().ReverseMap();
            CreateMap<PaginationFilterModel, PaginationDataFilterModel>().ReverseMap();
            CreateMap<UserFilterModel, UserDataFilterModel>().ReverseMap();
            CreateMap<AuthorDataFilterModel, AuthorFilterModel>().ReverseMap();
            CreateMap<PrintingEditionDataFilterModel, PrintingEditionFilterModel>().ReverseMap();
            CreateMap<OrderDataFilterModel, OrderFilterModel>().ReverseMap();
        }
    }
}
