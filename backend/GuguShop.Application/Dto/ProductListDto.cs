using System;

namespace GuguShop.Application.Dto
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid CategoryId { get; set; }
        public CategoryListDto Category { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public ManufacturerListDto Manufacturer { get; set; }
    }
}