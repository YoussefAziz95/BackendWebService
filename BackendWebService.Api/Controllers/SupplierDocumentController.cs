using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.SupplierDocuments;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers
{
    /// <summary>
    /// Controller responsible for handling supplier document-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierDocumentController : AppControllerBase
    {
        private readonly ISupplierDocumentService _supplierdocumentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDocumentController"/> class.
        /// </summary>
        /// <param name="supplierdocumentService">Services to handle supplier document operations.</param>
        public SupplierDocumentController(ISupplierDocumentService supplierdocumentService)
        {
            _supplierdocumentService = supplierdocumentService;
        }

        /// <summary>
        /// Adds a new supplier document.
        /// </summary>
        /// <param name="request">The request details to add a supplier document.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost]
        [Authorize(PermissionConstants.VENDORDOCUMENT_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddSupplierDocument([FromBody] AddSupplierDocumentRequest request)
        {
            var result = await _supplierdocumentService.AddAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets the details of a specific supplier document by ID.
        /// </summary>
        /// <param name="id">The ID of the supplier document.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.VENDORDOCUMENT_GET)]
        public async Task<IActionResult> GetSupplierDocument([FromRoute] int id)
        {
            var result = await _supplierdocumentService.GetAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a specific supplier document by ID.
        /// </summary>
        /// <param name="id">The ID of the supplier document to update.</param>
        /// <param name="request">The supplier document update details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPut]
        [Authorize(PermissionConstants.VENDORDOCUMENT_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdateSupplierDocument( [FromBody] UpdateSupplierDocumentRequest request)
        {
            var result = await _supplierdocumentService.UpdateAsync( request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets a paginated list of supplier documents based on the provided supplier ID.
        /// </summary>
        /// <param name="id">The ID of the supplier.</param>
        /// <param name="request">The pagination request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("GetAll/{id}")]
        [Authorize(PermissionConstants.VENDORDOCUMENT_VIEW)]
        public async Task<IActionResult> GetAll([FromRoute] int id, [FromBody] GetPaginatedRequest request)
        {
            var result = await _supplierdocumentService.GetPaginated(id);
            return Ok(result);
        }
    }
}
