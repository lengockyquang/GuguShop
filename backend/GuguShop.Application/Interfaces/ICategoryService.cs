using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Interfaces
{
    public interface ICategoryService: IBaseEntityService<Category, CategoryDto, CategoryListDto, CategoryCreateDto, CategoryUpdateDto>
    {
        
    }
}