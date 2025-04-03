using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Users;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers
{
    /// <summary>
    /// Controller responsible for managing user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : AppControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The service responsible for managing users.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="request">The request containing information about the user to be added.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [Authorize(PermissionConstants.USER_CREATE)]
        [HttpPost]
        [ModelValidator]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            var result = await _userService.AddAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Retrieves a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpGet]
        [Authorize(PermissionConstants.USER_GET)]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _userService.Get(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="request">The request containing updated information about the user.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpPut("{id}")]
        [Authorize(PermissionConstants.USER_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest request)
        {
            var result = await _userService.UpdateAsync(id, request);
            return NewResult(result);
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpDelete]
        [Authorize(PermissionConstants.USER_DELETE)]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.DeleteAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Retrieves a paginated list of all users.
        /// </summary>
        /// <param name="request">The request containing pagination parameters.</param>
        /// <returns>An <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpGet]
        [Authorize(Policy = PermissionConstants.USER_VIEW)]
        public IActionResult GetAll([FromQuery] GetPaginatedRequest request)
        {
            var result = _userService.GetUsersPaginated(request);
            return Ok(result);
        }

        /// <summary>
        /// Changes the password for a specific user.
        /// </summary>
        /// <param name="id">The ID of the user whose password needs to be changed.</param>
        /// <param name="request">The request containing the new password.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpPost]
        [ModelValidator]
        [Route("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword([FromRoute] int id, [FromBody] ChangePasswordRequest request)
        {
            var result = await _userService.ChangePassword(id, request);
            return NewResult(result);
        }

        /// <summary>
        /// Activates or deactivates OTP (One-Time Password) for a user.
        /// </summary>
        /// <param name="request">The request containing information about OTP activation/deactivation.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpPost("ActivateDeactivateOtp")]
        [Authorize]
        public async Task<IActionResult> ActivateDeactivateOtp(ActivateDeactivateOtpRequest request)
        {
            var result = await _userService.ActivateDeactivateOtp(request);
            if (request.HasOtp && result.Succeeded)
                HttpContext.Session.SetString(AppConstants.UserOtpType, "false");
            else HttpContext.Session.Remove(AppConstants.UserOtpType);
            return NewResult(result);
        }
    }
}
