using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Domain.Base.Entities;
using GuguShop.Infrastructure.Specification;

namespace GuguShop.Application.Interfaces
{
    public interface IBaseEntityService<TEntity, TEntityDto, TEntityListDto, TEntityCreateDto, TEntityUpdateDto>
    where TEntity: Entity<Guid>
    {
        Task<TEntityDto> CreateAsync(TEntityCreateDto createDto);
        Task<TEntityDto> UpdateAsync(Guid id, TEntityUpdateDto updateDto);
        Task<Guid> RemoveAsync(Guid id);
        ValueTask<IEnumerable<TEntityListDto>> GetListAsync(CancellationToken cancellation = default, Specification<TEntity> specification = null);
        Task<TEntityDto> GetAsync(Guid id, CancellationToken cancellation = default);
    }
}