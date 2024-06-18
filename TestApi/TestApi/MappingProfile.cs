using AutoMapper;
using TestApi.DTO;
using TestApi.Models;

namespace TestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
