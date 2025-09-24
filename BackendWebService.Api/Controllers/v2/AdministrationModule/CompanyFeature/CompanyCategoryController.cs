using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CompanyCategoryCategoryController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-company-category")]
    public async Task<IActionResult> AddCompanyCategory([FromBody] AddCompanyCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-company-category/{id}")]
    public async Task<IActionResult> GetCompanyCategory([FromRoute] int id)
    {
        var response = mediator.HandleById<CompanyCategoryResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-company-category")]
    public async Task<IActionResult> UpdateCompanyCategory([FromBody] UpdateCompanyCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(CompanyCategoryAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-company-category")]
    public async Task<IActionResult> DeleteCompanyCategory([FromBody] DeleteCompanyCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
