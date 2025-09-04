using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
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

    public CompaniesController(IUnitOfWork unitOfWork,
        ICompanyService companyService,
        IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _companyService = companyService;
    }

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
    {
        //try
        //{
        //    await _unitOfWork.BeginTransactionAsync();

        //    var user = _unitOfWork.GetUserInfo();
        //    var createdBy = user?.Username ?? "System";

        //    var organization = new Organization
        //    {
        //        Name = request.CompanyName,
        //        Email = request.Email,
        //        Phone = request.Phone,
        //        City = request.City,
        //        Country = request.Country,
        //        StreetAddress = request.StreetAddress,
        //        TaxNo = request.TaxNo,
        //        Type = OrganizationEnum.Company,
        //        FileId = request.FileId ?? 1,
        //        CreatedDate = DateTime.UtcNow,
        //        CreatedBy = createdBy
        //    };
        //    _unitOfWork.GenericRepository<Organization>().Add(organization);

        //    var company = new Company
        //    {
        //        CompanyName = request.CompanyName,
        //        ContactEmail = request.Email,
        //        ContactPhone = request.Phone,
        //        RegistrationNumber = request.RegistrationNumber,
        //        Status = StatusEnum.Active,
        //        IsActive = true,
        //        OrganizationId = organization.Id,
        //        CreatedDate = DateTime.UtcNow,
        //        CreatedBy = createdBy
        //    };
        //    _unitOfWork.GenericRepository<Company>().Add(company);

        //    if (request.Addresses?.Any() == true)
        //    {
        //        foreach (var addr in request.Addresses)
        //        {
        //            _unitOfWork.GenericRepository<Address>().Add(new Address
        //            {
        //                FullAddress = addr.FullAddress,
        //                Street = addr.Street,
        //                Zone = addr.Zone,
        //                State = addr.State,
        //                City = addr.City,
        //                IsAdministration = addr.IsAdministration,
        //                OrganizationId = organization.Id,
        //                CreatedDate = DateTime.UtcNow,
        //                CreatedBy = createdBy
        //            });
        //        }
        //    }

        //    if (request.Contacts?.Any() == true)
        //    {
        //        foreach (var contact in request.Contacts)
        //        {
        //            _unitOfWork.GenericRepository<Contact>().Add(new Contact
        //            {
        //                OrganizationId = organization.Id,
        //                Type = contact.Type,
        //                Value = contact.Value,
        //                CreatedDate = DateTime.UtcNow,
        //                CreatedBy = createdBy
        //            });
        //        }
        //    }

        //    await _unitOfWork.SaveAsync();
        //    await _unitOfWork.CommitAsync();

        //    var result = new Response<int>
        //    {
        //        Data = company.Id,
        //        Succeeded = true,
        //        StatusCode = ApiResultStatusCode.Success,
        //        Message = "Company added successfully"
        //    };

        //    return NewResult(result);
        //}
        //catch (Exception ex)
        //{
        //    await _unitOfWork.RollbackAsync();

        //    var result = new Response<string>
        //    {
        //        Data = null,
        //        Succeeded = false,
        //        StatusCode = ApiResultStatusCode.ServerError,
        //        Message = "Failed to add company. " + ex.Message
        //    };

        //    return NewResult(result);

        throw new NotImplementedException();
    }
    



    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany([FromRoute] int id)
    {
        var company = _unitOfWork.GenericRepository<Company>()
            .Get(
                company => company.Id == id,
                include: company => company
                    .Include(c => c.Organization)
                        .ThenInclude(o => o.Addresses)
                    .Include(c => c.Organization)
                        .ThenInclude(o => o.Contacts)
            );

        if (company == null)
            return NotFound("Company not found");

        var org = company.Organization;

        //var response = new CompanyResponse(
        //    Id: company.Id,
        //    Name: company.CompanyName ?? string.Empty,
        //    Country: org?.Country ?? string.Empty,
        //    City: org?.City ?? string.Empty,
        //    StreetAddress: org?.StreetAddress ?? string.Empty,
        //    Email: org?.Email ?? string.Empty,
        //    TaxNo: org?.TaxNo ?? string.Empty,
        //    Phone: org?.Phone,
        //    FileId: org?.FileId,
        //    ImageUrl: org?.File?.FullPath, // optional if you include File
        //    Fax: org?.FaxNo,
        //    RoleType: org?.Type.ToString() ?? string.Empty,
        //    IsActive: company.IsActive,
        //    CreatedDate: company.CreatedDate,
        //    UpdateDate: company.UpdatedDate,
        //    Addresses: company.Organization.Addresses?.Select(a => new AddressResponse(
        //        Id: a.Id,
        //        FullAddress: a.FullAddress ?? "",
        //        Street: a.Street ?? "",
        //        Zone: a.Zone ?? "",
        //        State: a.State ?? "",
        //        City: a.City ?? "",
        //        IsAdministration: a.IsAdministration
        //    )).ToList() ?? new(),
        //    Contacts: company.Organization.Contacts?.Select(c => new ContactResponse(
        //        Id: c.Id,
        //        Type: c.Type ?? "",
        //        Value: c.Value
        //    )).ToList() ?? new()
        //);

        //var result = new Response<CompanyResponse>
        //{
        //    Data = response,
        //    Succeeded = true,
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Company retrieved successfully"
        //};

        //return NewResult(result);

        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
    {
        var company = await _unitOfWork.GenericRepository<Company>().GetByIdAsync(request.Id);
        //if (company == null)
        //    return NotFound("Company not found");

        //company.Organization.StreetAddress = request.StreetAddress;
        //company.CompanyName = request.CompanyName;
        //company.ContactEmail = request.Email;
        //company.ContactPhone = request.Phone;
        //company.RegistrationNumber = request.RegistrationNumber;
        //company.Status = StatusEnum.Active;
        //company.IsActive = true;
        //company.Organization.Email = request.Email;
        //company.Organization.Phone = request.Phone;
        //company.Organization.City = request.City;
        //company.Organization.Country = request.Country;
        //company.Organization.StreetAddress = request.StreetAddress;
        //company.Organization.TaxNo = request.TaxNo;
        //company.Organization.Type = OrganizationEnum.Company;

        //_unitOfWork.GenericRepository<Company>().Update(company);
        //await _unitOfWork.SaveAsync();

        //var result = new Response<string>
        //{
        //    Data = "Updated",
        //    Succeeded = true,
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Company updated successfully"
        //};

        //return NewResult(result);

        throw new NotImplementedException();
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll(CompanyAllRequest request)
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
