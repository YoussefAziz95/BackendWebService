using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs.Common;
using BackendWebService.Application.DTOs;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PropertiesController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertiesController(IUnitOfWork unitOfWork)
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
            UserId = request.OwnerId,
            FileId = request.fileId
        };
        _unitOfWork.GenericRepository<Property>().Add(property);
        var result = _unitOfWork.Save();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProperty([FromRoute] int id)
    {
        _unitOfWork.GenericRepository<Property>().Exists(Property => Property.Id == id);
        var property = await _unitOfWork.GenericRepository<Property>().GetByIdAsync(id);
        if (property == null)
            return NotFound("Property not found");
        var result = new Response<PropertyResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Property found",
            Data = new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress,property.FileId, property.CreatedAt, property.UpdatedAt)
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request)
    {
        var property = await _unitOfWork.GenericRepository<Property>().GetByIdAsync(request.Id);
        if (property == null)
            return NotFound("Property not found");
        property.Name = request.Name;
        property.Latitude = request.Latitude;
        property.Longitude = request.Longitude;
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
            Data = new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress, property.FileId, property.CreatedAt, property.UpdatedAt)
        };
        return NewResult(response);
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var properties = _unitOfWork.GenericRepository<Property>().GetAll();
        var response = new PaginatedResponse<PropertyResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Propertys found",
            Data = properties.Select(property => new PropertyResponse(property.Id, property.UserId, property.Name, property.FullAddress, property.FileId, property.CreatedAt, property.UpdatedAt)).ToList(),
            TotalCount = properties.Count()
        };
        return NewResult(response);
    }
}
