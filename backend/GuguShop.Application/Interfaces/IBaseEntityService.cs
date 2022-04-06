using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Application.Interfaces
{
    public interface IBaseEntityService<TEntity, TEntityDto, TEntityListDto, TEntityCreateDto, TEntityUpdateDto>
    where TEntity: Entity<Guid>
    {
        Task<TEntityDto> CreateAsync(TEntityCreateDto createDto);
        Task<TEntityDto> UpdateAsync(TEntityUpdateDto updateDto);
        Task<Guid> RemoveAsync(Guid id);
        Task<IEnumerable<TEntityListDto>> GetListAsync();
        Task<TEntityDto> GetAsync(Guid id);
    }
}