using Api.Base;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Companies;
using Application.Validators.Common;
using Domain;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Companies;
using Application.DTOs.Companies;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : AppControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly UserManager<User> _userManager;

    public CompaniesController(ICompanyService companyService, UserManager<User> userManager)
    {
        _companyService = companyService;
        _userManager = userManager;
    }

    [HttpPost]
    [Authorize(PermissionConstants.COMPANY_CREATE)]
    [ModelValidator]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
    {
        var result = await _companyService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.COMPANY_GET)]
    public async Task<IActionResult> GetCompany([FromRoute] int id)
    {
        var result = await _companyService.GetAsync(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    [Authorize(PermissionConstants.COMPANY_EDIT)]
    [ModelValidator]
    public async Task<IActionResult> UpdateCompany([FromRoute] int id, [FromBody] UpdateCompanyRequest request)
    {
        var result = await _companyService.UpdateAsync(request);
        return NewResult(result);
    }

    [HttpPost("GetAll")]
    [Authorize(PermissionConstants.COMPANY_VIEW)]
    public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
    {
        var result = await _companyService.GetPaginated(request);
        return Ok(result);
    }

    [HttpPost("{id}")]
    [Authorize(PermissionConstants.COMPANY_DELETE)]
    public async Task<IActionResult> DeleteCompany([FromRoute] int id, [FromBody] DeleteSuperPasswordRequest deleteSuperPasswordRequest)
    {
        var validator = new DeleteSuperPasswordRequestValidator(_userManager); // Assuming you have a validator for DeleteSuperPasswordRequest
        var validationResult = await validator.ValidateAsync(deleteSuperPasswordRequest);

        if (!validationResult.IsValid)
        {
            // If validation fails, return bad request with errors
            return BadRequest(validationResult.Errors);
        }

        // Validation passed, proceed with deletion
        var result = await _companyService.DeleteAsync(id);
        return NewResult(result);
    }
}
