using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
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
            FullAddress = request.FullAddress,
            UserId = request.UserId,
            ContactNumber = request.ContactNumber,
            BuildingNumber = request.BuildingNumber,
            FloorNumber = request.FloorNumber,
            ApartmentNumber = request.ApartmentNumber,
            StreetNumber = request.StreetNumber,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };
        Zone zone;
        if (!_unitOfWork.GenericRepository<Zone>().Exists(c => c.Name == request.Name))
            zone = new Zone() { Name = request.ZoneName };
        else
            zone = _unitOfWork.GenericRepository<Zone>().Get(c => c.Name == request.Name);
        property.Zone = zone;
        _unitOfWork.GenericRepository<Property>().Add(property);
        var result = _unitOfWork.Save();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProperty([FromRoute] int id)
    {
        _unitOfWork.GenericRepository<Property>().Exists(Property => Property.Id == id);
        var property = _unitOfWork.GenericRepository<Property>().Get(p => p.Id == id,
            include: p => p.Include(z => z.Zone));
        if (property == null)
            return NotFound("Property not found");
        var result = new Response<PropertyResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Property found",
            Succeeded = true,
            Data = new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress,
            property.Zone?.Name ?? null, property.ContactNumber, property.BuildingNumber, property.FloorNumber, property.ApartmentNumber, property.StreetNumber,
            property.CreatedAt, property.UpdatedAt)
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request)
    {
        var property = _unitOfWork.GenericRepository<Property>().Get(p => p.Id == request.Id,
            include: p => p.Include(z => z.Zone));
        var zone = _unitOfWork.GenericRepository<Zone>().Get(c => c.Name == request.ZoneName);
        if (property is null)
            return NotFound("Property not found");
        if (zone is null)
            return NotFound("Zone not found");
        if (zone.Name != property.Zone.Name)
        {
            property.Zone = zone;
        }
        property.Name = request.Name;
        property.Latitude = request.Latitude;
        property.Longitude = request.Longitude;
        property.ContactNumber = request.ContactNumber;
        property.FullAddress = request.FullAddress;
        property.UserId = request.UserId;
        property.ApartmentNumber = request.ApartmentNumber;
        property.BuildingNumber = request.BuildingNumber;
        property.FloorNumber = request.FloorNumber;
        property.StreetNumber = request.StreetNumber;
        property.UpdatedAt = DateTime.UtcNow;
        property.DeletedAt = null;
        property.IsDeleted = false;
        _unitOfWork.GenericRepository<Property>().Update(property);
        var result = _unitOfWork.Save();
        if (result == 0)
            return BadRequest("Failed to update property");

        var response = new Response<PropertyResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Property updated successfully",
            Succeeded = true,
            Data = new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress,
            property.Zone?.Name ?? null, property.ContactNumber, property.BuildingNumber, property.FloorNumber, property.ApartmentNumber, property.StreetNumber,
            property.CreatedAt, property.UpdatedAt)
        };
        return NewResult(response);
    }
    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete([FromRoute] int id)
    {
        int result;
        await _unitOfWork.BeginTransactionAsync();
        if (!_unitOfWork.GenericRepository<Property>().ExistsNoTracking())
            return NotFound("Property not found");
        else
        {
            var property = _unitOfWork.GenericRepository<Property>().Get(p => p.Id == id);
            _unitOfWork.GenericRepository<Property>().SoftDelete(property);
            result = _unitOfWork.Save();
        }
        return result > 0 ? BadRequest(result) : Ok(result);

    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var properties = _unitOfWork.GenericRepository<Property>().GetAll(include: p => p.Include(z => z.Zone));
        var response = new PaginatedResponse<PropertyResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Propertys found",
            Succeeded = true,
            Data = properties.Select(property => new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress,
            property.Zone?.Name ?? null, property.ContactNumber, property.BuildingNumber, property.FloorNumber, property.ApartmentNumber, property.StreetNumber,
            property.CreatedAt, property.UpdatedAt)).ToList(),
            TotalCount = properties.Count()
        };
        return NewResult(response);
    }
}
