using System;
using System.Collections.Generic;

namespace GuguShop.Application.Dto
{
    public class ProductDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public ICollection<CategoryDto> Categories { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
    }
}