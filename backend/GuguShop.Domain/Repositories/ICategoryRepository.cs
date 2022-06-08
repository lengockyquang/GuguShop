using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;

namespace GuguShop.Domain.Repositories
{
    public interface ICategoryRepository: IBaseRepository<Guid, Category>
    {
        Task<ICollection<Category>> GetCategoryCombo(CancellationToken cancellationToken = default);
    }
}