using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.v2.SystemModule;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoriesController(IMediator mediator) : AppControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var result = await mediator.HandleAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory([FromRoute] int id)
    {
        var result = mediator.HandleById<CategoryResponse>(id);
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        var result = await mediator.HandleAsync(request);
        return NewResult(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromBody] CategoryAllRequest request )
    {
        var result = await mediator.HandleAsync(request);
        return NewResult(result);
    }

    [HttpGet("GetByParentId/{id?}")]
    public async Task<IActionResult> GetByParentId([FromRoute] int id)
    {

        var result = mediator.HandleById<CategoryHasChildResponse>(id);
        return NewResult(result);
    }
}