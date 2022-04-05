using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class ManufacturerService: IManufacturerService
    {
        private readonly IMapper _mapper;
        private readonly IManufacturerRepository _manufacturerRepository;
        public ManufacturerService(IMapper mapper, IManufacturerRepository manufacturerRepository)
        {
            _mapper = mapper;
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task<ManufacturerDto> CreateManufacturer(ManufacturerCreateDto createDto)
        {
            var createEntity = _mapper.Map<ManufacturerCreateDto, Manufacturer>(createDto);
            var entity = await _manufacturerRepository.Create(createEntity, true);
            return _mapper.Map<Manufacturer, ManufacturerDto>(entity);
        }

        public async Task<ManufacturerDto> UpdateManufacturer(ManufacturerUpdateDto updateDto)
        {
            var updateEntity = _mapper.Map<ManufacturerUpdateDto, Manufacturer>(updateDto);
            var entity = await _manufacturerRepository.Create(updateEntity, true);
            return _mapper.Map<Manufacturer, ManufacturerDto>(entity);        }

        public async Task<Guid> RemoveManufacturer(Guid id)
        {
            var entity = await _manufacturerRepository.Get(id);
            if (entity == null)
            {
                throw new Exception("Không tìm thấy entity với id " + id);
            }

            await _manufacturerRepository.Delete(entity, true);
            return entity.Id;        
        }

        public async Task<IEnumerable<ManufacturerListDto>> GetListManufacturer()
        {
            var entities = await _manufacturerRepository.GetWithSpecification();
            return _mapper.Map<ICollection<Manufacturer>, ICollection<ManufacturerListDto>>(entities.ToList());
        }

        public async Task<ManufacturerDto> GetManufacturer(Guid id)
        {
            return _mapper.Map<Manufacturer, ManufacturerDto>(await _manufacturerRepository.Get(id));
        }
    }
}