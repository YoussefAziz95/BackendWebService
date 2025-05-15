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
    [HttpGet("get-time-slots/")]
    public IActionResult GetNextInterval()
    {
        var now = DateTime.Now;

        var start = GetNextInterval(now);
        var intervals = new List<object>();

        for (int i = 0; i < 16; i++)
        {
            var end = start.AddMinutes(30);
            intervals.Add(new
            {
                start_time = start.ToString("yyyy-MM-ddTHH:mm:ss"),
                end_time = end.ToString("yyyy-MM-ddTHH:mm:ss")
            });

            start = end;
        }

        return Ok(intervals);
    }

    private static DateTime GetNextInterval(DateTime currentTime)
    {
        int minutes = currentTime.Minute;
        int addMinutes = 0;

        if (minutes == 0 || minutes == 30)
        {
            addMinutes = 30;
        }
        else if (minutes < 30)
        {
            addMinutes = 30 - minutes;
        }
        else
        {
            addMinutes = 60 - minutes;
        }

        return currentTime.AddMinutes(addMinutes);
    }
}
