using System;
using System.Collections.Generic;

namespace GuguShop.Application.Dto
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<Guid> TagIds { get; set; }
    }
}