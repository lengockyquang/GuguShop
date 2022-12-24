using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;
using System;

namespace GuguShop.Infrastructure.Repositories
{
    public class FileRepository : BaseRepository<Guid, FileEntity, GuguDbContext>, IFileRepository
    {
        public FileRepository(GuguDbContext dbContext) : base(dbContext)
        {
        }
    }
}
