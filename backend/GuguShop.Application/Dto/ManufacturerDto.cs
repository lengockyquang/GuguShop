using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuguShop.Application.Dto
{
    public class ManufacturerDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public ICollection<ProductDto> Products { get; set; }

    }
}