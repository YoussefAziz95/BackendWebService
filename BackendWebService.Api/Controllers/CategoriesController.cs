using Api.Base;
using Application.Contracts.Services;
using Application.DTOs.Categories;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : AppControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Authorize(PermissionConstants.CATEGORY_CREATE)]
    [ModelValidator]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var result = await _categoryService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.CATEGORY_GET)]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        var result = await _categoryService.GetAsync(id);
        return NewResult(result);
    }

    [HttpDelete("{id}")]
    [Authorize(PermissionConstants.CATEGORY_DELETE)]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpPut]
    [Authorize(PermissionConstants.CATEGORY_EDIT)]
    [ModelValidator]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        var result = await _categoryService.UpdateAsync(request);
        return NewResult(result);
    }

    [HttpGet("GetAll/{CompanyId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromRoute] int CompanyId)
    {
        var result = await _categoryService.GetPaginated(CompanyId);
        return Ok(result);
    }

}
