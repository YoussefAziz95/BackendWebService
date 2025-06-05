using Api.Base;
using Application.Contracts.Persistence;
using Application.Features.Common;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PropertyController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddProperty([FromBody] AddPropertyRequest request)
    {
        var property = new Property
        {
            Name = request.Name,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            ContactNumber = request.ContactNumber,
            CreatedAt = DateTime.UtcNow,
            UserId = request.UserId,

        };
        var zone = await _unitOfWork.GenericRepository<Zone>().GetByIdAsync(request.ZoneId);
        if (zone is null)
        {
            NotFound("Zone not found");
        }
        property.Zone = zone;

        _unitOfWork.GenericRepository<Property>().Add(property);
        var result = _unitOfWork.Save();

        return result > 0 ? Ok(property.Id) : BadRequest("Failed to add property");
    }

    [HttpGet("{id}")]
    public IActionResult GetProperty([FromRoute] int id)
    {
        var property = _unitOfWork.GenericRepository<Property>()
            .Get(p => p.Id == id, include: p => p.Include(z => z.Zone).Include(u => u.User));

        if (property is null)
            return NotFound("Property not found");

        var result = new Response<PropertyResponse>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Property found",
            Succeeded = true,
            Data = new PropertyResponse(property.Id, property.User.Id, property.Name, property.User.FirstName, property.User.PhoneNumber, property.Zone.Name, property.Longitude, property.Latitude, property.CreatedDate.Value)
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request)
    {
        var property = _unitOfWork.GenericRepository<Property>()
            .Get(p => p.Id == request.Id, include: p => p.Include(z => z.Zone));

        if (property is null)
            return NotFound("Property not found");
        if (property.User is null)
            return NotFound("Customer not found");
        if (property.Zone is null)
            return NotFound("Zone not found");
        var zone = await _unitOfWork.GenericRepository<Zone>().GetByIdAsync(request.ZoneId);
        if (zone is null)
        {
            NotFound("New Zone not found Check ZoneId");
        }
        property.Name = request.Name;
        property.Latitude = request.Latitude;
        property.Longitude = request.Longitude;
        property.ContactNumber = request.ContactNumber;
        property.Zone = zone;
        property.ZoneId = zone.Id;
        property.IsDeleted = false;
        property.DeletedAt = null;

        _unitOfWork.GenericRepository<Property>().Update(property);
        var result = _unitOfWork.Save();

        if (result == 0)
            return BadRequest("Failed to update property");

        var response = new Response<PropertyResponse>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Property found",
            Succeeded = true,
            Data = new PropertyResponse(property.Id, property.User.Id, property.Name, property.User.FirstName, property.User.PhoneNumber, property.Zone.Name, property.Longitude, property.Latitude, property.CreatedDate.Value)
        };
        return NewResult(response);
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromRoute] int id)
    {
        await _unitOfWork.BeginTransactionAsync();

        if (!_unitOfWork.GenericRepository<Property>().Exists(p => p.Id == id))
            return NotFound("Property not found");

        var property = _unitOfWork.GenericRepository<Property>().Get(p => p.Id == id);
        _unitOfWork.GenericRepository<Property>().SoftDelete(property);
        var result = _unitOfWork.Save();

        return result > 0 ? Ok("Property deleted successfully") : BadRequest("Failed to delete property");
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var properties = _unitOfWork.GenericRepository<Property>().GetAll(
            include: p => p.Include(z => z.Zone).Include(u => u.User));

        var response = new PaginatedResponse<PropertyListResponse>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Properties found",
            Succeeded = true,
            Data = properties.Select(p => new PropertyListResponse(
                p.Id,
                p.Name,
                p.User.FirstName,
                p.ContactNumber,
                p.Zone?.Name ?? string.Empty,
                p.Latitude,
                p.Longitude)).ToList(),
            TotalCount = properties.Count()
        };

        return NewResult(response);
    }
}
