using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class ProductService: BaseEntityService<Product, ProductDto, ProductListDto,ProductCreateDto, ProductUpdateDto>,IProductService
    {
        public ProductService(IMapper mapper, IProductRepository baseRepository) : base(mapper, baseRepository)
        {
        }
    }
}