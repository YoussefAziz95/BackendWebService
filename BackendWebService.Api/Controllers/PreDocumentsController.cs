using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.PreDocument;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling pre document-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PreDocumentsController : AppControllerBase
    {
        private readonly IPreDocumentService _preDocumentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDocumentsController"/> class.
        /// </summary>
        /// <param name="preDocumentService">Service to handle pre document operations.</param>
        public PreDocumentsController(IPreDocumentService preDocumentService)
        {
            _preDocumentService = preDocumentService;
        }

        /// <summary>
        /// Adds a new pre document.
        /// </summary>
        /// <param name="request">The pre document details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost]
        //[Authorize(PermissionConstants.PREDOCUMENT_CREATE)]
        [ModelValidator]
        public async Task<IActionResult> AddPreDocument([FromBody] AddPreDocumentRequest request)
        {
            var result = await _preDocumentService.AddAsync(request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets the details of a specific pre document by ID.
        /// </summary>
        /// <param name="id">The ID of the pre document.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet("{id}")]
        [Authorize(PermissionConstants.PREDOCUMENT_GET)]
        public async Task<IActionResult> GetPreDocument([FromRoute] int id)
        {
            var result = await _preDocumentService.GetAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Deletes a specific pre document by ID.
        /// </summary>
        /// <param name="id">The ID of the pre document to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpDelete("{id}")]
        [Authorize(PermissionConstants.PREDOCUMENT_DELETE)]
        public async Task<IActionResult> DeletePreDocument([FromRoute] int id)
        {
            var result = await _preDocumentService.DeleteAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Updates a specific pre document by ID.
        /// </summary>
        /// <param name="id">The ID of the pre document to update.</param>
        /// <param name="request">The pre document update details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPut("{id}")]
        //[Authorize(PermissionConstants.PREDOCUMENT_EDIT)]
        [ModelValidator]
        public async Task<IActionResult> UpdatePreDocument([FromRoute] int id, [FromBody] UpdatePreDocumentRequest request)
        {
            var result = await _preDocumentService.UpdateAsync(id, request);
            return NewResult(result);
        }

        /// <summary>
        /// Gets a paginated list of all pre documents based on the provided request.
        /// </summary>
        /// <param name="request">The pagination request details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpPost("GetAll")]
        [Authorize(PermissionConstants.PREDOCUMENT_VIEW)]
        public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
        {
            var result = await _preDocumentService.GetPaginated(request);
            return Ok(result);
        }

        /// <summary>
        /// Gets a list of all pre documents.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
        [HttpGet]
        [Authorize(PermissionConstants.PREDOCUMENT_VIEW)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _preDocumentService.GetAllAsync();
            return Ok(result);
        }
    }
}
