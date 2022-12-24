using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;
using System;

namespace GuguShop.Domain.Repositories
{
    public interface IFileRepository : IBaseRepository<Guid, FileEntity>
    {
    }
}
