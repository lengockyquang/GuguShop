using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuguShop.Application.Dto;

namespace GuguShop.Application.Interfaces
{
    public interface IManufacturerService
    {
        Task<ManufacturerDto> CreateManufacturer(ManufacturerCreateDto createDto);
        Task<ManufacturerDto> UpdateManufacturer(ManufacturerUpdateDto updateDto);
        Task<Guid> RemoveManufacturer(Guid id);
        Task<IEnumerable<ManufacturerListDto>> GetListManufacturer();
        Task<ManufacturerDto> GetManufacturer(Guid id);
    }
}