using Api.Base;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class DropDownController : AppControllerBase
{
    private readonly IDropdownService _dropdownService;

    public DropDownController(IDropdownService dropdownService)
    {
        _dropdownService = dropdownService;
    }

    [HttpPost("List")]
    public async Task<IActionResult> List([FromBody] DropDownRequest request)
    {
        // Call the service to retrieve dropdown options
        var result = await _dropdownService.GetDropdownOptions(request.tableName, request.columnNames);

        // Return the result
        return NewResult(result);
    }
}
