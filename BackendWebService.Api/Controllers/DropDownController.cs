using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Validators.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling requests related to dropdown options.
    /// </summary>
    public class DropDownController : AppControllerBase
    {
        private readonly IDropdownService _dropdownService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownController"/> class.
        /// </summary>
        /// <param name="dropdownService">The service responsible for providing dropdown options.</param>
        public DropDownController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }

        /// <summary>
        /// Retrieves dropdown options based on the provided parameters.
        /// </summary>
        /// <param name="request">The request containing parameters for fetching dropdown options.</param>
        /// <returns>An asynchronous task that returns an <see cref="IActionResult"/> representing the operation result.</returns>
        [HttpPost("List")]
        [Authorize]
        [ModelValidator]
        public async Task<IActionResult> List([FromBody] DropDownRequest request)
        {
            // Call the service to retrieve dropdown options
            var result = await _dropdownService.GetDropdownOptions(request.tableName, request.columnNames);

            // Return the result
            return NewResult(result);
        }
    }
}
