using System;

namespace GuguShop.Application.Dto
{
    public class ManufacturerUpdateDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}