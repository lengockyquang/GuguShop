using System;
using System.Collections.Generic;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Product: Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public ICollection<Category> Categories { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}