using System;
using System.Threading.Tasks;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers
{
    [ApiController]
    [Route("/api/manufacturer")]
    public class ManufacturerController: Controller
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        
        [HttpGet("index")]
        public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
        {
            return Ok(await _manufacturerService.GetListAsync(null, cancellationToken));
        }
        
        [HttpGet("show/{id:guid}")]
        public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _manufacturerService.GetAsync(id, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> HandleCreateAction([FromBody]ManufacturerCreateDto createDto)
        {
            return Ok(await _manufacturerService.CreateAsync(createDto));
        }
        
        [HttpPost("update/{id:guid}")]
        public async Task<IActionResult> HandleUpdateAction(Guid id, [FromBody]ManufacturerUpdateDto updateDto)
        {
            return Ok(await _manufacturerService.UpdateAsync(id,updateDto));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> HandleDeleteAction(Guid id)
        {
            return Ok(await _manufacturerService.RemoveAsync(id));
        }
    }
}