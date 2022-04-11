using System;
using System.Collections.Generic;
using System.Threading;
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
        Task<IEnumerable<TEntityListDto>> GetListAsync(CancellationToken cancellation = default);
        Task<TEntityDto> GetAsync(Guid id, CancellationToken cancellation = default);
    }
}