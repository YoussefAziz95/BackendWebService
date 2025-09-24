using Api.Base;
using Application.Contracts.Persistence;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;


[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
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
        //var service = new Service
        //{
        //    Name = request.Name,
        //    Code = request.Code,
        //};

        //Category category;
        //if (!_unitOfWork.GenericRepository<Category>().Exists(c => c.Name == request.CategoryName))
        //    return BadRequest("Category not found");

        //category = _unitOfWork.GenericRepository<Category>().Get(c => c.Name == request.CategoryName);
        //service.CategoryId = category.Id;

        //_unitOfWork.GenericRepository<Service>().Add(service);

        //var result = _unitOfWork.Save();
        //return Ok(service.Id);

        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetService([FromRoute] int id)
    {
        //_unitOfWork.GenericRepository<Service>().Exists(Service => Service.Id == id);
        //var service = _unitOfWork.GenericRepository<Service>().Get(s => s.Id == id, include: s => s.Include(c => c.Category));
        //if (service == null)
        //    return NotFound("Service not found");
        //var result = new Response<ServiceResponse>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Service found",
        //    Succeeded = true,
        //    Data = new ServiceResponse(service.Id, service.Name, service.Code, service.Category.Name)
        //};
        //return NewResult(result);

        throw new NotImplementedException();
    }

    [HttpPut]
    public IActionResult UpdateService([FromBody] UpdateServiceRequest request)
    {
        //var service = _unitOfWork.GenericRepository<Service>().Get(c => c.Id == request.Id, include: s => s.Include(c => c.Category));
        //if (service == null)
        //    return NotFound("Service not found");
        //service.Name = request.Name;
        //service.Code = request.Code;
        //_unitOfWork.GenericRepository<Service>().Update(service);
        //var result = _unitOfWork.Save();
        //if (result == 0)
        //    return BadRequest("Failed to update service");
        //var response = new Response<ServiceResponse>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Succeeded = true,
        //    Message = "Service updated successfully",
        //    Data = new ServiceResponse(service.Id, service.Name, service.Code, service.Category.Name)
        //};
        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        //var services = _unitOfWork.GenericRepository<Service>().GetAll(include: s => s.Include(c => c.Category));
        //var response = new PaginatedResponse<ServiceResponse>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Succeeded = true,
        //    Message = "Services found",
        //    Data = services.Select(service => new ServiceResponse(service.Id, service.Name, service.Code, service.Category.Name)).ToList(),
        //    TotalCount = services.Count()
        //};
        //return NewResult(response);

        throw new NotImplementedException();
    }
}
