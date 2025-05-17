using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.DTOs;
public class FileResponse
{
    public string FileName { get; set; }
    public string FullPath { get; set; }
    public string Extention { get; set; }
    public string? FileBase64 { get; set; }

    public FileResponse(string fileName, string fullPath, string extention)
    {
        FileName = fileName;
        FullPath = fullPath;
        Extention = extention;
    }
    public FileResponse()
    {
    }

}
public record UploadRequest(IFormFile? File);

public record DeleteRequest(string FileName);