using System.Diagnostics;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;
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
    public async Task<IActionResult> HandleIndexAction(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var specification = new Specification<Category>(limit, offset);
        return Ok(await _categoryService.GetListAsync(specification, cancellationToken));
    }

    [HttpGet("index-combo")]
    public async Task<IActionResult> HandleGetComboData(CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetComboDataAsync(cancellationToken));
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
    
    [HttpPost("create-sample/{maxNumber:int}")]
    public async Task<IActionResult> HandleCreateSampleAction(int maxNumber)
    {
        await _categoryService.InsertSampleData(maxNumber);
        return Ok();
    }
        
    [HttpPost("update/{id:guid}")]
    public async Task<IActionResult> HandleUpdateAction(Guid id, [FromBody]CategoryUpdateDto updateDto)
    {
        return Ok(await _categoryService.UpdateAsync(id, updateDto));
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> HandleDeleteAction(Guid id)
    {
        return Ok(await _categoryService.RemoveAsync(id));
    }
}