using System.Collections.Generic;
using System.Text.Json.Serialization;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Dto
{
    public class CategoryDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}