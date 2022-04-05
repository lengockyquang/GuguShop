using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GuguShop.Domain.Base.Entities;
using GuguShop.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Base
{
    public class BaseRepository<TKey, TEntity, TDbContext>: IBaseRepository<TKey,TEntity>
        where TEntity: Entity<TKey>
        where TDbContext: DbContext
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

        public async Task<TEntity> Get(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetWithSpecification(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity, bool autoSave = false)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity, bool autoSave = false)
        {
            var isExist = await _dbContext.Set<TEntity>().AnyAsync(x => x.Id.Equals(entity.Id));
            if (!isExist)
            {
                throw new Exception("Can not find entity with id " + entity.Id);
            }
            _dbContext.Set<TEntity>().Update(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TKey> Delete(TEntity entity, bool autoSave = false)
        {
            await Task.CompletedTask;
            _dbContext.Set<TEntity>().Remove(entity);
            if (autoSave == true) await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}