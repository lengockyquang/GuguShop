using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class ManufacturerService: BaseEntityService<Manufacturer, ManufacturerDto, ManufacturerListDto, ManufacturerCreateDto, ManufacturerUpdateDto>,IManufacturerService
    {
        public ManufacturerService(IMapper mapper, IManufacturerRepository baseRepository) : base(mapper, baseRepository)
        {
        }
    }
}