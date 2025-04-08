using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs.Common;
using BackendWebService.Application.DTOs;
using Domain;
using Domain.Constants;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var category = new Category
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        _unitOfWork.GenericRepository<Category>().Add(category);
        var result = _unitOfWork.Save();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.CATEGORY_GET)]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(id);
        if (category == null)
            return NotFound("Category not found");
        var result = new Response<CategoryResponse>()
        {
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, category.IsActive),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Category found"
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(request.Id);
        if (category == null)
            return NotFound("Category not found");
        category.Name = request.Name;
        category.ParentId = request.ParentId;
        _unitOfWork.GenericRepository<Category>().Update(category);
        var result = _unitOfWork.Save();
        if (result == null)
            return NotFound("Category not found");
        var response = new Response<CategoryResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Category updated successfully",
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, category.IsActive)
        };
        return NewResult(response);
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var categories = _unitOfWork.GenericRepository<Category>().GetAll();
        if (categories == null)
            return NotFound("Categories not found");
        var result = new Response<List<CategoryResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Data = categories.Select(c => new CategoryResponse(c.Id, c.Name, c.ParentId, c.IsActive)).ToList()
        };
        return NewResult(result);
    }

}
