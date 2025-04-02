using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Supplier.Request;
using Application.Validators.Common;
using Domain.Constants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller to manage suppliers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : AppControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierController"/> class.
        /// </summary>
        /// <param name="supplierService">The supplier service.</param>
        /// <param name="userManager">The user manager.</param>
        public SupplierController(ISupplierService supplierService, UserManager<User> userManager)
        {
            _supplierService = supplierService;
            _userManager = userManager;
        }

        /// <summary>
        /// Adds a new supplier.
        /// </summary>
        /// <param name="request">The request containing supplier details.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        [HttpPost("add")]
        [Authorize(PermissionConstants.VENDOR_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
        {
            var result = await _supplierService.AddRegisteredAsync(request);
            return NewResult(result);
        }
        /// <summary>
        /// Adds a new supplier.
        /// </summary>
        /// <param name="request">The request containing supplier details.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        [HttpPut("Register/{id}")]
        [Authorize(PermissionConstants.VENDOR_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddSupplier([FromRoute] int id)
        {
            var result = await _supplierService.RegisterAsync(id);
            return NewResult(result);
        }
        /// <summary>
        /// Gets a supplier by ID.
        /// </summary>
        /// <param name="id">The supplier ID.</param>
        /// <returns>A response containing the supplier details.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.VENDOR_GET)]
        public async Task<IActionResult> GetSupplier([FromRoute] int id)
        {
            var result = await _supplierService.GetAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a supplier by ID.
        /// </summary>
        /// <param name="id">The supplier ID.</param>
        /// <param name="request">The request containing updated supplier details.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        [HttpPut("{id}")]
        [Authorize(PermissionConstants.VENDOR_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierRequest request)
        {
            var result = await _supplierService.UpdateAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets all suppliers with pagination.
        /// </summary>
        /// <param name="request">The request containing pagination details.</param>
        /// <returns>A response containing the paginated list of suppliers.</returns>
        [HttpPost("GetAll")]
        [Authorize(PermissionConstants.VENDOR_VIEW)]
        public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
        {
            var result = await _supplierService.GetPaginated(request);
            return Ok(result);
        }

        [HttpPost("GetRegisterSuppliers")]
        [Authorize(PermissionConstants.VENDOR_VIEW)]
        public async Task<IActionResult> GetRegisterSuppliers([FromBody] GetPaginatedRequest request)
        {
            var result = await _supplierService.GetRegisterSuppliers(request);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a supplier by ID.
        /// </summary>
        /// <param name="id">The supplier ID.</param>
        /// <param name="deleteSuperPasswordRequest">The request containing the super password for verification.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        [HttpPost("{id}")]
        [Authorize(PermissionConstants.VENDOR_DELETE)]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id, [FromBody] DeleteSuperPasswordRequest deleteSuperPasswordRequest)
        {
            var validator = new DeleteSuperPasswordRequestValidator(_userManager); // Assuming you have a validator for DeleteSuperPasswordRequest
            var validationResult = await validator.ValidateAsync(deleteSuperPasswordRequest);

            if (!validationResult.IsValid)
            {
                // If validation fails, return bad request with errors
                return BadRequest(validationResult.Errors);
            }

            // Validation passed, proceed with deletion
            var result = await _supplierService.DeleteAsync(id);
            return NewResult(result);
        }

        [HttpPost("addSupplierToCompany")]
        [Authorize(PermissionConstants.VENDOR_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddSupplierToCompany( [FromBody] AddSupplierToCompany request)
        {
            var result = await _supplierService.AddSupplierTOCompany( request);
            return NewResult(result);
        }
    }
}
