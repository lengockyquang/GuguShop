using System;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.Base;
using GuguShop.Infrastructure.Data;

namespace GuguShop.Infrastructure.Repositories;

public class TagRepository: BaseRepository<Guid, Tag, GuguDbContext>, ITagRepository
{
    public TagRepository(GuguDbContext dbContext) : base(dbContext)
    {
    }
}