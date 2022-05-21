using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Mapper
{
    public class TagProfile: Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<Tag, TagListDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagUpdateDto, Tag>();
        }
    }
}