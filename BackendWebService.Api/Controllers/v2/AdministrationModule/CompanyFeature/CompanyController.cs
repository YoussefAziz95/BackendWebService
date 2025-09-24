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
public class CompanyController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-company")]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-company/{id}")]
    public async Task<IActionResult> GetCompany([FromRoute] int id)
    {
        var response = mediator.HandleById<CompanyResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-company")]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(CompanyAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-company")]
    public async Task<IActionResult> DeleteCompany([FromBody] DeleteCompanyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
