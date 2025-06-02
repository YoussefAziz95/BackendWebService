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
public class CustomerController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Customer> _userManager;

    public CustomerController(IUnitOfWork unitOfWork, UserManager<Customer> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
    {
        // Create User  
        var user = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email, // Use email as username  
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IsActive = true,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow,
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

        // Create Customer  
        var customer = new Customer
        {
        };

        _unitOfWork.GenericRepository<Customer>().Add(customer);
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

        var response = new Response<CustomerResponse>
        {
            Data = new CustomerResponse(
                customer.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                customer.MFAEnabled,
                customer.Role,
                customer.Status,
                user.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer created successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer([FromRoute] int id)
    {
        var customer = _unitOfWork.GenericRepository<Customer>()
            .Get(c => c.Id == id);
        if (customer == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer not found",
                Succeeded = false
            });
        }

        var response = new Response<CustomerResponse>
        {
            Data = new CustomerResponse
            (
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.PhoneNumber,
                customer.MFAEnabled,
                customer.Role,
                customer.Status,
                customer.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer found",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
    {
        var customer = _unitOfWork.GenericRepository<Customer>()
            .Get(c => c.Id == request.Id);
        if (customer == null)
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "Customer not found",
                Succeeded = false
            });
        }

        // Update User
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.UserName = request.Email; // Keep UserName in sync with Email
        customer.PhoneNumber = request.PhoneNumber;

        // Update Customer
        customer.PhoneNumber = request.PhoneNumber;
        customer.MFAEnabled = request.MFAEnabled;
        customer.Status = request.Status;

        _unitOfWork.GenericRepository<Customer>().Update(customer);
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

        var response = new Response<CustomerResponse>
        {
            Data = new CustomerResponse
            (
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.PhoneNumber,
                customer.MFAEnabled,
                customer.Role,
                customer.Status,
                customer.CreatedDate
            ),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customer updated successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var customers = _unitOfWork.GenericRepository<Customer>().GetAll();
        if (customers == null || !customers.Any())
        {
            return NotFound(new Response<object>
            {
                StatusCode = ApiResultStatusCode.NotFound,
                Message = "No customers found",
                Succeeded = false
            });
        }

        var response = new Response<List<CustomerResponse>>
        {
            Data = customers.Select(c => new CustomerResponse
            (
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.PhoneNumber,
                c.MFAEnabled,
                c.Role,
                c.Status,
                c.CreatedDate
            )).ToList(),
            StatusCode = ApiResultStatusCode.Success,
            Message = "Customers retrieved successfully",
            Succeeded = true
        };

        return NewResult(response);
    }

}