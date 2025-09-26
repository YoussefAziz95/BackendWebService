using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class FileController(IMediator mediator, IFileSystemService fileSystemService, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("uploadfile/{foldername}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadFile([FromRoute] string foldername, [FromForm] UploadRequest request)
    {
        try
        {
            var result = await fileSystemService.UploadFile(request, foldername);

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
        fileSystemService.DeleteFile(fileName);

        return Ok();
    }
    [HttpGet("downloadfile/{id}")]
    public async Task<IActionResult> Download([FromRoute] int id)
    {
        var fileLog = unitOfWork.GenericRepository<FileLog>().GetById(id);
        if (fileLog is null) return NotFound();
        var result = fileSystemService.DownloadFileResponse(fileLog.FileName);
        if (result is null) return NotFound();

        var response = new Response<FileResponse>();
        response.StatusCode = ApiResultStatusCode.Success;
        response.Succeeded = true;
        response.Data = new FileResponse(
                            fileLog.FileName,
                            fileLog.FullPath,
                            fileLog.Extention,
                            FileToLink(fileLog.Id));

        return NewResult(response);
    }


    [HttpGet("file/download/{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        // Retrieve file metadata by ID
        var file = unitOfWork.GenericRepository<FileLog>().GetById(id);
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
    public IActionResult GetAll()
    {
        var fileLogs = unitOfWork.GenericRepository<FileLog>().GetAll();
        if (fileLogs is null) return NotFound();

        var fileResponses = new List<FileResponse>();
        foreach (var fileLog in fileLogs)
        {
            var fileResponse = new FileResponse(
                                    fileLog.FileName,
                                    fileLog.FullPath,
                                    fileLog.Extention,
                                    FileToLink(fileLog.Id));
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
    //-------------------------------
    #region FileFieldValidator APIs
    //-------------------------------
    [HttpPost("add-file-field-validator")]
    public async Task<IActionResult> AddFileFieldValidator([FromBody] AddFileFieldValidatorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-file-field-validator/{id}")]
    public async Task<IActionResult> GetFileFieldValidator([FromRoute] int id)
    {
        var response = mediator.HandleById<FileFieldValidatorResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-file-field-validator")]
    public async Task<IActionResult> UpdateFileFieldValidator([FromBody] UpdateFileFieldValidatorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-file-field-validator")]
    public IActionResult GetAll(FileFieldValidatorAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-file-field-validator")]
    public async Task<IActionResult> DeleteFileFieldValidator([FromBody] DeleteFileFieldValidatorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region FileLog APIs
    //-------------------------------
    [HttpPost("add-file-log")]
    public async Task<IActionResult> AddFileLog([FromBody] AddFileLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-file-log/{id}")]
    public async Task<IActionResult> GetFileLog([FromRoute] int id)
    {
        var response = mediator.HandleById<FileLogResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-file-log")]
    public async Task<IActionResult> UpdateFileLog([FromBody] UpdateFileLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-file-log")]
    public IActionResult GetAll(FileLogAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-file-log")]
    public async Task<IActionResult> DeleteFileLog([FromBody] DeleteFileLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region FileType APIs
    //-------------------------------
    [HttpPost("add-file-type")]
    public async Task<IActionResult> AddFileType([FromBody] AddFileTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-file-type/{id}")]
    public async Task<IActionResult> GetFileType([FromRoute] int id)
    {
        var response = mediator.HandleById<FileTypeResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-file-type")]
    public async Task<IActionResult> UpdateFileType([FromBody] UpdateFileTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-file-type")]
    public IActionResult GetAll(FileTypeAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-file-type")]
    public async Task<IActionResult> DeleteFileType([FromBody] DeleteFileTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

}
