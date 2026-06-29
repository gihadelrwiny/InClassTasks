using AutoMapper;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Shared.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
              
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.InStock,
            opt => opt.MapFrom(src => src.Stock > 0));

        }
    }
}
