using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Mapper
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductListDto, Product>().ReverseMap();
        }
    }
}