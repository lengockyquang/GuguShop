using System;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;

namespace GuguShop.Infrastructure.Repositories
{
    public class CategoryRepository: BaseRepository<Guid, Category, GuguDbContext>, ICategoryRepository
    {
        public CategoryRepository(GuguDbContext dbContext) : base(dbContext)
        {
        }
    }
}