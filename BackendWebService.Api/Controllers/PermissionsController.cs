using Application.Contracts.Services;
using Application.DTOs.Permission;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller to manage permissions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : AppControllerBase
    {
        private readonly IPermissionService _permissionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionsController"/> class.
        /// </summary>
        /// <param name="permissionService">The permission service.</param>
        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Retrieves all permissions.
        /// </summary>
        /// <returns>A response containing all permissions.</returns>
        [HttpGet]
        [Authorize(PermissionConstants.PERMISSION_VIEW)]
        public IActionResult GetAll()
        {
            var result = _permissionService.GetAll();
            return NewResult(result);
        }
        /// <summary>
        /// Retrieves permissions associated with a role.
        /// </summary>
        /// <param name="id">The ID of the role.</param>
        /// <returns>A response containing permissions associated with the role.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.PERMISSION_VIEW)]
        public async Task<IActionResult> GetRolePermissions([FromRoute] int id)
        {
            var result = await _permissionService.GetRolePermissions(id);
            return NewResult(result);
        }
        /// <summary>
        /// Retrieves pages accessible to a user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>A response containing pages accessible to the user.</returns>
        [HttpGet("GetUserPages/{id}")]
        //[Authorize(PermissionConstants.PERMISSION_VIEW)]
        public async Task<IActionResult> GetUserPages(int id)
        {
            var result = await _permissionService.GetUserPages(id);
            return NewResult(result);
        }
    }
}
