using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Interfaces
{
    public interface ITagService: IBaseEntityService<Tag, TagDto, TagListDto, TagCreateDto, TagUpdateDto>
    {
        
    }
}