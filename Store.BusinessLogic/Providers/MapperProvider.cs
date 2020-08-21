using AutoMapper;
using Store.BusinessLogic.Models.Users;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Providers
{
    public class MapperProvider : Profile
    {
        
        public MapperProvider()
        {
            CreateMap<ApplicationUser, UserModel>().ReverseMap();
        }
    }
}
