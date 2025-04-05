using Api.Base;
using Application.Contracts.Services;
using Application.DTOs.Utility;
using Application.Validators.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UtilityController : AppControllerBase
{
    private readonly IUtilityService _utilityService;

    public UtilityController(IUtilityService utilitService)
    {
        _utilityService = utilitService;
    }

    [HttpPost("/upload")]
    [ModelValidator]
    public async Task<IActionResult> Upload()
    {
        try
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var request = new UploadRequest { File = file };
            var result = await _utilityService.UploadFile(request);

            return NewResult(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return BadRequest();
    }

    [HttpPost("/delete")]
    [ModelValidator]
    public IActionResult Delete([FromBody] DeleteRequest request)
    {
        var result = _utilityService.DeleteFile(request);

        return NewResult(result);
    }

    [HttpGet("/download/{fileName}")]
    public IActionResult Download([FromRoute] string fileName)
    {
        var result = _utilityService.DownloadFile(fileName);

        if (result.StatusCode == ApiResultStatusCode.NotFound)
            return NewResult(result);

        return File(System.IO.File.OpenRead(result.Data!.FilePath!), result.Data!.MimeType!, result.Data!.FileName);
    }
}
