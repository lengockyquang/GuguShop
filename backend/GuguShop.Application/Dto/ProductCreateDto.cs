using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GuguShop.Application.Dto
{
    public class ProductCreateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public Guid ManufacturerId { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<Guid> TagIds { get; set; } = new List<Guid>();
        public IFormFile Image { get; set; }
        public Guid? ImageId { get; set; }
    }
}