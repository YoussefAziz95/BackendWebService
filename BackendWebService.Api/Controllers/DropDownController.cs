using BackendWebService.Api.Base;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Validators.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Api.Controllers;

public class DropDownController : AppControllerBase
{
    private readonly IDropdownService _dropdownService;

    public DropDownController(IDropdownService dropdownService)
    {
        _dropdownService = dropdownService;
    }

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
