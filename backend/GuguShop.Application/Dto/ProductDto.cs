using System;
using System.Collections.Generic;

namespace GuguShop.Application.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        
        public ICollection<TagDto> Tags { get; set; }
    }
}