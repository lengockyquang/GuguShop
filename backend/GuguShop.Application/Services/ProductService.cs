using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<ProductCreateDto> CreateProduct(ProductCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUpdateDto> UpdateProduct(ProductUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> RemoveProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductListDto>> GetListProduct()
        {
            var entities = await _productRepository.GetWithSpecification();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductListDto>>(entities);
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            return _mapper.Map<Product, ProductDto>(await _productRepository.Get(id));
        }
    }
}