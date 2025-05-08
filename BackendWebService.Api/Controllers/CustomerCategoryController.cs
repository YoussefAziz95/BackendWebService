using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CustomerCategoryController : AppControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public CustomerCategoryController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // 1. Add a Booking Request
        [HttpPost("book")]
        public async Task<IActionResult> AddCustomerRequest([FromBody] BookingRequest request)
        {
            // Validate the request
            if (request == null || request.CustomerId <= 0 || request.CategoryId <= 0 || string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest(new Response<object>
                {
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = "Invalid request data",
                    Succeeded = false
                });
            }

            // Create CustomerCategoryRequest
            var customerRequest = new CustomerCategory
            {
                CustomerId = request.CustomerId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Status = StatusEnum.Pending, // Default status
                RequestedDate = DateTime.UtcNow,
                AssignedTechnicianId = null,
                ScheduledDate = null,
                CompletedDate = null
            };

            _unitOfWork.GenericRepository<CustomerCategory>().Add(customerRequest);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult <= 0)
            {
                return BadRequest(new Response<object>
                {
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = "Failed to create customer request",
                    Succeeded = false
                });
            }

            var response = new Response<BookingResponse>(
                true,
                ApiResultStatusCode.Success,
                new BookingResponse(
                    customerRequest.Id,
                    customerRequest.CustomerId,
                    customerRequest.Description,
                    customerRequest.Status,
                    customerRequest.RequestedDate
                ),
                "Customer request created successfully"
            );

            return NewResult(response);
        }

        // 2. Schedule the Booking
        [HttpPut("schedule-booking/{id}")]
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

            var customerRequest = await _unitOfWork.GenericRepository<CustomerCategory>().GetByIdAsync(request.Id);
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

            _unitOfWork.GenericRepository<CustomerCategory>().Update(customerRequest);
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

        // 3. Assign a Technician
        [HttpPut("assign/{id}")]
        public async Task<IActionResult> AssignTechnician(int id, [FromBody] AssignTechnicianRequest request)
        {
            // Validate the request
            if (request == null || request.TechnicianId <= 0)
            {
                return BadRequest(new Response<object>
                {
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = "Invalid request data",
                    Succeeded = false
                });
            }

            // Retrieve the existing customer request
            var customerRequest = await _unitOfWork.GenericRepository<CustomerCategory>().GetByIdAsync(id);
            if (customerRequest == null)
            {
                return NotFound(new Response<object>
                {
                    StatusCode = ApiResultStatusCode.NotFound,
                    Message = "Customer request not found",
                    Succeeded = false
                });
            }

            // Assign the technician
            customerRequest.AssignedTechnicianId = request.TechnicianId;

            // Optionally, update the status if needed
            if (customerRequest.Status == StatusEnum.Pending)
            {
                customerRequest.Status = StatusEnum.InProgress; // Update status to InProgress if assigning
            }

            _unitOfWork.GenericRepository<CustomerCategory>().Update(customerRequest);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult <= 0)
            {
                return BadRequest(new Response<object>
                {
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = "Failed to assign technician",
                    Succeeded = false
                });
            }

            return Ok(new Response<object>
            {
                StatusCode = ApiResultStatusCode.Success,
                Message = "Technician assigned successfully",
                Succeeded = true
            });
        }
        // 4. Complete the Booking
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteBooking(int id)
        {
            // Retrieve the existing customer request
            var customerRequest = await _unitOfWork.GenericRepository<CustomerCategory>().GetByIdAsync(id);
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

            _unitOfWork.GenericRepository<CustomerCategory>().Update(customerRequest);
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
}