using Pustok.Business.DTOs.CategoryDtos;
using Pustok.Business.DTOs.ProductDtos;

namespace Pustok.Business.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryGetResponseDto>().ReverseMap();

        CreateMap<Product, ProductGetResponseDto>().ForMember(p => p.Category, p => p.MapFrom(x => x.Category)).ReverseMap();
        CreateMap<ProductPostDto, Product>().ReverseMap();
        CreateMap<ProductPutDto, Product>().ReverseMap();

        CreateMap<CategoryPostDto, Category>().ReverseMap();
    }
}