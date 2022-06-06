using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Domain.Base.Entities;
using GuguShop.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Base
{
    public class BaseRepository<TKey, TEntity, TDbContext> : IBaseRepository<TKey, TEntity>
        where TEntity : Entity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetQueryable(bool isTracking = true)
        {
            return isTracking ? _dbContext.Set<TEntity>().AsQueryable() : _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        public async Task<TEntity> Get(TKey id,string includeProperties ,CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            if (string.IsNullOrEmpty(includeProperties))
            {
                return await query.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            }
            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }
            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<bool> Any(TKey id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetWithSpecification(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "",
            bool asNoTracking = false,
            bool asNoTrackingWithIdentityResolution = false,
            int? Limit = null,
            int Offset = 0,
            CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (asNoTrackingWithIdentityResolution)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

            }


            if (Offset != 0)
            {
                query = query.Skip(Offset);
            }

            if (Limit.HasValue && Limit.Value != -1)
            {
                query = query.Take(Limit.Value);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> Create(TEntity entity, bool autoSave = false)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<ICollection<TEntity>> CreateRange(ICollection<TEntity> entities, bool autoSave = false)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            if (autoSave == true)
            {
                await _dbContext.SaveChangesAsync();
            }
            return entities;
        }

        public async Task<TEntity> Update(TEntity entity, bool autoSave = false)
        {
            _dbContext.Set<TEntity>().Update(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities, bool autoSave = false)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TKey> Delete(TEntity entity, bool autoSave = false)
        {
            await Task.CompletedTask;
            _dbContext.Set<TEntity>().Remove(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}