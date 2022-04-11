using System;
using System.Collections.Generic;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Product: Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        
        public ICollection<Tag> Tags { get; set; }

    }
}