using System;
using System.Collections.Generic;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Domain.Entities
{
    public class Manufacturer: Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}