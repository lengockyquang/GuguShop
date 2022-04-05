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
        public async Task<ProductDto> CreateProduct(ProductCreateDto createDto)
        {
            var createEntity = _mapper.Map<ProductCreateDto, Product>(createDto);
            var entity = await _productRepository.Create(createEntity, true);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task<ProductDto> UpdateProduct(ProductUpdateDto updateDto)
        {
            var updateEntity = _mapper.Map<ProductUpdateDto, Product>(updateDto);
            var entity = await _productRepository.Update(updateEntity, true);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task<Guid> RemoveProduct(Guid id)
        {
            var entity = await _productRepository.Get(id);
            if (entity == null)
            {
                throw new Exception("Không tìm thấy entity với id " + id);
            }

            await _productRepository.Delete(entity, true);
            return entity.Id;
        }

        public async Task<IEnumerable<ProductListDto>> GetListProduct()
        {
            var entities = await _productRepository.GetWithSpecification(null ,null, "Manufacturer");
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductListDto>>(entities);
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            return _mapper.Map<Product, ProductDto>(await _productRepository.Get(id));
        }
    }
}