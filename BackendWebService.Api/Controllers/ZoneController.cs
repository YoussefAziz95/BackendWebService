using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ZoneController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ZoneController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddZone([FromBody] AddZoneRequest request)
    {
        var zone = new Zone
        {
            Name = request.Name,
            Description = request.Description,
            ParentZoneId = request.ParentId
        };

        _unitOfWork.GenericRepository<Zone>().Add(zone);
        var result = _unitOfWork.Save();

        return Ok(zone.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetZone([FromRoute] int id)
    {
        var zone = await _unitOfWork.GenericRepository<Zone>().GetByIdAsync(id);
        if (zone == null)
            return NotFound("Zone not found");

        var result = new Response<ZoneResponse>()
        {
            Data = new ZoneResponse(zone.Id, zone.Name, zone.Description, zone.ParentZoneId, zone.IsActive),
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "Zone found"
        };

        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateZone([FromBody] UpdateZoneRequest request)
    {
        var zone = await _unitOfWork.GenericRepository<Zone>().GetByIdAsync(request.Id);
        if (zone == null)
            return NotFound("Zone not found");

        zone.Name = request.Name;
        zone.Description = request.Description;
        zone.ParentZoneId = request.ParentId;

        _unitOfWork.GenericRepository<Zone>().Update(zone);
        var result = _unitOfWork.Save();

        var response = new Response<ZoneResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "Zone updated successfully",
            Data = new ZoneResponse(zone.Id, zone.Name, zone.Description, zone.ParentZoneId, zone.IsActive)
        };

        return NewResult(response);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var zones = _unitOfWork.GenericRepository<Zone>().GetAll();
        if (zones == null || !zones.Any())
            return NotFound("Zones not found");

        var result = new Response<List<ZoneResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "Zones found",
            Data = zones.Select(z =>
                new ZoneResponse(z.Id, z.Name, z.Description, z.ParentZoneId, z.IsActive)).ToList()
        };

        return NewResult(result);
    }
}
