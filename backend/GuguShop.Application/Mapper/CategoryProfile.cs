using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Mapper
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}