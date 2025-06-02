using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class TechnicianController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Technician> _userManager;

    public TechnicianController(IUnitOfWork unitOfWork, UserManager<Technician> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddTechnician([FromBody] AddTechnicianRequest request)
    {
        // Create User  
        var user = new Technician
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email, // Use email as username  
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IsActive = true,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow,
            MainRole = RoleEnum.Technician
        };

        // Create user with Identity  
        var identityResult = await _userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = $"Failed to create user: {errors}",
                Succeeded = false
            });
        }

        //// Create Technician  
        //var technician = new Technician
        //{
            
        //};

        //_unitOfWork.GenericRepository<Technician>().Add(technician);
        var saveResult = _unitOfWork.Save();

        if (saveResult <= 0)
        {
            // Rollback user creation if customer save fails  
            await _userManager.DeleteAsync(user);
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to create customer",
                Succeeded = false
            });
        }

        var response = new Response<TechnicianResponse>
        {
            Data = new TechnicianResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.MainRole.ToString(),
                user.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Technician created successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTechnician([FromRoute] int id)
    {
        var technician = _unitOfWork.GenericRepository<Technician>().Get(c => c.Id == id);
        if (technician == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Technician not found",
                Succeeded = false
            });
        }

        var response = new Response<TechnicianResponse>
        {
            Data = new TechnicianResponse
            (
                technician.Id,
                technician.FirstName,
                technician.LastName,
                technician.Email,
                technician.PhoneNumber,
                technician.MainRole.ToString(),
                technician.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Technician found",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTechnician([FromBody] UpdateTechnicianRequest request)
    {
        var technician = _unitOfWork.GenericRepository<Technician>()
            .Get(c => c.Id == request.Id);
        if (technician == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Technician not found",
                Succeeded = false
            });
        }

        // Update User
        technician.FirstName = request.FirstName;
        technician.LastName = request.LastName;
        technician.Email = request.Email;
        technician.UserName = request.Email; // Keep UserName in sync with Email
        technician.PhoneNumber = request.PhoneNumber;

        // Convert the string status to the StatusEnum type
        if (!Enum.TryParse(request.Status, out StatusEnum parsedStatus))
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Invalid status value",
                Succeeded = false
            });
        }

        technician.AccountStatus = parsedStatus;

        _unitOfWork.GenericRepository<Technician>().Update(technician);
        var saveResult = _unitOfWork.Save();

        if (saveResult <= 0)
        {
            return BadRequest(new Response<object>
            {
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = "Failed to update customer",
                Succeeded = false
            });
        }

        var response = new Response<TechnicianResponse>
        {
            Data = new TechnicianResponse
            (
                technician.Id,
                technician.FirstName,
                technician.LastName,
                technician.Email,
                technician.PhoneNumber,
                technician.MainRole.ToString(),
                technician.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Technician updated successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var customers = _unitOfWork.GenericRepository<Technician>().GetAll();
        if (customers == null || !customers.Any())
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "No customers found",
                Succeeded = false
            });
        }

        var response = new Response<List<TechnicianResponse>>
        {
            Data = customers.Select(c => new TechnicianResponse
            (
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.PhoneNumber,
                c.MainRole.ToString(),
                c.CreatedDate
             )).ToList(),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Technicians retrieved successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

}