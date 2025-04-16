using Api.Base;
using Application.Contracts.Services;
using Application.DTOs;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class FileSystemController : AppControllerBase
{
    private readonly IFileSystemService _fileSystemService;

    public FileSystemController(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    [HttpPost("uploadfile/{foldername}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadFile([FromRoute] string foldername, [FromForm] UploadRequest request)
    {
        try
        {
            var result = await _fileSystemService.UploadFile(request, foldername);
            return NewResult(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("error");
        }
    }

    [HttpPost("deletefile")]
    public IActionResult Delete([FromBody] DeleteRequest request)
    {
        var result = _fileSystemService.DeleteFile(request);

        return NewResult(result);
    }

    [HttpGet("downloadfile/{id}")]
    public IActionResult Download([FromRoute] int id)
    {
        if (id == 0) return Ok();
        var result = _fileSystemService.DownloadFile(id);

        if (result.StatusCode == ApiResultStatusCode.NotFound)
            return NewResult(result);

        return File(System.IO.File.OpenRead(result.Data!.FilePath!), result.Data!.MimeType!, result.Data!.FileName);
    }

}
