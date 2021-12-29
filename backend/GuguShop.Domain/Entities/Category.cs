using System;
using System.Collections.Generic;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Category: Entity<Guid>
    {
        public string Name { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}