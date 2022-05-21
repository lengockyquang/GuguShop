using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class TagService: BaseEntityService<Tag, TagDto, TagListDto, TagCreateDto, TagUpdateDto>, ITagService
    {
        public TagService(IMapper mapper, ITagRepository tagRepository): base(mapper, tagRepository)
        {
        }
    }
}