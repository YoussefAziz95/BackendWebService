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
public class ServiceController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ServiceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddService([FromBody] AddServiceRequest request)
    {
        var service = new Service
        {
            Name = request.Name,
            Code = request.Code,
            CategoryId = request.CategoryId

        };
        _unitOfWork.GenericRepository<Service>().Add(service);
        var result = _unitOfWork.Save();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetService([FromRoute] int id)
    {
        _unitOfWork.GenericRepository<Service>().Exists(Service => Service.Id == id);
        var service = await _unitOfWork.GenericRepository<Service>().GetByIdAsync(id);
        if (service == null)
            return NotFound("Service not found");
        var result = new Response<ServiceResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Service found",
            Data = new ServiceResponse(service.Id, service.Name, service.Code, service.CategoryId)
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceRequest request)
    {
        var service = await _unitOfWork.GenericRepository<Service>().GetByIdAsync(request.Id);
        if (service == null)
            return NotFound("Service not found");
        service.Name = request.Name;
        service.Code = request.Code;
        service.CategoryId = request.CategoryId;
        _unitOfWork.GenericRepository<Service>().Update(service);
        var result = _unitOfWork.Save();
        if (result == 0)
            return BadRequest("Failed to update service");
        var response = new Response<ServiceResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Service updated successfully",
            Data = new ServiceResponse(service.Id, service.Name, service.Code, service.CategoryId)
        };
        return NewResult(response);
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var services = _unitOfWork.GenericRepository<Service>().GetAll();
        var response = new PaginatedResponse<ServiceResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Services found",
            Data = services.Select(service => new ServiceResponse(service.Id, service.Name, service.Code, service.CategoryId)).ToList(),
            TotalCount = services.Count()
        };
        return NewResult(response);
    }
}
