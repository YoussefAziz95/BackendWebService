using Api.Base;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Features.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PartController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddPart([FromBody] AddPartRequest request)
    {
        var part = new Part
        {
            Name = request.Name,
            Description = request.Description,
            Code = request.Code,
            Image = request.Image,
            PartNumber = request.PartNumber,
            Manufacturer = request.Manufacturer,
            ProductId = request.ProductId
        };

        _unitOfWork.GenericRepository<Part>().Add(part);
        var result = _unitOfWork.Save();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPart([FromRoute] int id)
    {
        var part = await _unitOfWork.GenericRepository<Part>().GetByIdAsync(id);
        if (part == null)
            return NotFound("Part not found");

        var response = new Response<PartResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Part found",
            Succeeded = true,
            Data = new PartResponse(part.Id, part.Name, part.Description, part.Code, part.Image, part.PartNumber, part.Manufacturer, part.ProductId, part.IsActive)
        };

        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePart([FromBody] UpdatePartRequest request)
    {
        var part = await _unitOfWork.GenericRepository<Part>().GetByIdAsync(request.Id);
        if (part == null)
            return NotFound("Part not found");

        part.Name = request.Name;
        part.Description = request.Description;
        part.Code = request.Code;
        part.Image = request.Image;
        part.PartNumber = request.PartNumber;
        part.Manufacturer = request.Manufacturer;
        part.ProductId = request.ProductId;

        _unitOfWork.GenericRepository<Part>().Update(part);
        var result = _unitOfWork.Save();

        var response = new Response<PartResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Part updated successfully",
            Succeeded = true,
            Data = new PartResponse(part.Id, part.Name, part.Description, part.Code, part.Image, part.PartNumber, part.Manufacturer, part.ProductId, part.IsActive)
        };

        return NewResult(response);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var parts = _unitOfWork.GenericRepository<Part>().GetAll();
        if (parts == null || !parts.Any())
            return NotFound("Parts not found");

        var result = new Response<List<PartResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Parts found",
            Succeeded = true,
            Data = parts.Select(part =>
                new PartResponse(part.Id, part.Name, part.Description, part.Code, part.Image, part.PartNumber, part.Manufacturer, part.ProductId, part.IsActive)).ToList()
        };

        return NewResult(result);
    }
}
