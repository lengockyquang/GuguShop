using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Repositories
{
    public class CategoryRepository: BaseRepository<Guid, Category, GuguDbContext>, ICategoryRepository
    {
        private readonly GuguDbContext _dbContext;
        public CategoryRepository(GuguDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ICollection<Category>> CreateRange(ICollection<Category> entities, bool autoSave = false)
        {
            await _dbContext.Set<Category>().BulkInsertAsync(entities);
            return entities;        
        }

        public async Task<ICollection<Category>> GetCategoryCombo(CancellationToken cancellationToken1 = default)
        {
            return await _dbContext.Set<Category>()
                .AsNoTracking()
                .ToListAsync(cancellationToken1);
        }
    }
}