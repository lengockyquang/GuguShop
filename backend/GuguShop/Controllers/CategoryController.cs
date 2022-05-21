using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController: Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("index")]
    public async Task<IActionResult> HandleIndexAction(CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetListAsync(cancellationToken));
    }
        
    [HttpGet("show/{id:guid}")]
    public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetAsync(id, cancellationToken));
    }

    [HttpPost("create")]
    public async Task<IActionResult> HandleCreateAction([FromBody]CategoryCreateDto createDto)
    {
        return Ok(await _categoryService.CreateAsync(createDto));
    }
        
    [HttpPost("update/{id:guid}")]
    public async Task<IActionResult> HandleUpdateAction(Guid id, [FromBody]CategoryUpdateDto updateDto)
    {
        return Ok(await _categoryService.UpdateAsync(updateDto));
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> HandleDeleteAction(Guid id)
    {
        return Ok(await _categoryService.RemoveAsync(id));
    }
}