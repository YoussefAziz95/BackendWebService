using Application.Contracts.DTOs;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace Api.Base;

[Route("api/[controller]")]
[ApiController]
public class AppControllerBase : ControllerBase
{
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
    public static async Task<string> FileToBase64Async(string path)
    {
        var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        byte[] fileBytes;
        await using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            fileBytes = new byte[stream.Length];
            await stream.ReadAsync(fileBytes, 0, (int)stream.Length);
        }
        return Convert.ToBase64String(fileBytes);
    }
}
