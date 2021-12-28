using System;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Product: Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}