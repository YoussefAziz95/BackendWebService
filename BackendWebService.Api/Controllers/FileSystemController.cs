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
public class FileSystemController : AppControllerBase
{
    private readonly IFileSystemService _fileSystemService;

    public FileSystemController(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    [HttpPost("uploadfile/{foldername}")]
    [ModelValidator]
    public async Task<IActionResult> uploadFile([FromRoute] string foldername)
    {
        try
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var id = int.Parse(formCollection["id"]);
            var createdDate = formCollection["CreatedDate"].ToString().Replace(" ", "_");
            var request = new UploadRequest { File = file, Id = id, CreatedDate = createdDate };
            var result = await _fileSystemService.UploadFile(request, foldername);

            return NewResult(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return BadRequest("error");
    }

    [HttpPost("deletefile")]
    [ModelValidator]
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
