using Microsoft.AspNetCore.Http;

namespace Application.DTOs;

public record UploadRequest(IFormFile? File);
public record FileResponse(string FullName, string FullPath, string Name, string Extention);
public record DeleteRequest(string FileName);