using System.Threading.Tasks;
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
        public async Task<IActionResult> HandleGetAllAction()
        {
            return Ok(await _productService.GetListProduct());
        }
    }
}