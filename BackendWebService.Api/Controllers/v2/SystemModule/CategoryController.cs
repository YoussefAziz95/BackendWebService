using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.v2;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoryController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-category")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var result = await mediator.HandleAsync(request);
        return NewResult(result);
    }

    [HttpGet("get-category/{id}")]
    public IActionResult GetCategory([FromRoute] int id)
    {
        var result = mediator.HandleById<CategoryResponse>(id);
        return NewResult(result);
    }

    [HttpPut("update-category")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        var result = await mediator.HandleAsync(request);
        return NewResult(result);
    }

    [HttpPost("get-all-category")]
    public IActionResult GetAllCategory([FromBody] CategoryAllRequest request)
    {
        var result = mediator.Handle(request);
        return NewResult(result);
    }

    [HttpGet("get-by-parent-id/{id?}")]
    public IActionResult GetByParentId([FromRoute] int id)
    {

        var result = mediator.HandleById<CategoryHasChildResponse>(id);
        return NewResult(result);
    }

    [HttpGet("get-available-employees/{categoryId?}")]
    public IActionResult GetAvailableEmployees([FromRoute] int? categoryId = null)
    {

        var categories = unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == categoryId, include: c => c.Include(s => s.SubCategories));
        if (categories is null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null && category.SubCategories.Any()));
        var response = new List<CategoryHasChildResponse>();
        foreach (var c in hasChildCategories)
        {
            var r = new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, FileToLink(c.c.FileId ?? 1), c.hasChild, c.c.IsActive);
        }
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = response
        };
        return NewResult(result);
    }
    [HttpGet("get-services/{categoryId?}")]
    public IActionResult GetServices([FromRoute] int id)
    {

        var categories = unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == id, include: c => c.Include(s => s.SubCategories));
        if (categories is null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null && category.SubCategories.Any()));
        var response = new List<CategoryHasChildResponse>();
        foreach (var c in hasChildCategories)
        {
            var r = new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, FileToLink(c.c.FileId ?? 1), c.hasChild, c.c.IsActive);
        }
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = response
        };
        return NewResult(result);
    }
}