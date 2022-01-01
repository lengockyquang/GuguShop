using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Mapper
{
    public class ManufacturerProfile: Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<ManufacturerCreateDto, Manufacturer>();
            CreateMap<ManufacturerUpdateDto, Manufacturer>();
            CreateMap<ManufacturerListDto, Manufacturer>().ReverseMap();
            CreateMap<ManufacturerDto, Manufacturer>().ReverseMap();
        }
    }
}