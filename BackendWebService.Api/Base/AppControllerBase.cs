using Application.Contracts.Features;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Extensions;
using System.Security.Claims;
namespace Api.Base;


[ApiController]
public class AppControllerBase : ControllerBase
{

    protected string UserName => User.Identity?.Name;
    protected int UserId => int.Parse(User.Identity.GetUserId());
    protected string UserEmail => User.Identity.FindFirstValue(ClaimTypes.Email);
    protected string UserRole => User.Identity.FindFirstValue(ClaimTypes.Role);

    protected string UserKey => User.FindFirstValue(ClaimTypes.UserData);
    public ObjectResult NewResult<T>(IResponse<T> response)
    {
        switch (response.StatusCode)
        {
            case ApiResultStatusCode.Ok:
                return new OkObjectResult(response);
            case ApiResultStatusCode.Success:
                return new ObjectResult(response);
            case ApiResultStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case ApiResultStatusCode.UnAuthorized:
                return new UnauthorizedObjectResult(response);
            case ApiResultStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case ApiResultStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case ApiResultStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case ApiResultStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }

    }
    public static string GetMimeTypeFromExtension(string extension)
    {
        return extension.ToLower() switch
        {
            ".txt" => "text/plain",
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".gif" => "image/gif",
            ".csv" => "text/csv",
            ".zip" => "application/zip",
            ".json" => "application/json",
            ".xml" => "application/xml",
            ".mp4" => "video/mp4",
            ".mp3" => "audio/mpeg",
            _ => "application/octet-stream" // Default for unknown types
        };
    }
    [NonAction]
    public async Task<string> FileToLink(int fileId)
    {
        string imageFolderPath = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/FileSystem/file/download/1";

        try
        {
            imageFolderPath = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/FileSystem/file/download/{fileId}";
        }
        catch (Exception ex)
        {
            // optionally log
        }

        return imageFolderPath;
    }




}
