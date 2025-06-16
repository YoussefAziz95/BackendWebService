using Api.Base;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
using Domain;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class CompaniesController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyService _companyService;

    public CompaniesController(IUnitOfWork unitOfWork, ICompanyService companyService)
    {
        _unitOfWork = unitOfWork;
        _companyService = companyService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
    {
        var company = new Company
        {
            CompanyName = request.CompanyName,
            ContactEmail = request.Email,
            ContactPhone = request.Phone,
            RegistrationNumber = request.RegistrationNumber,
            Status = StatusEnum.Active,
            IsActive = true,
        };
        var organization = new Organization
        {
            Name = request.CompanyName,
            Email = request.Email,
            Phone = request.Phone,
            City = request.City,
            Country = request.Country,
            StreetAddress = request.StreetAddress,
            TaxNo = request.TaxNo,
            Type = OrganizationEnum.Company,
        };
        _unitOfWork.GenericRepository<Company>().Add(company);
        await _unitOfWork.SaveAsync();

        var result = new Response<int>
        {
            Data = company.Id,
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Company added successfully"
        };

        return NewResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany([FromRoute] int id)
    {
        var company = await _unitOfWork.GenericRepository<Company>().GetByIdAsync(id);
        if (company == null)
            return NotFound("Company not found");

        var result = new Response<Company>
        {
            Data = company,
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Company retrieved successfully"
        };

        return NewResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
    {
        var company = await _unitOfWork.GenericRepository<Company>().GetByIdAsync(request.Id);
        if (company == null)
            return NotFound("Company not found");

        company.Organization.StreetAddress = request.StreetAddress;
        company.CompanyName = request.CompanyName;
        company.ContactEmail = request.Email;
        company.ContactPhone = request.Phone;
        company.RegistrationNumber = request.RegistrationNumber;
        company.Status = StatusEnum.Active;
        company.IsActive = true;
        company.Organization.Email = request.Email;
        company.Organization.Phone = request.Phone;
        company.Organization.City = request.City;
        company.Organization.Country = request.Country;
        company.Organization.StreetAddress = request.StreetAddress;
        company.Organization.TaxNo = request.TaxNo;
        company.Organization.Type = OrganizationEnum.Company;

        _unitOfWork.GenericRepository<Company>().Update(company);
        await _unitOfWork.SaveAsync();

        var result = new Response<string>
        {
            Data = "Updated",
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Company updated successfully"
        };

        return NewResult(result);
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll(GetPaginatedCompanyRequest request)
    {
        var response = await _companyService.GetPaginated(request);
        return NewResult(response);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteCompany([FromRoute] int id, [FromBody] DeleteSuperPasswordRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SuperPassword))
            return BadRequest("Enter Password");

        var company = await _unitOfWork.GenericRepository<Company>().GetByIdAsync(id);
        if (company == null)
            return NotFound("Company not found");

        _unitOfWork.GenericRepository<Company>().Delete(company);
        await _unitOfWork.SaveAsync();

        var result = new Response<string>
        {
            Data = "Deleted",
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Company deleted successfully"
        };

        return NewResult(result);
    }
}
