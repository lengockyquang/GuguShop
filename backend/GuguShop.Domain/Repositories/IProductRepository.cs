using System;
using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;

namespace GuguShop.Domain.Repositories
{
    public interface IProductRepository: IBaseRepository<Guid, Product>
    {
        
    }
}