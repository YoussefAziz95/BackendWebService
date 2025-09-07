using Api.Base;
using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomerServiceController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServiceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet("{id}")]
    public IActionResult GetCustomerService([FromRoute] int id)
    {
        var customerService = _unitOfWork.GenericRepository<CustomerService>().Get(c => c.Id == id,
            include: c => c.Include(s => s.Service).Include(c => c.Customer)
            );
        if (customerService == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer service not found",
                Succeeded = false
            });
        }
        if (customerService.Customer == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer not found",
                Succeeded = false
            });
        }
        if (customerService.Service == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Service not found",
                Succeeded = false
            });
        }

        var response = new Response<BookingResponse>
        {
            Data = new BookingResponse(
                customerService.Id,
                customerService.CustomerId,
                customerService.Service.Name,
                customerService.Service.Code,
                customerService.Description,
                customerService.Status,
                customerService.RequestedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer service found",
            Succeeded = true
        };

        return NewResult(response);
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var customerServices = _unitOfWork.GenericRepository<CustomerService>().GetAll();
        if (customerServices == null || !customerServices.Any())
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "No customer services found",
                Succeeded = false
            });
        }

        var response = new Response<List<AllBookingResponse>>
        {
            Data = customerServices.Select(c => new AllBookingResponse(
                c.Id,
                c.CustomerId,
                c.ServiceId,
                c.Description,
                c.Status, // Convert StatusEnum to string  
                c.RequestedDate
            )).ToList(),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer services retrieved successfully",
            Succeeded = true
        };

        return NewResult(response);
    }
    // 1. Add a Booking Request
    [HttpPost("book")]
    public async Task<IActionResult> AddCustomerService([FromBody] BookingRequest request)
    {
        if (!_unitOfWork.GenericRepository<Customer>().ExistsNoTracking(c => c.Id == request.CustomerId))
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer not found",
                Succeeded = false
            });
        }
        if (!_unitOfWork.GenericRepository<Service>().ExistsNoTracking(s => s.Id == request.ServiceId))
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Service not found",
                Succeeded = false
            });
        }
        var customerService = new CustomerService
        {
            CustomerId = request.CustomerId,
            ServiceId = request.ServiceId,
            Description = request.Description,
            Status = StatusEnum.Pending, // Set initial status to Pending
            RequestedDate = DateTime.UtcNow // Set the requested date to now
        };
        _unitOfWork.GenericRepository<CustomerService>().Add(customerService);
        var saveResult = await _unitOfWork.SaveAsync();
        if (saveResult <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to add customer service request",
                Succeeded = false
            });
        }
        return Ok(customerService.Id);
    }

    // 2. Schedule the Booking
    [HttpPut("schedule-booking")]
    public async Task<IActionResult> ScheduleBooking([FromBody] ScheduleBookingRequest request)
    {
        // Validate the request
        if (request == null || request.ScheduledDate == null)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Invalid request data",
                Succeeded = false
            });
        }

        var customerRequest = await _unitOfWork.GenericRepository<CustomerService>().GetByIdAsync(request.Id);
        if (customerRequest == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer request not found",
                Succeeded = false
            });
        }

        // Update the scheduled date and status
        customerRequest.ScheduledDate = request.ScheduledDate;
        customerRequest.Status = StatusEnum.InProgress; // Update status to InProgress

        _unitOfWork.GenericRepository<CustomerService>().Update(customerRequest);
        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to schedule customer request",
                Succeeded = false
            });
        }

        return Ok(new Response<object>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer request scheduled successfully",
            Succeeded = true
        });
    }

    // 3. Assign a Employee
    [HttpPut("assign/{id}")]
    public async Task<IActionResult> AssignEmployee(int id, [FromBody] AssignEmployeeRequest request)
    {
        // Validate the request
        if (request == null || request.EmployeeId <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Invalid request data",
                Succeeded = false
            });
        }

        // Retrieve the existing customer request
        var customerRequest = await _unitOfWork.GenericRepository<CustomerService>().GetByIdAsync(id);
        if (customerRequest == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer request not found",
                Succeeded = false
            });
        }


        // Optionally, update the status if needed
        if (customerRequest.Status == StatusEnum.Pending)
        {
            customerRequest.Status = StatusEnum.InProgress; // Update status to InProgress if assigning
        }

        _unitOfWork.GenericRepository<CustomerService>().Update(customerRequest);
        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to assign employee",
                Succeeded = false
            });
        }

        return Ok(new Response<object>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Employee assigned successfully",
            Succeeded = true
        });
    }
    // 4. Complete the Booking
    [HttpPut("complete/{id}")]
    public async Task<IActionResult> CompleteBooking(int id)
    {
        // Retrieve the existing customer request
        var customerRequest = await _unitOfWork.GenericRepository<CustomerService>().GetByIdAsync(id);
        if (customerRequest == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer request not found",
                Succeeded = false
            });
        }

        // Mark the booking as completed
        customerRequest.Status = StatusEnum.Completed; // Update status to Completed
        customerRequest.CompletedDate = DateTime.UtcNow; // Set the completed date

        _unitOfWork.GenericRepository<CustomerService>().Update(customerRequest);
        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to complete customer request",
                Succeeded = false
            });
        }

        return Ok(new Response<object>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer request completed successfully",
            Succeeded = true
        });
    }
}