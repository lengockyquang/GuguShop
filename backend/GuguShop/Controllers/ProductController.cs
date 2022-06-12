using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Application.Specifications;
using GuguShop.Attributes;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
        {
            var indexSpecification = new GetProductListSpec();
            return Ok(await _productService.GetListAsync(indexSpecification, cancellationToken));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _productService.GetAsync(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> HandleCreateAction([FromBody] ProductCreateDto createDto)
        {
            return Ok(await _productService.CreateAsync(createDto));
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> HandleUpdateAction(Guid id, ProductUpdateDto updateDto)
        {
            return Ok(await _productService.UpdateAsync(id, updateDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> HandleDeleteAction(Guid id)
        {
            return Ok(await _productService.RemoveAsync(id));
        }

    }
}