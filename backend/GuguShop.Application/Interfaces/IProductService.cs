using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuguShop.Application.Dto;

namespace GuguShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductCreateDto createDto);
        Task<ProductDto> UpdateProduct(ProductUpdateDto updateDto);
        Task<Guid> RemoveProduct(Guid id);
        Task<IEnumerable<ProductListDto>> GetListProduct();
        Task<ProductDto> GetProduct(Guid id);
    }
}