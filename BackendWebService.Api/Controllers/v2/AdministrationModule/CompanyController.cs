using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CompanyController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Company APIs
    //-------------------------------
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

    [HttpPost("get-all-company")]
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
    #endregion

    //-------------------------------
    #region Manager APIs
    //-------------------------------
    [HttpPost("add-manager")]
    public async Task<IActionResult> AddManager([FromBody] AddManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-manager/{id}")]
    public async Task<IActionResult> GetManager([FromRoute] int id)
    {
        var response = mediator.HandleById<ManagerResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-manager")]
    public async Task<IActionResult> UpdateManager([FromBody] UpdateManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-manager")]
    public IActionResult GetAll(ManagerAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-manager")]
    public async Task<IActionResult> DeleteManager([FromBody] DeleteManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Company Catgeory APIs
    //-------------------------------
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

    [HttpPost("get-all-company-category")]
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
    #endregion

}
