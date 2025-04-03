using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Roles;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers
{
    /// <summary>
    /// Controller responsible for handling role-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : AppControllerBase
    {
        private readonly IApplicationRoleService _roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="roleService">Services to handle role operations.</param>
        public RolesController(IApplicationRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Gets a paginated list of all roles based on the provided request.
        /// </summary>
        /// <param name="request">The pagination request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet]
        [Authorize(PermissionConstants.ROLE_VIEW)]
        public async Task<IActionResult> GetAll([FromQuery] GetPaginatedRequest request)
        {
            var result = await _roleService.GetRolesPaginated(request);
            return Ok(result);
        }

        /// <summary>
        /// Adds a role to a user.
        /// </summary>
        /// <param name="request">The request details to add a role to a user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("addRoleToUser")]
        [Authorize(PermissionConstants.ROLE_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleToUserRequest request)
        {
            var result = await _roleService.AddRoleToUserAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Adds a new role.
        /// </summary>
        /// <param name="request">The request details to add a role.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("addRole")]
        [Authorize(PermissionConstants.ROLE_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleRequest request)
        {
            var result = await _roleService.AddRoleAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets the details of a specific role by ID.
        /// </summary>
        /// <param name="id">The ID of the role.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.ROLE_GET)]
        public async Task<IActionResult> GetRole([FromRoute] int id)
        {
            var result = await _roleService.GetRoleAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Deletes a specific role by ID.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpDelete("{id}")]
        [Authorize(PermissionConstants.ROLE_DELETE)]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a specific role by ID.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="request">The role update details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPut("{id}")]
        [Authorize(PermissionConstants.ROLE_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
        {
            var result = await _roleService.UpdateRoleAsync(id, request);
            return NewResult(result);
        }
    }
}
