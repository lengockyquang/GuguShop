﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Base.Entities;
using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Services
{
    public abstract class BaseEntityService<TEntity, TEntityDto, TEntityListDto, TEntityCreateDto, TEntityUpdateDto>
        :IBaseEntityService<TEntity, TEntityDto, TEntityListDto, TEntityCreateDto, TEntityUpdateDto>
    where TEntity: Entity<Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Guid, TEntity> _baseRepository;

        protected BaseEntityService(IMapper mapper, IBaseRepository<Guid, TEntity> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public virtual async Task<TEntityDto> CreateAsync(TEntityCreateDto createDto)
        {
            var createEntity = _mapper.Map<TEntityCreateDto, TEntity>(createDto);
            var entity = await _baseRepository.Create(createEntity, true);
            return _mapper.Map<TEntity,TEntityDto>(entity);
        }

        public virtual async Task<TEntityDto> UpdateAsync(TEntityUpdateDto updateDto)
        {
            var updateEntity = _mapper.Map<TEntityUpdateDto, TEntity>(updateDto);
            var entity = await _baseRepository.Update(updateEntity, true);
            return _mapper.Map<TEntity,TEntityDto>(entity);        }

        public virtual async Task<Guid> RemoveAsync(Guid id)
        {
            var entity = await _baseRepository.Get(id);
            if (entity == null)
            {
                throw new Exception("Không tìm thấy entity với id " + id);
            }

            await _baseRepository.Delete(entity, true);
            return entity.Id;            
        }

        public virtual async Task<IEnumerable<TEntityListDto>> GetListAsync(CancellationToken cancellation = default)
        {
            var entities = await _baseRepository.GetWithSpecification(null,null,"",cancellation);
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityListDto>>(entities);        
        }

        public virtual async Task<TEntityDto> GetAsync(Guid id,CancellationToken cancellation = default)
        {
            return _mapper.Map<TEntity, TEntityDto>(await _baseRepository.Get(id, cancellation));
        }
    }
}