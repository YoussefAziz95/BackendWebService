using Api.Base;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Features.Common;
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

    public CompaniesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
    {
        var company = new Company
        {
            Name = request.Name,
            ContactEmail = request.Email,
            ContactPhone = request.Phone,
            RegistrationNumber = request.RegistrationNumber,
            Status = StatusEnum.Active,
            IsActive = true,
        };
        var organization = new Organization
        {
            Name = request.Name,
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

        company.Name = request.Name;
        company.Organization.StreetAddress = request.StreetAddress;
        company.Name = request.Name;
        company.ContactEmail = request.Email;
        company.ContactPhone = request.Phone;
        company.RegistrationNumber = request.RegistrationNumber;
        company.Status = StatusEnum.Active;
        company.IsActive = true;
        company.Name = request.Name;
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = _unitOfWork.GenericRepository<Company>().GetAll(include: c => c.Include(o => o.Organization)).Select
            (c => new CompanyResponse(
                c.Id,
                c.Name,
                c.Organization.Country,
                c.Organization.City,
                c.Organization.StreetAddress,
                c.ContactEmail,
                c.Organization.TaxNo,
                c.ContactPhone,
                null,
                c.Organization.Fax,
                Enum.GetName(typeof(OrganizationEnum), c.Organization.Type),
                c.IsActive ?? true,
                c.CreatedDate ?? DateTime.UtcNow,
                c.UpdateDate)).ToList();
        var response = new Response<List<CompanyResponse>>
        {
            Data = query,
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Companies retrieved successfully"
        };



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
