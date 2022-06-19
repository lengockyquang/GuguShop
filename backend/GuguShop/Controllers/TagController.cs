using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

[Authorize]
[ApiController]
[Route("/api/tags")]
public class TagController: Controller
{
    private readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
    {
        return Ok(await _tagService.GetListAsync(null, cancellationToken));
    }
        
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await _tagService.GetAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> HandleCreateAction([FromBody] TagCreateDto createDto)
    {
        return Ok(await _tagService.CreateAsync(createDto));
    }
        
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> HandleUpdateAction(Guid id, TagUpdateDto updateDto)
    {
        return Ok(await _tagService.UpdateAsync(id,updateDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> HandleDeleteAction(Guid id)
    {
        return Ok(await _tagService.RemoveAsync(id));
    }
    
}