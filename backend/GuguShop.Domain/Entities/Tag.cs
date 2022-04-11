using System;
using System.Collections;
using System.Collections.Generic;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Tag: Entity<Guid>
    {
        public string Name { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}