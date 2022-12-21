using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuguShop.Application.Services
{
    public class ManufacturerService: BaseEntityService<Manufacturer, ManufacturerDto, ManufacturerListDto, ManufacturerCreateDto, ManufacturerUpdateDto>,IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        public ManufacturerService(IMapper mapper, IManufacturerRepository baseRepository) : base(mapper, baseRepository)
        {
            _manufacturerRepository = baseRepository;
        }

        public async Task<ICollection<ManufacturerComboDto>> GetComboDataAsync(CancellationToken cancellationToken = default)
        {
            var data = await _manufacturerRepository.GetWithSpecification();
            return data.Select(x => new ManufacturerComboDto()
            {
                Label = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
        }
    }
}