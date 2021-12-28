using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuguShop.Application.Dto;

namespace GuguShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductCreateDto> CreateProduct(ProductCreateDto createDto);
        Task<ProductUpdateDto> UpdateProduct(ProductCreateDto updateDto);
        Task<Guid> RemoveProduct(Guid id);
        Task<IEnumerable<ProductListDto>> GetListProduct();
        Task<ProductDto> GetProduct(Guid id);
    }
}