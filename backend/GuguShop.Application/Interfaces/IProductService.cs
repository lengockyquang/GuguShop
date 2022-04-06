using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuguShop.Application.Dto;
using GuguShop.Domain.Entities;

namespace GuguShop.Application.Interfaces
{
    public interface IProductService: IBaseEntityService<Product, ProductDto, ProductListDto,ProductCreateDto, ProductUpdateDto>
    {
    }
}