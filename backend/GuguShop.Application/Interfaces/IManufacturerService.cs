using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GuguShop.Application.Interfaces
{
    public interface IManufacturerService: IBaseEntityService<Manufacturer, ManufacturerDto, ManufacturerListDto, ManufacturerCreateDto, ManufacturerUpdateDto>
    {
        Task<ICollection<ManufacturerComboDto>> GetComboDataAsync(CancellationToken cancellationToken = default);

    }
}