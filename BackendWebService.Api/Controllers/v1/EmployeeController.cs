using Api.Base;
using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;


[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeeController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public EmployeeController(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
    {
        // Create User  
        //var user = new User
        //{
        //    FirstName = request.FirstName,
        //    LastName = request.LastName,
        //    UserName = request.Email, // Use email as username  
        //    Email = request.Email,
        //    PhoneNumber = request.PhoneNumber,
        //    IsActive = true,
        //    IsDeleted = false,
        //    CreatedDate = DateTime.UtcNow,
        //    MainRole = RoleEnum.Employee
        //};

        //// Create user with Identity  
        //var identityResult = await _userManager.CreateAsync(user, request.Password);
        //if (!identityResult.Succeeded)
        //{
        //    var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
        //    return BadRequest(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.BadRequest,
        //        Message = $"Failed to create user: {errors}",
        //        Succeeded = false
        //    });
        //}

        ////// Create Employee  
        ////var employee = new Employee
        ////{

        ////};

        ////_unitOfWork.GenericRepository<Employee>().Add(employee);
        //var saveResult = _unitOfWork.Save();

        //if (saveResult <= 0)
        //{
        //    // Rollback user creation if customer save fails  
        //    await _userManager.DeleteAsync(user);
        //    return BadRequest(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.BadRequest,
        //        Message = "Failed to create customer",
        //        Succeeded = false
        //    });
        //}

        //var response = new Response<EmployeeResponse>
        //{
        //    Data = new EmployeeResponse(
        //        user.Id,
        //        user.FirstName,
        //        user.LastName,
        //        user.Email,
        //        user.PhoneNumber,
        //        user.MainRole.ToString(),
        //        user.CreatedDate
        //    ),
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Employee created successfully",
        //    Succeeded = true
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee([FromRoute] int id)
    {
        //var employee = _unitOfWork.GenericRepository<Employee>().Get(c => c.Id == id);
        //if (employee == null)
        //{
        //    return NotFound(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.NotFound,
        //        Message = "Employee not found",
        //        Succeeded = false
        //    });
        //}

        //var response = new Response<EmployeeResponse>
        //{
        //    Data = new EmployeeResponse
        //    (
        //        employee.Id,
        //        employee.User.FirstName,
        //        employee.User.LastName,
        //        employee.User.Email,
        //        employee.User.PhoneNumber,
        //        employee.User.MainRole.ToString(),
        //        employee.CreatedDate
        //    ),
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Employee found",
        //    Succeeded = true
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
    {
        //var employee = _unitOfWork.GenericRepository<Employee>()
        //    .Get(c => c.Id == request.Id);
        //if (employee == null)
        //{
        //    return NotFound(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.NotFound,
        //        Message = "Employee not found",
        //        Succeeded = false
        //    });
        //}

        //// Update User
        //employee.User.FirstName = request.FirstName;
        //employee.User.LastName = request.LastName;
        //employee.User.Email = request.Email;
        //employee.User.UserName = request.Email; // Keep UserName in sync with Email
        //employee.User.PhoneNumber = request.PhoneNumber;
        //employee.AccountStatus = request.Status;

        //_unitOfWork.GenericRepository<Employee>().Update(employee);
        //var saveResult = _unitOfWork.Save();

        //if (saveResult <= 0)
        //{
        //    return BadRequest(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.BadRequest,
        //        Message = "Failed to update customer",
        //        Succeeded = false
        //    });
        //}

        //var response = new Response<EmployeeResponse>
        //{
        //    Data = new EmployeeResponse
        //    (
        //        employee.Id,
        //        employee.User.FirstName,
        //        employee.User.LastName,
        //        employee.User.Email,
        //        employee.User.PhoneNumber,
        //        employee.User.MainRole.ToString(),
        //        employee.CreatedDate
        //    ),
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Employee updated successfully",
        //    Succeeded = true
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        //var customers = _unitOfWork.GenericRepository<Employee>().GetAll();
        //if (customers == null || !customers.Any())
        //{
        //    return NotFound(new Response<object>
        //    {
        //        StatusCode = ApiResultStatusCode.NotFound,
        //        Message = "No customers found",
        //        Succeeded = false
        //    });
        //}

        //var response = new Response<List<EmployeeResponse>>
        //{
        //    Data = customers.Select(c => new EmployeeResponse
        //    (
        //        c.Id,
        //        c.User.FirstName,
        //        c.User.LastName,
        //        c.User.Email,
        //        c.User.PhoneNumber,
        //        c.User.MainRole.ToString(),
        //        c.CreatedDate
        //     )).ToList(),
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Employees retrieved successfully",
        //    Succeeded = true
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

}