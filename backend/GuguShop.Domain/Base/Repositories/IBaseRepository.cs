using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Infrastructure.Utility;

namespace GuguShop.Domain.Base.Repositories
{
    public interface IBaseRepository<TKey, TEntity> where TEntity: class
    {
    
        IQueryable<TEntity> GetQueryable(bool isTracking = true);
        Task<TEntity> Get(TKey id,string includeProperties = "", CancellationToken cancellationToken = default);
        Task<bool> Any(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetWithSpecification(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            EfTrackingType efTrackingType = EfTrackingType.DefaultTracking,
            int? limit = null,
            int offset = 0,
            CancellationToken cancellationToken = default);
        Task<TEntity> Create(TEntity entity, bool autoSave = false);
        Task<ICollection<TEntity>> CreateRange(ICollection<TEntity> entities, bool autoSave = false);
        Task<TEntity> Update(TEntity entity, bool autoSave = false);
        Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities, bool autoSave = false);
        Task<TKey> Delete(TEntity entity, bool autoSave = false);
        Task<ICollection<TKey>> DeleteRange(ICollection<TEntity> entities, bool autoSave = false);

        Task SaveChangeAsync();
    }
}