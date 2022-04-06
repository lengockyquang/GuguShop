using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Interfaces
{
    public interface IManufacturerService: IBaseEntityService<Manufacturer, ManufacturerDto, ManufacturerListDto, ManufacturerCreateDto, ManufacturerUpdateDto>
    {
        
    }
}