using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuguShop.Attributes;

namespace GuguShop.Controllers.Business;

[Authorize]
[ApiController]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> HandleIndexAction(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var specification = new Specification<Category>(limit, offset);
        return Ok(await _categoryService.GetListAsync(specification, cancellationToken));
    }

    [CustomAuthorize]
    [HttpGet("combo")]
    public async Task<IActionResult> HandleGetComboData(CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetComboDataAsync(cancellationToken));
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> HandleShowAction(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> HandleCreateAction([FromBody] CategoryCreateDto createDto)
    {
        return Ok(await _categoryService.CreateAsync(createDto));
    }

    [HttpPost("sample-initial/{maxNumber:int}")]
    public async Task<IActionResult> HandleCreateSampleAction(int maxNumber)
    {
        await _categoryService.InsertSampleData(maxNumber);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> HandleUpdateAction(Guid id, [FromBody] CategoryUpdateDto updateDto)
    {
        return Ok(await _categoryService.UpdateAsync(id, updateDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> HandleDeleteAction(Guid id)
    {
        return Ok(await _categoryService.RemoveAsync(id));
    }
}