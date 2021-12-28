using System;
using System.Threading.Tasks;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers
{
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("index")]
        public async Task<IActionResult> HandleIndexAction()
        {
            return Ok(await _productService.GetListProduct());
        }
        
        [HttpGet("show/{id:guid}")]
        public async Task<IActionResult> HandleShowAction(Guid id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> HandleCreateAction(ProductCreateDto createDto)
        {
            return Ok(await _productService.CreateProduct(createDto));
        }
        
        [HttpPost("update/{id:guid}")]
        public async Task<IActionResult> HandleUpdateAction(Guid id, ProductUpdateDto updateDto)
        {
            return Ok(await _productService.UpdateProduct(updateDto));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> HandleDeleteAction(Guid id)
        {
            return Ok(await _productService.RemoveProduct(id));
        }

    }
}