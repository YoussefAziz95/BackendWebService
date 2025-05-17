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
    private readonly UserManager<User> _userManager;

    public TechnicianController(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddTechnician([FromBody] AddTechnicianRequest request)
    {
        // Create User  
        var user = new User
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

        // Create Technician  
        var technician = new Technician
        {
            UserId = user.Id,
            User = user,
        };

        _unitOfWork.GenericRepository<Technician>().Add(technician);
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
                technician.Id,
                technician.UserId,
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
        var technician = _unitOfWork.GenericRepository<Technician>()
            .Get(c => c.Id == id, include: c => c.Include(u => u.User));
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
                technician.UserId,
                technician.User.FirstName,
                technician.User.LastName,
                technician.User.Email,
                technician.User.PhoneNumber,
                technician.User.MainRole.ToString(),
                technician.User.CreatedDate
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
            .Get(c => c.Id == request.Id, include: c => c.Include(u => u.User));
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
        technician.User.FirstName = request.FirstName;
        technician.User.LastName = request.LastName;
        technician.User.Email = request.Email;
        technician.User.UserName = request.Email; // Keep UserName in sync with Email
        technician.User.PhoneNumber = request.PhoneNumber;

        // Update Technician
        technician.User.PhoneNumber = request.PhoneNumber;

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
                technician.UserId,
                technician.User.FirstName,
                technician.User.LastName,
                technician.User.Email,
                technician.User.PhoneNumber,
                technician.User.MainRole.ToString(),
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
        var customers = _unitOfWork.GenericRepository<Technician>()
            .GetAll(include: c => c.Include(u => u.User));
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
                c.UserId,
                c.User.FirstName,
                c.User.LastName,
                c.User.Email,
                c.User.PhoneNumber,
                c.User.MainRole.ToString(),
                c.User.CreatedDate
             )).ToList(),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Technicians retrieved successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

}