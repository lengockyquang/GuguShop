using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GuguShop.Domain.Base.Repositories
{
    public interface IBaseRepository<TKey, TEntity> where TEntity: class
    {
    
        IQueryable<TEntity> GetQueryable(bool isTracking = true);
        Task<TEntity> Get(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetWithSpecification(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default);
        Task<TEntity> Create(TEntity entity, bool autoSave = false);
        Task<TEntity> Update(TEntity entity, bool autoSave = false);
        Task<TKey> Delete(TEntity id, bool autoSave = false);
    }
}