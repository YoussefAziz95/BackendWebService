using Api.Base;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
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
    private readonly IUnitOfWork _unitOfWork;

    public FileSystemController(IFileSystemService fileSystemService,
        IUnitOfWork unitOfWork)
    {
        _fileSystemService = fileSystemService;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("uploadfile/{foldername}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadFile([FromRoute] string foldername, [FromForm] UploadRequest request)
    {
        try
        {
            var result = await _fileSystemService.UploadFile(request, foldername);

            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("error");
        }
    }

    [HttpPost("deletefile/{fileName}")]
    public IActionResult Delete([FromRoute] string fileName)
    {
        _fileSystemService.DeleteFile(fileName);

        return Ok();
    }
    [HttpGet("downloadfile/{id}")]
    public async Task<IActionResult> Download([FromRoute] int id)
    {
        var fileLog = _unitOfWork.GenericRepository<FileLog>().GetById(id);
        if (fileLog is null) return NotFound();
        var result = _fileSystemService.DownloadFileResponse(fileLog.FileName);
        if (result is null) return NotFound();

        var response = new Response<FileResponse>();
        result.FileName = fileLog.FileName;
        result.FullPath = fileLog.FullPath;
        result.Extention = fileLog.Extention;
        result.FileBase64 = await FileToBase64Async(fileLog.FullPath);
        response.StatusCode = ApiResultStatusCode.Success;
        response.Succeeded = true;
        response.Data = result;

        return NewResult(response);
    }


    [HttpGet("file/download/{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        // Retrieve file metadata by ID
        var file = _unitOfWork.GenericRepository<FileLog>().GetById(id);
        if (file == null)
        {
            return NotFound("File not found.");
        }


        // Get the physical file
        var filePath = file.FullPath;
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File does not exist on the server.");
        }

        // Stream the file to the client
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return File(fileStream, GetMimeTypeFromExtension(file.Extention), file.FileName);
    }
    [HttpGet("get-latest/")]
    public async Task<IActionResult> GetAll()
    {
        var fileLogs = _unitOfWork.GenericRepository<FileLog>().GetAll();
        if (fileLogs is null) return NotFound();

        var fileResponses = new List<FileResponse>();
        foreach (var fileLog in fileLogs)
        {
            var fileResponse = new FileResponse();
            fileResponse.FileName = fileLog.FileName;
            fileResponse.FullPath = fileLog.FullPath;
            fileResponse.Extention = fileLog.Extention;
            fileResponse.FileBase64 = await FileToBase64Async(fileLog.FullPath);
            fileResponses.Add(fileResponse);
        }

        var response = new Response<IEnumerable<FileResponse>>()
        {
            Data = fileResponses,
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "File found"
        };

        return NewResult(response);
    }
    

}
