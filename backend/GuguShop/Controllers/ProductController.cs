using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("index")]
        public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
        {
            var indexSpecification = new Specification<Product>(
                null,
                queryable => queryable.OrderBy(x => x.Name),
                "Category, Manufacturer");
            return Ok(await _productService.GetListAsync(cancellationToken, indexSpecification));
        }
        
        [HttpGet("show/{id:guid}")]
        public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _productService.GetAsync(id, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> HandleCreateAction([FromBody] ProductCreateDto createDto)
        {
            return Ok(await _productService.CreateAsync(createDto));
        }
        
        [HttpPost("update/{id:guid}")]
        public async Task<IActionResult> HandleUpdateAction(Guid id, ProductUpdateDto updateDto)
        {
            return Ok(await _productService.UpdateAsync(id, updateDto));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> HandleDeleteAction(Guid id)
        {
            return Ok(await _productService.RemoveAsync(id));
        }

    }
}