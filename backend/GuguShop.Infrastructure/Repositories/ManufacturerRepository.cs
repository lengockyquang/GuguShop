using System;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;

namespace GuguShop.Infrastructure.Repositories
{
    public class ManufacturerRepository: BaseRepository<Guid, Manufacturer, GuguDbContext>, IManufacturerRepository
    {
        public ManufacturerRepository(GuguDbContext dbContext) : base(dbContext)
        {
        }
    }
}