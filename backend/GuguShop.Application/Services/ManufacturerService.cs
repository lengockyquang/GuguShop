using System;
using System.Collections.Generic;
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
        // todo implement unit of work
        public ManufacturerService(IMapper mapper, IManufacturerRepository manufacturerRepository)
        {
            _mapper = mapper;
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task<ManufacturerDto> CreateManufacturer(ManufacturerCreateDto createDto)
        {
            var createEntity = _mapper.Map<ManufacturerCreateDto, Manufacturer>(createDto);
            var entity = await _manufacturerRepository.Create(createEntity);
            return _mapper.Map<Manufacturer, ManufacturerDto>(entity);
        }

        public Task<ManufacturerDto> UpdateManufacturer(ManufacturerUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> RemoveManufacturer(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ManufacturerListDto>> GetListManufacturer()
        {
            var entities = await _manufacturerRepository.GetWithSpecification();
            return _mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerListDto>>(entities);
        }

        public async Task<ManufacturerDto> GetManufacturer(Guid id)
        {
            return _mapper.Map<Manufacturer, ManufacturerDto>(await _manufacturerRepository.Get(id));
        }
    }
}