using System;
using System.Threading.Tasks;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers.Business
{
    [Authorize]
    [ApiController]
    [Route("/api/manufacturers")]
    public class ManufacturerController: Controller
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        
        [HttpGet]
        public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
        {
            return Ok(await _manufacturerService.GetListAsync(null, cancellationToken));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _manufacturerService.GetAsync(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> HandleCreateAction([FromBody]ManufacturerCreateDto createDto)
        {
            return Ok(await _manufacturerService.CreateAsync(createDto));
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> HandleUpdateAction(Guid id, [FromBody]ManufacturerUpdateDto updateDto)
        {
            return Ok(await _manufacturerService.UpdateAsync(id,updateDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> HandleDeleteAction(Guid id)
        {
            return Ok(await _manufacturerService.RemoveAsync(id));
        }

        [HttpGet("combo")]
        public async Task<IActionResult> HandleGetComboData(CancellationToken cancellationToken = default)
        {
            return Ok(await _manufacturerService.GetComboDataAsync(cancellationToken));
        }
    }
}