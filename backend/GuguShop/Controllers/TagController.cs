using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

[ApiController]
[Route("/api/tag")]
public class TagController: Controller
{
    private readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet("index")]
    public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
    {
        return Ok(await _tagService.GetListAsync(cancellationToken));
    }
        
    [HttpGet("show/{id:guid}")]
    public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await _tagService.GetAsync(id, cancellationToken));
    }

    [HttpPost("create")]
    public async Task<IActionResult> HandleCreateAction([FromBody] TagCreateDto createDto)
    {
        return Ok(await _tagService.CreateAsync(createDto));
    }
        
    [HttpPost("update/{id:guid}")]
    public async Task<IActionResult> HandleUpdateAction(Guid id, TagUpdateDto updateDto)
    {
        return Ok(await _tagService.UpdateAsync(updateDto));
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> HandleDeleteAction(Guid id)
    {
        return Ok(await _tagService.RemoveAsync(id));
    }
    
}