using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Validators.Common;
using Domain.Constants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;
using Application.DTOs.Company.Request;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling company-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : AppControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesController"/> class.
        /// </summary>
        /// <param name="companyService">Service to handle company operations.</param>
        /// <param name="userManager">Manager for handling user operations.</param>
        public CompaniesController(ICompanyService companyService, UserManager<User> userManager)
        {
            _companyService = companyService;
            _userManager = userManager;
        }

        /// <summary>
        /// Adds a new company.
        /// </summary>
        /// <param name="request">The company details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost]
        [Authorize(PermissionConstants.COMPANY_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            var result = await _companyService.AddAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets the details of a specific company by ID.
        /// </summary>
        /// <param name="id">The ID of the company.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.COMPANY_GET)]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            var result = await _companyService.GetAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a specific company by ID.
        /// </summary>
        /// <param name="id">The ID of the company to update.</param>
        /// <param name="request">The company update details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPut("{id}")]
        [Authorize(PermissionConstants.COMPANY_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdateCompany([FromRoute] int id, [FromBody] UpdateCompanyRequest request)
        {
            var result = await _companyService.UpdateAsync( request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets a paginated list of all companies based on the provided request.
        /// </summary>
        /// <param name="request">The pagination request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("GetAll")]
        [Authorize(PermissionConstants.COMPANY_VIEW)]
        public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
        {
            var result = await _companyService.GetPaginated(request);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a specific company by ID after validating the provided super password.
        /// </summary>
        /// <param name="id">The ID of the company to delete.</param>
        /// <param name="deleteSuperPasswordRequest">The super password request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("{id}")]
        [Authorize(PermissionConstants.COMPANY_DELETE)]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id, [FromBody] DeleteSuperPasswordRequest deleteSuperPasswordRequest)
        {
            var validator = new DeleteSuperPasswordRequestValidator(_userManager); // Assuming you have a validator for DeleteSuperPasswordRequest
            var validationResult = await validator.ValidateAsync(deleteSuperPasswordRequest);

            if (!validationResult.IsValid)
            {
                // If validation fails, return bad request with errors
                return BadRequest(validationResult.Errors);
            }

            // Validation passed, proceed with deletion
            var result = await _companyService.DeleteAsync(id);
            return NewResult(result);
        }
    }
}
