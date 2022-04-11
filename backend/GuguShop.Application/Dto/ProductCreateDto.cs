using System;

namespace GuguShop.Application.Dto
{
    public class ProductCreateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public Guid CategoryId { get; set; }
    }
}