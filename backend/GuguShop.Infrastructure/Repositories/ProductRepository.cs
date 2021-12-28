using System;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;

namespace GuguShop.Infrastructure.Repositories
{
    public class ProductRepository: BaseRepository<Guid, Product, GuguDbContext>, IProductRepository
    {
        public ProductRepository(GuguDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}