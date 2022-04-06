using System;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class CategoryService: BaseEntityService<Category, CategoryDto, CategoryListDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepository baseRepository) : base(mapper, baseRepository)
        {
        }
    }
}